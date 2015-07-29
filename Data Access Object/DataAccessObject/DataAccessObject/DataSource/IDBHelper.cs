using System;
namespace DataAccessObject.DataSource {
    interface IDBHelper {
        System.Data.SqlClient.SqlDataReader Select(System.Data.SqlClient.SqlCommand Cmd);
        bool Update(System.Data.SqlClient.SqlCommand Cmd);

        void Dispose();
    }
}
