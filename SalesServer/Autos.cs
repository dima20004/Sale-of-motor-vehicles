using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Autos {
	public class Auto {
		public int id;
		public int owner;
		public int priceRub;
		public int brand;
		public string model;
		public int manufYear;
		public Transmission trans;
		public Type type;
		public EngineType engineType;
		public int mileageKm;
		public StWheel stWheel;
		public int enginePower;
		public Color color;
		public short ownersCount;
		public DateTime aquisitionDate;
		public string description;
		public byte[] image;
	}

	public static class Names {
		public static string typeName(Type it) {
			switch(it) {
				case Autos.Type.sedan: return "седан";
				case Autos.Type.coupe: return "купе";
				case Autos.Type.cabriolet: return "кабриолет";
				case Autos.Type.phaeton: return "фаэтон";
				case Autos.Type.roadster: return "родстер";
				case Autos.Type.lando: return "ландо";
				case Autos.Type.brogham: return "брогам";
				case Autos.Type.pickup: return "пикап";
				case Autos.Type.limousine: return "лимузин";
				case Autos.Type.two_box: return "двухобъемные";
				case Autos.Type.wagon: return "универсал";
				case Autos.Type.hatchback: return "хэтчбек";
				case Autos.Type.liftback: return "лифтбек";
				case Autos.Type.suv: return "внедорожник";
				case Autos.Type.crossover: return "кроссовер";
				case Autos.Type.van: return "фургон";
				case Autos.Type.one_box: return "однообъемный";
				case Autos.Type.minivan: return "минивэн";
				case Autos.Type.compact: return "компактвэн";
				case Autos.Type.mpv: return "микровэн";
				default: throw new InvalidOperationException();
			}
		}

		public static string colorName(Color it) {
			switch(it) {
				case Autos.Color.white: return "белый";
				case Autos.Color.silver: return "серебристый";
				case Autos.Color.gray: return "серый";
				case Autos.Color.black: return "черный";
				case Autos.Color.brown: return "коричневый";
				case Autos.Color.gold: return "золотой";
				case Autos.Color.beige: return "бежевый";
				case Autos.Color.red: return "красный";
				case Autos.Color.maroon: return "бордовый";
				case Autos.Color.orange: return "оранжевый";
				case Autos.Color.yellow: return "желтый";
				case Autos.Color.green: return "зеленый";
				case Autos.Color.cyan: return "голубой";
				case Autos.Color.blue: return "синий";
				case Autos.Color.violet: return "фиолетовый";
				case Autos.Color.purple: return "фиолетовый";
				case Autos.Color.pink: return "розовый"; 
				default: throw new InvalidOperationException();
			}
		}

		public static string TransName(Transmission it) {
			switch(it) {
				case Autos.Transmission.automatic: return "автомат";
				case Autos.Transmission.robot: return "робот";
				case Autos.Transmission.variator: return "вариатор";
				case Autos.Transmission.manual: return "ручная";
				default: throw new InvalidOperationException();
			}
		}

		public static string EngineTypeName(EngineType it) {
			switch(it) {
				case Autos.EngineType.electrical: return "элекрический";
				case Autos.EngineType.gas: return "газ";
				case Autos.EngineType.oil: return "бензин";
				default: throw new InvalidOperationException();
			}
		}

		public static string stWheelName(StWheel it) {
			switch(it) {
				case Autos.StWheel.left: return "левый";
				case Autos.StWheel.right: return "правый";
				default: throw new InvalidOperationException();
			}
		}
	}

	public sealed class EnumCollection<T> : ICollection<string> where T : Enum {
		public delegate string A(T i);

		private A a;

		public EnumCollection(A a) {
			this.a = a;
		}

		public int Count => Enum.GetValues(typeof(T)).Length;
		public bool IsReadOnly => true;
		public void Add(string item) { throw new NotImplementedException(); }
		public void Clear() { throw new NotImplementedException(); }
		public bool Contains(string item) { return true; }
		public void CopyTo(string[] array, int arrayIndex) { throw new NotImplementedException(); }
		public IEnumerator<string> GetEnumerator() { return new AA{ it = this }; }
		public bool Remove(string item) { throw new NotImplementedException(); }
		IEnumerator IEnumerable.GetEnumerator() { return new AA{ it = this }; }

		private class AA : IEnumerator<string> {
			public EnumCollection<T> it;
			int index = -1;

			public string Current => it.a((T) Enum.GetValues(typeof(T)).GetValue(index));
			object IEnumerator.Current => Current;
			public void Dispose() {}
			public bool MoveNext() { index++; return index < it.Count; }
			public void Reset() { index = -1; }
		}
	}

	public enum Type {
		sedan, coupe, cabriolet,
		phaeton, roadster, lando, brogham, 
		pickup, limousine, two_box, wagon,
		hatchback, liftback, suv, crossover, 
		van, one_box, minivan, compact, mpv
	}

	public enum Color {
		white, silver, gray, black, brown,
		gold, beige, red, maroon, orange,
		yellow, green, cyan, blue, violet, 
		purple, pink
	}

	public enum Transmission {
		robot, automatic, variator, manual
	}

	public enum EngineType {
		oil, gas, electrical
	}

	public enum StWheel {
		left, right
	}
}
