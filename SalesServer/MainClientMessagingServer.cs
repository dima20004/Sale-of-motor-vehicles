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

		public MainClientMessagingServer() {
			//test connection
			using(var connection = new SqlConnection(Properties.Settings1.Default.connectionString)) {}
		}

		bool Messaging.login(AccountData account) {
			using(
			var connection = new SqlConnection(Properties.Settings1.Default.connectionString)) {
			using(
			var command = new SqlCommand(
				@"
				select cast(case 
					when exists(
						select *
						from [Customers].[Authorization]
						where [Login] = @Login and [Password] = @Password
					)
					then 1 
					else 0 
				end as bit);
				",
				connection
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Login", account.login);
			command.Parameters.AddWithValue("@Password", account.pass);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {

			if(!reader.Read()) throw new InvalidOperationException();
			return (bool) reader[0];

			}}}
		}

		bool Messaging.register(AccountData account, string name, string surname) {
			using(
			var connection = new SqlConnection(Properties.Settings1.Default.connectionString)) {
			using(
			var command = new SqlCommand(
				@"
				begin transaction;

				begin try
					insert into [Customers].[Authorization]([Login], [Password])
					values(@Login, @Password);

					insert into [Customers].[Accounts]([Id], [Name], [Surname])
					values(scope_identity(), @Name, @Surname);

					commit transaction;
					select cast(1 as bit);
				end try
				begin catch
					rollback transaction;
					select cast(0 as bit);
				end catch;
				",
				connection
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Login", account.login);
			command.Parameters.AddWithValue("@Password", account.pass);
			command.Parameters.AddWithValue("@Name", name);
			command.Parameters.AddWithValue("@Surname", surname);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {
			if(!reader.Read()) throw new InvalidOperationException();
			return (bool) reader[0];
			}}}
		}
	}
}
