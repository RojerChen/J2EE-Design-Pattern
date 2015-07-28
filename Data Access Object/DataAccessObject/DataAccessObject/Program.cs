using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject {
    class Program {
        static void Main(string[] args) {

            string ConnectString = "Server =127.0.0.1;Database=northwind;User Id=northwind;Password=northwind;";

            Dao.IRegionDao dao = new Dao.RegionDao(ConnectString);
            List<Model.RegionModel> list = dao.GetAll();
            foreach (var item in list) {
                Console.WriteLine(item.RegionID + ":" + item.RegionDescription);
            }
            Console.WriteLine("End.");
            Console.ReadKey();

        }
    }
}
