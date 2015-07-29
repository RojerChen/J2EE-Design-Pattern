using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessObject.Dao {
    public class RegionDao : DataAccessObject.Dao.IRegionDao,IDisposable  {
        
        private string _ConnectString = string.Empty;
        private DataSource.IDBHelper _DBHelper;

        public RegionDao(string ConnectString) {
            _ConnectString = ConnectString;
            _DBHelper = new DataSource.DBHelper(_ConnectString);
        }

        ~RegionDao() {
            Dispose();
        }


        public void Dispose() {
            _DBHelper.Dispose();
            _ConnectString = string.Empty;
        }

        #region "Data Access Object Pattern V1"

        public List<Model.RegionModel> GetAll() {
            List<Model.RegionModel> list = new List<Model.RegionModel>();
            using (SqlConnection SqlConn = new SqlConnection(_ConnectString)) {
                SqlConn.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = SqlConn;
                Cmd.CommandText = "select * from Region";
                SqlDataReader Dr = Cmd.ExecuteReader();
                while (Dr.Read()) {
                    list.Add(new Model.RegionModel() {
                        RegionID = Convert.ToInt32(Dr["RegionID"].ToString()),
                        RegionDescription = Dr["RegionDescription"].ToString()
                    });
                }
                Dr.Close();
            }
            return list;
        }

        public bool Insert(Model.RegionModel obj) {
            bool flag = false;

            using (SqlConnection SqlConn = new SqlConnection(_ConnectString)) {
                SqlConn.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = SqlConn;
                Cmd.CommandText = "insert into Region(RegionID,RegionDescription) values(@RegionID,@RegionDescription)";
                Cmd.Parameters.Add("@RegionID", obj.RegionID);
                Cmd.Parameters.Add("@RegionDescription", obj.RegionDescription);
                Cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool Update(Model.RegionModel obj) {
            bool flag = false;

            using (SqlConnection SqlConn = new SqlConnection(_ConnectString)) {
                SqlConn.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = SqlConn;
                Cmd.CommandText = "update Region set RegionDescription=@RegionDescription where RegionID=@RegionID";
                Cmd.Parameters.Add("@RegionID", obj.RegionID);
                Cmd.Parameters.Add("@RegionDescription", obj.RegionDescription);
                Cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool Delete(Model.RegionModel obj) {
            bool flag = false;

            using (SqlConnection SqlConn = new SqlConnection(_ConnectString)) {
                SqlConn.Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = SqlConn;
                Cmd.CommandText = "delete from Region where RegionID=@RegionID";
                Cmd.Parameters.Add("@RegionID", obj.RegionID);
                Cmd.ExecuteNonQuery();
            }
            return true;
        }

        #endregion

        public List<Model.RegionModel> GetAll2() {
            List<Model.RegionModel> list = new List<Model.RegionModel>();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = "select * from Region";
            SqlDataReader Dr = _DBHelper.Select(Cmd);
            while (Dr.Read()) {
                list.Add(new Model.RegionModel() {
                    RegionID = Convert.ToInt32(Dr["RegionID"].ToString()),
                    RegionDescription = Dr["RegionDescription"].ToString()
                });
            }
            Dr.Close();
            return list;
        }
    }
}
