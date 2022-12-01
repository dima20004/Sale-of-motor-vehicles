using System;
using System.Collections.Generic;
using Accounts;
using ClientMessaging;

namespace Sale_of_motor_vehicles {

	public sealed class Customer {
		public AccountData accountData;
		public Account? account;
		public Customer() { 
			accountData = new AccountData();
			account = null;
		}
		
		public void logOut() {
			accountData = new AccountData();
			account = null;
			//здесь можно очистить список объявлений например
		}

		public void logIn(AccountData data, Account o) {
			logOut();
			this.accountData = data;
			this.account = o;
		}

		public bool LoggedIn{
			get{ return account != null; }
		}
	}
}
