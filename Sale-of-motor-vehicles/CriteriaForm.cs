using Criteria;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	public partial class CriteriaForm : Form {
		private Context context;

		public Criteria.Criterium criterium{ get; private set; }

		private object value;

		private struct CritName {
			public CriteriumType type;
			public CriteriaInfo info;

			public override string ToString() { return info.name(type); }
		}

		private sealed class CritListMap : ICollection<CritName> {
			public CriteriaInfo info;
			public CritName this[int i] { get{ return new CritName{
				type = (CriteriumType) System.Enum.GetValues(typeof(CriteriumType)).GetValue(i),
				info = info,
			}; } }

			public int Count => System.Enum.GetValues(typeof(CriteriumType)).Length;
			public bool IsReadOnly => true;
			public void Add(CritName item) { throw new System.NotImplementedException(); }
			public void Clear() { throw new System.NotImplementedException(); }
			public bool Contains(CritName item) { return true; }
			public void CopyTo(CritName[] array, int arrayIndex) { throw new System.NotImplementedException(); }
			public IEnumerator<CritName> GetEnumerator() { return new AA{ it = this }; }
			public bool Remove(CritName item) { throw new System.NotImplementedException(); }
			IEnumerator IEnumerable.GetEnumerator() { return new AA{ it = this }; }

			private class AA : IEnumerator<CritName> {
				public CritListMap it;
				int index = -1;

				public CritName Current => it[index];
				object IEnumerator.Current => it[index];
				public void Dispose() {}
				public bool MoveNext() { index++; return index < it.Count; }
				public void Reset() { index = -1; }
			}
		}

		public CriteriaForm(Context context, Criterium crit) {
			this.context = context;

			InitializeComponent();

			criteriaTypeCombobox.DataSource = new BindingSource{ DataSource = new CritListMap{ info = context.criteria } };

			if(crit != null) {
				var list = System.Enum.GetValues(typeof(CriteriumType));
				var i = 0;
				for(; i < list.Length; i++) {
					if((CriteriumType) list.GetValue(i) == crit.type) break;
				}
				criteriaTypeCombobox.SelectedIndex = i;
				value = crit.value;
				updateValue();
			}
		}

		private void criteriaTypeCombobox_SelectedIndexChanged(object sender, System.EventArgs e) {
			value = null;

			updateValue();
		}

		private void updateValue() {
			var type = (Criteria.CriteriumType) System.Enum.GetValues(typeof(Criteria.CriteriumType)).GetValue(criteriaTypeCombobox.SelectedIndex);
			
			System.Diagnostics.Debug.Assert(System.Enum.GetValues(typeof(ValueType)).Length == 7);
			Control control;
			switch(context.criteria.valueType(type)) {
				case ValueType.amountRub: {
					var c = new NumericUpDown();
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
					c.Minimum = 0;
					c.Maximum = int.MaxValue;
					c.Value = 1;

					if(value != null) c.Value = (int) value;
					c.ValueChanged += (a, b) => { value = (int) c.Value; };
					value = (int) c.Value;

					control = c;
				} break;
				case ValueType.collection: {
					var c = new ComboBox();
					c.DropDownStyle = ComboBoxStyle.DropDownList;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
					//https://stackoverflow.com/a/36053487/18704284
					c.BindingContext = this.BindingContext;
					var source = context.criteria.valuesNames(type);
					c.DataSource = new BindingSource{ DataSource = source };
					c.DisplayMember = "Value";

					var index = 0;
					if(value != null) {
						foreach(var pair in source) if(pair.Key == (int) value) break;
						else index++;
					}
					c.SelectedIndex = index;
					c.SelectedIndexChanged += (a, b) => { value = ((KeyValuePair<int, string>) c.SelectedItem).Key; };
					value = ((KeyValuePair<int, string>) c.SelectedItem).Key;

					control = c;
				} break;
				case ValueType.str: {
					var c = new TextBox();
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;

					if(value != null) c.Text = value.ToString();
					c.TextChanged += (a, b) => { value = c.Text; };
					value = c.Text;

					control = c;
				} break;
				case ValueType.year: {
					var c = new NumericUpDown();
					c.Minimum = 1900;
					c.Maximum = 3000;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;

					if(value != null) c.Value = (int) value;
					c.ValueChanged += (a, b) => { value = (int) c.Value; };
					value = (int) c.Value;

					control = c;
				} break;
				case ValueType.date: {
					var c = new DateTimePicker();
					c.Format = DateTimePickerFormat.Short;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;

					if(value != null) c.Value = (System.DateTime) value;
					c.ValueChanged += (a, b) => { value = c.Value; };
					value = c.Value;

					control = c;
				} break;
				case ValueType.count: {
					var c = new NumericUpDown();
					c.Minimum = 0;
					c.Maximum = 999999;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;

					if(value != null) c.Value = (int) value;
					c.ValueChanged += (a, b) => { value = (int) c.Value; };
					value = (int) c.Value;

					control = c;
				} break;
				case ValueType.boolean: {
					var c = new ComboBox();
					c.DropDownStyle = ComboBoxStyle.DropDownList;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
					//https://stackoverflow.com/a/36053487/18704284
					c.BindingContext = this.BindingContext;
					c.DataSource = new BindingSource{ DataSource = new List<string>(2){"Нет", "Да"} };

					if(value != null) c.SelectedIndex = (bool) value ? 1 : 0;
					else c.SelectedIndex = 0;
					c.SelectedIndexChanged += (a, b) => { value = c.SelectedIndex == 1; };
					value = c.SelectedIndex == 1;

					control = c;
				} break;
				default: throw new System.InvalidOperationException(); break;
			}

			criteriaTable.SuspendLayout();
			criteriaTable.Controls.Clear();
			criteriaTable.Controls.Add(control);
			criteriaTable.ResumeLayout(false);
			criteriaTable.PerformLayout();
		}

		private void addCriteriaButton_Click(object sender, System.EventArgs e) {
			criterium = context.criteria.create(
				(Criteria.CriteriumType) System.Enum.GetValues(typeof(Criteria.CriteriumType)).GetValue(criteriaTypeCombobox.SelectedIndex),
				value
			);
			DialogResult = DialogResult.OK;
		}
	}
}
