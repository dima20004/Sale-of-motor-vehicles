using Criteria;
using System.Collections.Generic;

namespace Sale_of_motor_vehicles {
	/*Составляет отсортированный по важности и типу (по убыванию) список критериев*/
	class CriteriaList {
		private List<Criterium> criteriumList;
		private CriteriaInfo criteria;

		public CriteriaList(CriteriaInfo criteria) {
			this.criteriumList = new List<Criterium>();
			this.criteria = criteria;
		}
		public void Add(Criterium it) {
			if(criteriumList.Count == 0) {
				criteriumList.Add(it);
				return;
			}
			var low = 0;
			var high = criteriumList.Count-1;

			while(low <= high) {
				var mid = (low + high) / 2;
				var o = criteriumList[mid];

				if(it.type == o.type) {
					low = mid + 1;
					break;
				}
				
				var itP = CriteriaInfo.importance(it.type);
				var oP  = CriteriaInfo.importance(o .type);

				if(itP < oP || (itP == oP && it.type < o.type)) low = mid + 1;
				else high = mid - 1;
			}

			criteriumList.Insert(low, it);
		}

		public List<Criterium> List{ get{ return criteriumList; } }
	}
}
