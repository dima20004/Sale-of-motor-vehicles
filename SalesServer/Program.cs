using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SalesServer {
	class Program {
		static void Main(string[] args) {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

			ServiceHost clientHost = null;
			ServiceHost adminHost = null;

            try {
				string adress = "net.tcp://localhost:8080";

				var clientServer = LoggingNoErrorProxy<ClientMessaging.Messaging>.Create(
					"Клиентский сервер",
					new MainClientMessagingServer()
				);
				clientHost = new ServiceHost(clientServer, new Uri[] { new Uri(adress) });
				clientHost.AddServiceEndpoint(typeof(ClientMessaging.Messaging), new NetTcpBinding() { MaxReceivedMessageSize = int.MaxValue, MaxBufferPoolSize = int.MaxValue, MaxBufferSize = int.MaxValue }, "client");
				clientHost.Opened += (a, b) => Console.WriteLine("Client server opened\n");
				clientHost.Open();

				var adminServer = LoggingNoErrorProxy<AdminMessaging.Messaging>.Create(
					"Админский сервер", new MainAdminMessagingServer()
				);
				clientHost = new ServiceHost(adminServer, new Uri[] { new Uri(adress) });
				clientHost.AddServiceEndpoint(typeof(AdminMessaging.Messaging), new NetTcpBinding(), "admin");
				clientHost.Opened += (a, b) => Console.WriteLine("Admin server opened\n");
				clientHost.Open();

				Console.ReadKey();
			}
			catch(Exception e) {
				Console.Write("Error while working:\n{0}", e);
			}
			finally {
				if(clientHost != null) clientHost.Close();
				if(adminHost != null) adminHost.Close();
			}
		}
	}
}
