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

		public CriteriaForm(Context context) {
			this.context = context;

			InitializeComponent();

			criteriaTypeCombobox.DataSource = new BindingSource{ DataSource = new CritListMap{ info = context.criteria } };
		}

		private void criteriaTypeCombobox_SelectedIndexChanged(object sender, System.EventArgs e) {
			var type = (Criteria.CriteriumType) System.Enum.GetValues(typeof(Criteria.CriteriumType)).GetValue(criteriaTypeCombobox.SelectedIndex);

			System.Diagnostics.Debug.Assert(System.Enum.GetValues(typeof(ValueType)).Length == 2);
			Control control;
			switch(context.criteria.valueType(type)) {
				case ValueType.amountRub: {
					var c = new NumericUpDown();
					c.ValueChanged += (a, b) => { value = (int) c.Value; };
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
					c.Minimum = 0;
					c.Maximum = int.MaxValue;
					c.Value = 1;

					control = c;
				} break;
				case ValueType.collection: {
					var c = new ComboBox();
					c.SelectedIndexChanged += (a, b) => { value = ((KeyValuePair<int, object>) c.SelectedItem).Key; };
					c.DropDownStyle = ComboBoxStyle.DropDownList;
					c.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
					c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
					c.DataSource = new BindingSource{ DataSource = context.criteria.values(type) };
					c.DisplayMember = "Value";

					control = c;
				}
				break;
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
