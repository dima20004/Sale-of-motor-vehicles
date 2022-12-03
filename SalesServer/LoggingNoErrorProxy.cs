using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;

namespace SalesServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class LoggingNoErrorProxy<T> : System.Runtime.Remoting.Proxies.RealProxy {
		private readonly string prefix;
		private readonly T instance;
		
		private LoggingNoErrorProxy(string prefix, T instance) : base(typeof(T)) {
			this.prefix = prefix;
		    this.instance = instance;
		}
		
		public static T Create(string prefix,T instance) {
		    return (T) new LoggingNoErrorProxy<T>(prefix, instance).GetTransparentProxy();
		}
		
		public override IMessage Invoke(IMessage msg) {
			Stopwatch watch = null;
			try {
				var methodCall = (IMethodCallMessage) msg;
				var method = (MethodInfo) methodCall.MethodBase;
			
				watch = new Stopwatch();
				watch.Start();
		        var result = method.Invoke(instance, methodCall.InArgs);
				watch.Stop();

				var sb = new StringBuilder();

				sb.AppendFormat(
					"{0}: ответ ({1}ms) на `{2}`. результат - `{3}` = {{ ",
					prefix,
					watch?.Elapsed.TotalMilliseconds, methodCall?.MethodName, result?.GetType()
				);

				if(result != null) {
					var first = true;
					foreach(var field in result.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)) {
						if(!first) sb.Append(", ");
						sb.Append(field.GetValue(result)?.GetType().ToString() ?? "null");
						first = false;
					}
				}

				sb.Append(" }");
				sb.Append("\n");

				Console.WriteLine("{0}", sb.ToString());
		        return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
		    }
		    catch (Exception e) {
				watch.Stop();
				Console.WriteLine(
					"\n{0}: ошибка ответа ({1} ms) на `{2}`. причина - {3}\n",
					prefix,
					watch?.Elapsed.TotalMilliseconds,
					(msg as IMethodCallMessage)?.MethodName,
					e.ToString()
				);

		        if (e is TargetInvocationException && e.InnerException != null) {
					return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
				} 
				else throw e;
		    }
		}
	}
}
