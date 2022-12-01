using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts {
	[Serializable] public struct AccountData {
		public string login, pass;
	}

	public enum ManagementRole {
		user, admin
	}

	[Serializable] public struct Account {
		public string name, surname;
		public ManagementRole role;
	}
}
