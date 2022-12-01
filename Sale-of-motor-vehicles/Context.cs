using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_of_motor_vehicles {
	public sealed class Context {
		public readonly ClientMessaging.Messaging messaging;
		public readonly Customer customer;

		public readonly Criteria.CriteriaInfo criteria;

		public Context() {
			this.messaging = ClientServerQuery.Create();
			this.customer = new Customer();

			criteria = messaging.getCriteria();
		}
	}
}
