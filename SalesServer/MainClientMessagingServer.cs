using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ClientMessaging;

namespace SalesServer {

	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = false)]
	class MainClientMessagingServer : Messaging {
		private static ConnectionView conn { get { 
			return new SqlConnection(Properties.Settings1.Default.connectionString); 
		} }

		public MainClientMessagingServer() {
			//test connection
			using(var connection = new SqlConnection(Properties.Settings1.Default.connectionString)) {}
		}

		Accounts.Account? Messaging.login(Accounts.AccountData account) {
			using(var connection = conn) { return DBAccounts.loginAccount(conn, account); }
		}

		bool Messaging.register(Accounts.AccountData account, string name, string surname) {
			using(var connection = conn) { return DBAccounts.registerAccount(
				connection, account, name, surname, Accounts.ManagementRole.user
			); }
		}

		Criteria.CriteriaInfo Messaging.getCriteria() {
			using(var c = conn) {
			using(
			var command = new SqlCommand(@"select [Id], [Name] from [Auto].[Brands]", c)) {
			command.CommandType = System.Data.CommandType.Text;

			var brands = new Dictionary<int, object>();

			c.Open();
			using(
			var reader = command.ExecuteReader()) {
			while(reader.Read()) brands.Add(reader.GetInt32(0), reader.GetString(1));
			reader.Close();
			command.Dispose();
			c.Dispose();

			return new Criteria.CriteriaInfo(brands);
			}}
			}
		}
	}
}
