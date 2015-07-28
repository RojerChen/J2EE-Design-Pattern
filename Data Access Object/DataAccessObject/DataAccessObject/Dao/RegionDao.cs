using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessObject.Dao {
    public class RegionDao : DataAccessObject.Dao.IRegionDao {
        
        private string _ConnectString = string.Empty;

        public RegionDao(string ConnectString) {
            _ConnectString = ConnectString;
        }

        public List<Model.RegionModel> GetAll() {
            List<Model.RegionModel> list = new List<Model.RegionModel>();
            using(SqlConnection SqlConn = new SqlConnection(_ConnectString)){
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
    }
}
