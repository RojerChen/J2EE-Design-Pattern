using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessObject.DataSource {
    public class DBHelper : DataAccessObject.DataSource.IDBHelper , IDisposable {
        private string _ConnectString = string.Empty;
        private SqlConnection _SqlConn;

        public DBHelper(string ConnectString) {
            _ConnectString = ConnectString;
            _SqlConn = new SqlConnection(_ConnectString);
        }

        ~DBHelper() {
            Dispose();
        }

        public void Dispose() {
            Close();
            _ConnectString = string.Empty;
        }

        private void Connect() {
            if (_SqlConn.State != ConnectionState.Open)
                _SqlConn.Open();
        }

        private void Close() {
            if (_SqlConn.State != ConnectionState.Closed)
                _SqlConn.Close();
        }

        public SqlDataReader Select(SqlCommand Cmd) {
            Connect();
            Cmd.Connection = _SqlConn;
            SqlDataReader Dr = Cmd.ExecuteReader();
            return Dr;
        }

        public bool Update(SqlCommand Cmd) {
            Connect();
            Cmd.Connection = _SqlConn;
            Cmd.ExecuteNonQuery();
            return true;
        }

  

        

    }
}
