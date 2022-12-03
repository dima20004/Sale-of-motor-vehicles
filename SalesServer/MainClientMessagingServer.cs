using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

		private Criteria.CriteriaInfo criteriaInfo;

		public MainClientMessagingServer() {
			//test connection
			using(var connection = new SqlConnection(Properties.Settings1.Default.connectionString)) {}

			using(var c = conn) {
			using(
			var command = new SqlCommand(@"select [Id], [Name] from [Auto].[Brands];", c)) {
			command.CommandType = System.Data.CommandType.Text;

			var brands = new Dictionary<int, object>();

			c.Open();
			using(
			var reader = command.ExecuteReader()) {
			while(reader.Read()) brands.Add(reader.GetInt32(0), reader.GetString(1));
			reader.Close();
			command.Dispose();
			c.Dispose();

			criteriaInfo = new Criteria.CriteriaInfo(brands);
			}}}
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
			return criteriaInfo;
		}

		List<Auto> Messaging.findAdverts(List<Criterium> crits) {
			for(int i = 0; i < crits.Count; i++) 
				criteriaInfo.checkValueCorrect(crits[i].type, crits[i].value);

			using(var c = conn) {
			var chs = DBCriteria.makeCheckString(crits, "[Auto].[Automobiles]", "@Param");
			using(
			var command = new SqlCommand(@"
				select
					[Id], [Price], [Brand], [Model],
					[ManufYear], [Trans], [Type],          
					[EngineType], [MileageKm],    
					[SteeringWheel], [EnginePower], 
					[Color], [OwnersCount],
					[AquisitionDate], [Description],
					[Owner], [Image]
				from [Auto].[Automobiles]
				where " + chs.str, 
				c
			)) {
			command.CommandType = System.Data.CommandType.Text;

			for(int i = 0; i < chs.parameters.Count; i++) {
				command.Parameters.AddWithValue("@Param"+i, chs.parameters[i]);
			}

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
				it.owner = reader.GetInt32(15);
				it.image = reader[16] is DBNull ? null : (byte[]) reader[16];
				autos.Add(it);
			}
			return autos;
			}}}
		}

		int Messaging.addAdvert(Accounts.AccountData data, Auto auto) {
			using(var c = conn) {
			using(
			var command = new SqlCommand(@"
				if(@Id is null) begin 
					insert into [Auto].[Automobiles](
						[Price], [Owner], [Brand], [Model],
						[ManufYear], [Trans], [Type],         
						[EngineType], [MileageKm],    
						[SteeringWheel], [EnginePower],  
						[Color], [OwnersCount],
						[AquisitionDate], [Description],
						[Image]
					) values (
						@Price, @Owner, @Brand, @Model, @ManufYear, @Trans, 
						@Type, @EngineType, @MileageKm, @SteeringWheel, @EnginePower, 
						@Color, @OwnersCount, @AquisitionDate, @Description, @Image
					);

					select cast(scope_identity() as int)
				end
				else begin
					update [Auto].[Automobiles]
					set
						[Price] = @Price,
						[Owner] = @Owner,
						[Brand] = @Brand,
						[Model] = @Model,
						[ManufYear] = @ManufYear,
						[Trans] = @Trans,
						[Type] = @Type,
						[EngineType] = @EngineType,
						[MileageKm] = @MileageKm,
						[SteeringWheel] = @SteeringWheel,
						[EnginePower] = @EnginePower,
						[Color] = @Color,
						[OwnersCount] = @OwnersCount,
						[AquisitionDate] = @AquisitionDate,
						[Description] = @Description,
						[Image] = @Image
					where [Id] = @Id

					select cast(case when @@rowcount = 0 then 0 else 1 end as bit); 
				end", 
				c
			)) {
			command.CommandType = System.Data.CommandType.Text;
			command.Parameters.AddWithValue("@Id", auto.id == 0 ? DBNull.Value : (object) auto.id);
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
			command.Parameters.AddWithValue("@AquisitionDate", auto.aquisitionDate);
			command.Parameters.AddWithValue("@Description", auto.description);
			command.Parameters.AddWithValue("@Image", encodeImageDatabase(auto.image));
			var ownerParam = command.Parameters.Add("@Owner", System.Data.SqlDbType.Int);
			

			var autos = new List<Auto>();
			c.Open();

			var accountId = DBAccounts.loginAccountId(conn, data);
			ownerParam.Value = accountId.Value;

			using(var res = command.ExecuteReader()) {
			res.Read();
			if(auto.id != 0) {
				if((bool) res[0]) return auto.id;
				else throw new Exception();
			}
			else {
				return (int) res[0];
			}
			}}}
		}

		private object encodeImageDatabase(byte[] img) {
			if(img == null) return DBNull.Value;
			else using(var s = new MemoryStream(img, false)) { 
			using(var s2 = new MemoryStream()) { 
			System.Drawing.Image.FromStream(s).Save(s2, System.Drawing.Imaging.ImageFormat.Jpeg);
			return s2.ToArray();
			}}
		} 
	}
}
