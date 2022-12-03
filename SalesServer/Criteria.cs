using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;

namespace Criteria {

	public enum CriteriumType {
		priceFrom, priceTo, 
		brand,
		model, 
		manufYearFrom, manufYearTo,
		trans,
		type,
		engineType,
		mileageFrom, mileageTo,
		stWheel,
		enginePowerFrom, enginePowerTo,
		color,
		ownersCountFrom, ownersCountTo,
		aquisitionDateFrom, aquisitionDateTo,
	}

	public enum ValueType {
		amountRub, collection, str,
		year, date, count, 
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
		private Dictionary<int, object> brandValues;

		public CriteriaInfo(
			Dictionary<int, object> brandValues
		) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			this.brandValues = brandValues;
		}

		public ValueType valueType(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			switch(type) {
				case CriteriumType.priceFrom:			return ValueType.amountRub;
				case CriteriumType.priceTo:				return ValueType.amountRub;
				case CriteriumType.brand:				return ValueType.collection;
				case CriteriumType.model:				return ValueType.str;
				case CriteriumType.manufYearFrom:		return ValueType.year;
				case CriteriumType.manufYearTo:			return ValueType.year;
				case CriteriumType.trans:				return ValueType.collection;
				case CriteriumType.type:				return ValueType.collection;
				case CriteriumType.engineType:			return ValueType.collection;
				case CriteriumType.mileageFrom:			return ValueType.count;
				case CriteriumType.mileageTo:			return ValueType.count;
				case CriteriumType.stWheel:				return ValueType.collection;
				case CriteriumType.enginePowerFrom:		return ValueType.count;
				case CriteriumType.enginePowerTo:		return ValueType.count;
				case CriteriumType.color:				return ValueType.collection;
				case CriteriumType.ownersCountFrom:		return ValueType.count;
				case CriteriumType.ownersCountTo:		return ValueType.count;
				case CriteriumType.aquisitionDateFrom:	return ValueType.date;
				case CriteriumType.aquisitionDateTo:	return ValueType.date;
				default: throw new NotSupportedException();
			}
		}

		public string valueString(CriteriumType type, object value) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			checkValueCorrect(type, value);

