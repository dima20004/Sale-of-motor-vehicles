using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ClientMessaging {

	[Serializable] public struct AccountData {
		public string login, pass;
	}

	[ServiceContract]
	public interface Messaging {
		[OperationContract] bool register(AccountData account, string name, string surname);

		[OperationContract] bool login(AccountData account);
	}
}
