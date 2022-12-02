using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ClientMessaging {

	[ServiceContract]
	public interface Messaging {
		[OperationContract] Criteria.CriteriaInfo getCriteria();

		[OperationContract] bool register(Accounts.AccountData account, string name, string surname);

		[OperationContract] Accounts.Account? login(Accounts.AccountData account);

		[OperationContract] List<Autos.Auto> findAdverts(List<Criteria.Criterium> crits);

		[OperationContract] int addAdvert(Autos.Auto auto);
	}
}
