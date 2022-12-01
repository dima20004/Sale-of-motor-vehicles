using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServer {
	class ConnectionView : IDisposable {
		private SqlConnection conn;
		private bool disposable;

		public ConnectionView(SqlConnection conn) : this(conn, true) {}

		public ConnectionView(SqlConnection conn, bool disposable) {
			this.conn = conn;
			this.disposable = disposable;
		}

		public ConnectionView(ConnectionView cv) : this(cv, true) {}

		public ConnectionView(ConnectionView cv, bool disposable) {
			this.conn = cv;
			this.disposable = cv.disposable && disposable;
		}

		public void Open() {
			if(conn.State != System.Data.ConnectionState.Open) conn.Open();
		}

		public void Close() {
			if(conn.State != System.Data.ConnectionState.Closed) conn.Close();
		}

		public static implicit operator SqlConnection(ConnectionView it) {
			return it.conn;
		}

		public static implicit operator ConnectionView(SqlConnection it) {
			return new ConnectionView(it);
		}

		public void Dispose() {
			if(disposable) conn.Dispose();
		}
	}
}
