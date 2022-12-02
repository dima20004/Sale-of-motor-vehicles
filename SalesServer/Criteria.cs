using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Criteria {

	public enum CriteriumType {
		priceFrom, priceTo, brand,
	}

	public enum ValueType {
		amountRub, collection, 
	}

	[Serializable] public sealed class Criterium { 
		public CriteriumType type{ get; }
		public object value{ get; }
		
		public Criterium(CriteriumType type, object value) {
			this.type = type; 
			this.value = value;
		}
	}

	[Serializable] public class CriteriaInfo {

		public CriteriaInfo(Dictionary<int, object> brandValues) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			this.brandValues = brandValues;
		}

		public ValueType valueType(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			switch(type) {
				case CriteriumType.priceFrom: return ValueType.amountRub;
				case CriteriumType.priceTo	: return ValueType.amountRub;
				case CriteriumType.brand	: return ValueType.collection;
				default: throw new NotSupportedException();
			}
		}

		public string valueString(CriteriumType type, object value) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			checkValueCorrect(type, value);

			Debug.Assert(Enum.GetValues(typeof(ValueType)).Length == 2);
			switch(this.valueType(type)) {
				case ValueType.amountRub: return value.ToString(); break;
				case ValueType.collection: return values(type)[(int) value].ToString(); break;
				default: throw new NotSupportedException();
			}
		}

		public string name(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			switch(type) {
				case CriteriumType.priceFrom: return "Цена от, руб.";
				case CriteriumType.priceTo	: return "Цена до, руб.";
				case CriteriumType.brand	: return "Марка";
				default: throw new NotSupportedException();
			}
		}

		public Dictionary<int, object> values(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			switch(type) {
				case CriteriumType.brand: return brandValues;
				default: throw new NotSupportedException();
			}
		}

		public static int importance(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			switch(type) {
				case CriteriumType.priceFrom: return 100;
				case CriteriumType.priceTo	: return 99;
				case CriteriumType.brand	: return 0;
				default: throw new NotSupportedException();
			}
		}

		public Criterium create(CriteriumType type, object value) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			checkValueCorrect(type, value);
			return new Criterium(type, value);
		}

		public void checkValueCorrect(CriteriumType type, object value) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 3);
			Debug.Assert(Enum.GetValues(typeof(ValueType)).Length == 2);

			bool valueCorrect;
			switch(this.valueType(type)) {
				case ValueType.amountRub: 
					valueCorrect = value is int && (int) value >= 0; 
				break;
				case ValueType.collection: 
					valueCorrect = value is int && values(type).ContainsKey((int) value);
				break;
				default: valueCorrect = false; break;
			}
			if(!valueCorrect) throw new NotSupportedException();
		}

		//данные
		private Dictionary<int, object> brandValues;
	}
}
