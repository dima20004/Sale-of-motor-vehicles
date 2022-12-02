using Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServer {
	static class DBCriteria {
		private static string dbCheck(Criterium crit, string tableName) {
			System.Diagnostics.Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);

			switch(crit.type) {
				case CriteriumType.priceFrom: return tableName + ".[Price] >= " + crit.value;
				case CriteriumType.priceTo	: return tableName + ".[Price] <= " + crit.value;
				case CriteriumType.brand	: return tableName + ".[Brand] = " + crit.value;
				default: throw new NotSupportedException();
			}
		}

		public static string makeCheckString(List<Criterium> crits, string tableName) {
			if(crits.Count == 0) return "(null is null)";

			crits.Sort((f, s) => { 
				if(f.type == s.type) return 0;
				var fi = CriteriaInfo.importance(f.type);
				var si = CriteriaInfo.importance(s.type);
				if(fi - si != 0) return -(fi - si);
				else return -(f.type - s.type);
			});

			var result = new StringBuilder();
			result.Append("(((null is not null)");

			var prevType = crits[0].type;

			for(int i = 0; i < crits.Count; i++) {
				var it = crits[i];

				if(it.type == prevType) result.Append("or");
				else result.Append(")and(");

				result.Append('(').Append(dbCheck(it, tableName)).Append(')');
			}

			result.Append("))");

			return result.ToString();
		}
	}
}
