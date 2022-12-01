using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdminMessaging {
	[ServiceContract] public interface Messaging {
		[OperationContract] bool updateRole(string login, Accounts.ManagementRole role);
	}
}
