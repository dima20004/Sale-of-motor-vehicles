using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SalesServer {
	class Program {
		static void Main(string[] args) {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

			ServiceHost clientHost = null;

            try {
				string adress = "net.tcp://localhost:8080";

				var clientServer = LoggingNoErrorProxy<ClientMessaging.Messaging>.Create(
					"Клиентский сервер",
					new MainClientMessagingServer()
				);
				clientHost = new ServiceHost(clientServer, new Uri[] { new Uri(adress) });
				clientHost.AddServiceEndpoint(typeof(ClientMessaging.Messaging), new NetTcpBinding(), "client");
				clientHost.Opened += (a, b) => Console.WriteLine("Client server opened");
				clientHost.Open();

				Console.ReadKey();
			}
			catch(Exception e) {
				Console.Write("Error while working:\n{0}", e);
			}
			finally {
				if(clientHost != null) clientHost.Close();
			}
		}
	}
}
