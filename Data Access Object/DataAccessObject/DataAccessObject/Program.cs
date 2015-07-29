using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
    class Program {

        private static string _ConnectionString = "Server =127.0.0.1;Database=northwind;User Id=northwind;Password=northwind;";

        static void Main(string[] args) {

            RUN();

            Console.WriteLine("End.");
            Console.ReadKey();

        }

        private static void RUN() {
            Dao.IRegionDao dao = new Dao.RegionDao(_ConnectionString);
            List<Model.RegionModel> list;
            /*
            list = dao.GetAll();
            foreach (var item in list) {
                Console.WriteLine(item.RegionID + ":" + item.RegionDescription);
            }
            */

            //insert
            //dao.Insert(new Model.RegionModel(){
            //    RegionID = 5,
            //    RegionDescription = "item5"
            //});

            //update
            //dao.Update(new Model.RegionModel() {
            //    RegionID = 5,
            //    RegionDescription = "new item5"
            //});

            //delete
            //dao.Delete(new Model.RegionModel() {
            //    RegionID = 5,
            //    RegionDescription = "new item5"
            //});



            list = dao.GetAll2();
            foreach (var item in list) {
                Console.WriteLine(item.RegionID + ":" + item.RegionDescription);
            }
            dao.Dispose();
        }
    }
}
