using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using Autos;
using ClientMessaging;
using Criteria;

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

		List<Auto> Messaging.findAdverts(List<Criterium> crits) {
			using(var c = conn) {
			using(
			var command = new SqlCommand(@"
				select
					[Id], [Price], [Brand], [Model],
					[ManufYear], [Trans], [Type],          
					[EngineType], [MileageKm],    
					[SteeringWheel], [EnginePower], 
					[Color], [OwnersCount],
					[AquisititionDate], [Description]    
				from [Auto].[Automobiles]
				where " + DBCriteria.makeCheckString(crits, "[Auto].[Automobiles]"), 
				c
			)) {
			command.CommandType = System.Data.CommandType.Text;

			var autos = new List<Auto>();
			c.Open();
			using(
			var reader = command.ExecuteReader()) {
			while(reader.Read()) {
				var it = new Auto();
				it.id = reader.GetInt32(0);
				it.priceRub = reader.GetInt32(1);
				it.brand = reader.GetInt32(2);
				it.model = reader.GetString(3);
				it.manufYear = reader.GetInt32(4);
				it.trans = (Transmission) (byte) reader[5];
				it.type = (Autos.Type) (byte) reader[6];
				it.engineType = (EngineType) (byte) reader[7];
				it.mileageKm = reader.GetInt32(8);
				it.stWheel = (StWheel) (byte) reader[9];
				it.enginePower = reader.GetInt32(10);
				it.color = (Color) (byte) reader[11];
				it.ownersCount = (byte) reader[12];
				it.aquisitionDate = (DateTime) reader[13];
				it.description = (string) reader[14];
				autos.Add(it);
			}
			return autos;
			}}}
		}

		int Messaging.addAdvert(Auto auto) {
			using(var c = conn) {
			using(
			var command = new SqlCommand(@"
				insert into [Auto].[Automobiles](
					[Price], [Brand], [Model],
					[ManufYear], [Trans], [Type],         
					[EngineType], [MileageKm],    
					[SteeringWheel], [EnginePower],  
					[Color], [OwnersCount],
					[AquisititionDate], [Description]    
				) values (
					@Price, @Brand, @Model, @ManufYear, @Trans, 
					@Type, @EngineType, @MileageKm, @SteeringWheel, @EnginePower, 
					@Color, @OwnersCount, @AquisititionDate, @Description
				);
				
				select cast(scope_identity() as int)", 
				c
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Price", auto.priceRub);
			command.Parameters.AddWithValue("@Brand", auto.brand);
			command.Parameters.AddWithValue("@Model", auto.model);
			command.Parameters.AddWithValue("@ManufYear", auto.manufYear);
			command.Parameters.AddWithValue("@Trans", auto.trans);
			command.Parameters.AddWithValue("@Type", auto.type);
			command.Parameters.AddWithValue("@EngineType", auto.engineType);
			command.Parameters.AddWithValue("@MileageKm", auto.mileageKm);
			command.Parameters.AddWithValue("@SteeringWheel", auto.stWheel);
			command.Parameters.AddWithValue("@EnginePower", auto.enginePower);
			command.Parameters.AddWithValue("@Color", auto.color);
			command.Parameters.AddWithValue("@OwnersCount", auto.ownersCount);
			command.Parameters.AddWithValue("@AquisititionDate", auto.aquisitionDate);
			command.Parameters.AddWithValue("@Description", auto.description);


			var autos = new List<Auto>();
			c.Open();
			using(var res = command.ExecuteReader()) {
			res.Read();
			return (int) res[0];
			}}}
		}
	}
}
