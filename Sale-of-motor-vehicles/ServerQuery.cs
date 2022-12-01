using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;

namespace Common {
	public class ServerQuery<T> : System.Runtime.Remoting.Proxies.RealProxy, IDisposable {
		private ChannelFactory<T> factory;

		private ServerQuery(string adress) : base(typeof(T)) {
			var endpoint = new EndpointAddress(adress);
			var binding = new NetTcpBinding();
			factory = new ChannelFactory<T>(binding, endpoint);
		}

		public static T Create(string adress) {
			return (T)new ServerQuery<T>(adress).GetTransparentProxy();
		}

		public void Dispose() {
			factory.Close();
		}

		public override IMessage Invoke(IMessage msg) {
			var methodCall = (IMethodCallMessage) msg;

			try {
				var method = (MethodInfo) methodCall.MethodBase;

				//https://stackoverflow.com/a/10833801/18704284
				var service = factory.CreateChannel();
				var ar = ((System.ServiceModel.Channels.IChannel)service).BeginOpen(null, null);
				if(!ar.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, 0, 0, 500), true)) throw new TimeoutException("Service is not available");
				((System.ServiceModel.Channels.IChannel)service).EndOpen(ar);

				var result = method.Invoke(service, methodCall.InArgs);
				((IClientChannel)service).Dispose();
				return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
			}
			catch(Exception e) {
				if(e is TargetInvocationException && e.InnerException != null) {
					return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
				}
				else throw e;
			}
		}
	}

	public static class EnhancedMessaging {

		public static Attempt<T, Exception> attempt<A, T>(this A it, Func<A, T> action) {
			try { return Attempt<T, Exception>.Success(action.Invoke(it)); }
			catch(Exception e) { return Attempt<T, Exception>.Failure(e); }
		}
	}

	public sealed class Attempt<S, F> {
		private S success;
		private F failure;
		private bool isSuccess;

		private Attempt(){}

		public static Attempt<S, F> Success(S success) {
			return new Attempt<S, F>{ success = success, isSuccess = true };
		}

		public static Attempt<S, F> Failure(F failure) {
			return new Attempt<S, F>{ failure = failure, isSuccess = false };
		}

		public S s{ get{ 
			if(!isSuccess) throw new InvalidOperationException();
			return success;
		}}

		public F f{ get{ 
			if(isSuccess) throw new InvalidOperationException();
			return failure;
		}}

		public bool IsSuccess{ get{ return isSuccess; } }

		public static implicit operator bool(Attempt<S, F> it) { return it.isSuccess; }
	}
}

