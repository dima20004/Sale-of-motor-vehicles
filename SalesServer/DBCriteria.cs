using Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServer {
	static class DBCriteria {
		private static string dbCheck(CriteriumType crit, string tableName, string paramName) {
			System.Diagnostics.Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);

			var tn = tableName;
			var pn = paramName;

			switch(crit) {
				case CriteriumType.priceFrom:			return tn + ".[Price]>=" + pn;
				case CriteriumType.priceTo:				return tn + ".[Price]<=" + pn;
				case CriteriumType.brand:				return tn + ".[Brand]=" + pn;
				case CriteriumType.model:				return "lower(" + tn + ".[Model]) like concat('%',lower(" + pn + "),'%')";
				case CriteriumType.manufYearFrom:		return tn + ".[ManufYear]>=" + pn;
				case CriteriumType.manufYearTo:			return tn + ".[ManufYear]<=" + pn;
				case CriteriumType.trans:				return tn + ".[Trans]=" + pn;
				case CriteriumType.type:				return tn + ".[Type]=" + pn;
				case CriteriumType.engineType:			return tn + ".[EngineType]=" + pn;
				case CriteriumType.mileageFrom:			return tn + ".[MileageKm]>=" + pn;
				case CriteriumType.mileageTo:			return tn + ".[MileageKm]<=" + pn;
				case CriteriumType.stWheel:				return tn + ".[SteeringWheel]=" + pn;
				case CriteriumType.enginePowerFrom:		return tn + ".[EnginePower]>=" + pn;
				case CriteriumType.enginePowerTo:		return tn + ".[EnginePower]<=" + pn;
				case CriteriumType.color:				return tn + ".[Color]=" + pn;
				case CriteriumType.ownersCountFrom:		return tn + ".[OwnersCount]>=" + pn;
				case CriteriumType.ownersCountTo:		return tn + ".[OwnersCount]<=" + pn;
				case CriteriumType.aquisitionDateFrom:	return tn + ".[AquisitionDate]>=" + pn;
				case CriteriumType.aquisitionDateTo:	return tn + ".[AquisitionDate]" + pn;
				default: throw new NotSupportedException();
			}
		}

		public struct CheckString {
			public string str;
			public List<object> parameters;
		}

		public static CheckString makeCheckString(List<Criterium> criteriumList, string tableName, string paramName) {
			if(criteriumList.Count == 0) return new CheckString{ str ="(null is null)", parameters = new List<object>(0) };

			var parameters = new List<object>(criteriumList.Count);

			var crits = new List<Criterium>(criteriumList);
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

				prevType = it.type;

				result.Append('(').Append(dbCheck(it.type, tableName, paramName + i)).Append(')');
				parameters.Add(it.value);
			}

			result.Append("))");

			return new CheckString{ str = result.ToString(), parameters = parameters };
		}
	}
}
