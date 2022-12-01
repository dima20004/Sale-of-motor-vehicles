using Accounts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SalesServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
	class MainAdminMessagingServer : AdminMessaging.Messaging {
		private static ConnectionView conn { get { 
			return new SqlConnection(Properties.Settings1.Default.connectionString); 
		} }

		public bool updateRole(string login, ManagementRole role) {
			using(var c = conn) { return DBAccounts.updateRole(c, login, role); }
		}
	}
}