			Debug.Assert(Enum.GetValues(typeof(ValueType)).Length == 6);
			switch(this.valueType(type)) {
				case ValueType.amountRub: return value.ToString();
				case ValueType.collection: {
					var it = (int) value;
					switch(type) {
						case CriteriumType.brand		: return brandValues[it].ToString();
						case CriteriumType.trans		: return Autos.Names.TransName((Autos.Transmission) Enum.GetValues(typeof(Autos.Transmission)).GetValue(it));
						case CriteriumType.type			: return Autos.Names.typeName((Autos.Type) Enum.GetValues(typeof(Autos.Type)).GetValue(it));
						case CriteriumType.engineType	: return Autos.Names.EngineTypeName((Autos.EngineType) Enum.GetValues(typeof(Autos.EngineType)).GetValue(it));
						case CriteriumType.stWheel		: return Autos.Names.stWheelName((Autos.StWheel) Enum.GetValues(typeof(Autos.StWheel)).GetValue(it));
						case CriteriumType.color		: return Autos.Names.colorName((Autos.Color) Enum.GetValues(typeof(Autos.Color)).GetValue(it));
						default: throw new NotSupportedException();
					}
				} 
				case ValueType.str:   return value.ToString();
				case ValueType.year:  return value.ToString() + "г.";
				case ValueType.date:  return ((DateTime) value).ToString("d");
				case ValueType.count: return value.ToString();
				default: throw new NotSupportedException();
			}
		}

		public string name(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			switch(type) {
				case CriteriumType.priceFrom:			return "Цена от, руб.";
				case CriteriumType.priceTo:				return "Цена до, руб.";
				case CriteriumType.brand:				return "Марка";
				case CriteriumType.model:				return "Модель";
				case CriteriumType.manufYearFrom:		return "Год выпуска от";
				case CriteriumType.manufYearTo:			return "Год выпуска до";
				case CriteriumType.trans:				return "КПП";
				case CriteriumType.type:				return "Тип кузова";
				case CriteriumType.engineType:			return "Тип двигателя";
				case CriteriumType.mileageFrom:			return "Пробег от, км.";
				case CriteriumType.mileageTo:			return "Пробег до, км.";
				case CriteriumType.stWheel:				return "Руль";
				case CriteriumType.enginePowerFrom:		return "Мощность двиателя от, л.с.";
				case CriteriumType.enginePowerTo:		return "Мощность двигателя до, л.с.";
				case CriteriumType.color:				return "Цвет";
				case CriteriumType.ownersCountFrom:		return "Количество владельцев от";
				case CriteriumType.ownersCountTo:		return "Количество владельцев до";
				case CriteriumType.aquisitionDateFrom:	return "Дата приобретения от";
				case CriteriumType.aquisitionDateTo:	return "Дата приобретения до";
				default: throw new NotSupportedException();
			}
		}

		private static Dictionary<int, object> enumDictionary<T>() where T: Enum {
			var vals = Enum.GetValues(typeof(T));
			var res = new Dictionary<int, object>(vals.Length);
			for(int i = 0; i <vals.Length; i++) {
				var it = vals.GetValue(i);
				res.Add((int) it, it);
			}
			return res;
		}

		public Dictionary<int, object> values(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			switch(type) {
				case CriteriumType.brand		: return brandValues;
				case CriteriumType.trans		: return enumDictionary<Autos.Transmission>();
				case CriteriumType.type			: return enumDictionary<Autos.Type>();
				case CriteriumType.engineType	: return enumDictionary<Autos.EngineType>();
				case CriteriumType.stWheel		: return enumDictionary<Autos.StWheel>();
				case CriteriumType.color		: return enumDictionary<Autos.Color>();
				default: throw new NotSupportedException();
			}
		}

		private delegate string A<T>(T i);

		private Dictionary<int, string> names<T>(A<T> a) where T: Enum {
			var values = Enum.GetValues(typeof(T));
			var nd = new Dictionary<int, string>(values.Length);
			for(int i = 0; i < values.Length; i++) {
				var it = values.GetValue(i);
				nd.Add((int) it, a((T) it));
			}
			return nd;
		}

		public Dictionary<int, string> valuesNames(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			switch(type) {
				case CriteriumType.brand		: {
					var nd = new Dictionary<int, string>(brandValues.Count);
					foreach(var pair in brandValues) nd.Add(pair.Key, pair.Value.ToString());
					return nd;
				}
				case CriteriumType.trans		: return names<Autos.Transmission>((i) => Autos.Names.TransName(i));
				case CriteriumType.type			: return names<Autos.Type>((i) => Autos.Names.typeName(i));
				case CriteriumType.engineType	: return names<Autos.EngineType>((i) => Autos.Names.EngineTypeName(i));
				case CriteriumType.stWheel		: return names<Autos.StWheel>((i) => Autos.Names.stWheelName(i));
				case CriteriumType.color		: return names<Autos.Color>((i) => Autos.Names.colorName(i));
				default: throw new NotSupportedException();
			}
		}

		public static int importance(CriteriumType type) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			switch(type) {
				case CriteriumType.priceFrom: return 100;
				case CriteriumType.priceTo	: return 99;
				case CriteriumType.brand	: return 80;
				case CriteriumType.model:				return 70;
				case CriteriumType.manufYearFrom:		return 61;
				case CriteriumType.manufYearTo:			return 60;
				case CriteriumType.trans:				return 40;
				case CriteriumType.type:				return 90;
				case CriteriumType.engineType:			return 85;
				case CriteriumType.mileageFrom:			return 82;
				case CriteriumType.mileageTo:			return 81;
				case CriteriumType.stWheel:				return 50;
				case CriteriumType.enginePowerFrom:		return 64;
				case CriteriumType.enginePowerTo:		return 63;
				case CriteriumType.color:				return 55;
				case CriteriumType.ownersCountFrom:		return 31;
				case CriteriumType.ownersCountTo:		return 30;
				case CriteriumType.aquisitionDateFrom:	return 21;
				case CriteriumType.aquisitionDateTo:	return 20;
				default: throw new NotSupportedException();
			}
		}

		public Criterium create(CriteriumType type, object value) {
			checkValueCorrect(type, value);
			return new Criterium(type, value);
		}

		public void checkValueCorrect(CriteriumType type, object value) {
			Debug.Assert(Enum.GetValues(typeof(CriteriumType)).Length == 19);
			Debug.Assert(Enum.GetValues(typeof(ValueType)).Length == 6);

			bool valueCorrect;
			switch(this.valueType(type)) {
				case ValueType.amountRub: { 
					valueCorrect = value is int && (int) value >= 0; 
				} break;
				case ValueType.collection: {
					valueCorrect = value is int && values(type).ContainsKey((int) value);
				} break;
				case ValueType.str: {
					valueCorrect = value is string && ((string) value).Length < 128;
				} break;
				case ValueType.year: {
					valueCorrect = value is int && (int)value >= 1900 && (int)value <= 3000;
				} break;
				case ValueType.date: {
					valueCorrect = value is DateTime;
				} break;
				case ValueType.count: {
					valueCorrect = value is int && (int)value >= 0;
				} break;
				default: valueCorrect = false; break;
			}
			if(!valueCorrect) throw new NotSupportedException();
		}
	}
}
