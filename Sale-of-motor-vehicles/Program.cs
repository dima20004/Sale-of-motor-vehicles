using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	 static class Program {
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main() {
			Context context;
			Exception e;
			try{ context = new Context(); e = null; } catch(Exception ex) { context = null; e = ex; }

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FindAuto(context, e));
		}
	}
}
