using System;
using System.Collections.Generic;
using ClientMessaging;

namespace Sale_of_motor_vehicles {

	public sealed class Customer {
		public AccountData? account;

		public Customer() { 
			account = null;
		}
		
		public void unlogin() {
			account = null;
			//здесь можно очистить список объявлений например
		}

		public void updateAccount(AccountData o) {
			unlogin();
			this.account = o;
		}

		public bool LoggedIn{
			get{ return account != null; }
		}
	}
}
