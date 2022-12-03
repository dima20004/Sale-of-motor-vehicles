using System;
using System.Data.SqlClient;
using Accounts;

namespace SalesServer {
	static class DBAccounts {

		public static bool updateRole(ConnectionView connection, string login, ManagementRole role) {
			using(connection) { 
			using(
			var command = new SqlCommand(
				@"
				update [as]
				set [Role] = @Role
				from (
					select * 
					from [Customers].[Authorization] as [an]
					where [an].[Login] = @Login
				) as [an]
				inner join [Customers].[Accounts] as [as]
				on [an].[Id] = [as].[Id];
				
				select cast((case when @@ROWCOUNT = 0 then 0 else 1 end) as bit)",
				connection
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Login", login);
			command.Parameters.AddWithValue("@Role", (int) role);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {

			return reader.Read() && (bool)reader[0];
			}}}
		}

		public static Account? loginAccount(ConnectionView connection, AccountData account) {
			using(connection) { 
			using(
			var command = new SqlCommand(
				@"
				select [Name], [Surname], [Role], [as].[Id]
				from (
					select *
					from [Customers].[Authorization]
					where [Login] = @Login and [Password] = @Password
				) as [ad]

				inner join [Customers].[Accounts] as [as]
				on [ad].[Id] = [as].[Id];",
				connection
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Login", account.login);
			command.Parameters.AddWithValue("@Password", account.pass);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {

			if(!reader.Read()) return null;
			return new Accounts.Account{ 
				name = (string) reader[0],
				surname = (string) reader[1],
				role = (ManagementRole) (int) reader[2],
				id = (int) reader[3],
			};
			}}}
		}

		public static int? loginAccountId(ConnectionView connection, AccountData account) {
			using(connection) { 
			using(
			var command = new SqlCommand(
				@"
				select [as].[Id]
				from (
					select *
					from [Customers].[Authorization]
					where [Login] = @Login and [Password] = @Password
				) as [ad]

				inner join [Customers].[Accounts] as [as]
				on [ad].[Id] = [as].[Id];",
				connection
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Login", account.login);
			command.Parameters.AddWithValue("@Password", account.pass);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {

			if(!reader.Read()) return null;
			return (int) reader[0];
			}}}
		}

		public static bool registerAccount(
			ConnectionView connection, 
			AccountData account, string name, string surname,
			ManagementRole role
		) {
			if(account.login.Length < 1 || account.pass.Length < 8
				|| name.Length < 1 || surname.Length < 1
			) return false;
			using(connection) {
			using(
			var command = new SqlCommand(
				@"
				begin transaction;

				begin try
					insert into [Customers].[Authorization]([Login], [Password])
					values(@Login, @Password);

					insert into [Customers].[Accounts]([Id], [Name], [Surname], [Role])
					values(scope_identity(), @Name, @Surname, @Role);

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
			command.Parameters.AddWithValue("@Role", (int) role);

			connection.Open();
			using(
			var reader = command.ExecuteReader()) {
			if(!reader.Read()) throw new InvalidOperationException();
			return (bool) reader[0];
			}}}
		}
	}
}
