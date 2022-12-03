using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ClientMessaging {

	[Serializable] public struct Statistics {
		public int autosCount;
		public int soldOutCount;
		public int soldOutPriceSum;
		public int discountSum;
	}


	[ServiceContract]
	public interface Messaging {
		[OperationContract] Criteria.CriteriaInfo getCriteria();

		[OperationContract] Statistics getStatistics();

		[OperationContract] bool register(Accounts.AccountData account, string name, string surname);

		[OperationContract] Accounts.Account? login(Accounts.AccountData account);

		[OperationContract] List<Autos.Auto> findAdverts(List<Criteria.Criterium> crits);

		[OperationContract] int addAdvert(Accounts.AccountData data, Autos.Auto auto);

		[OperationContract] void deleteAdvert(Accounts.AccountData data, int id);

		[OperationContract] DateTime buyAdvert(int id, int price);
	}
}
