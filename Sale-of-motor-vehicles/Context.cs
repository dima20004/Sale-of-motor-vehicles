using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_of_motor_vehicles {
	public sealed class Context {
		public ClientMessaging.Messaging messaging;
		public Customer customer;

		public Context() {
			this.messaging = ClientServerQuery.Create();
			this.customer = new Customer();
		}
	}
}
