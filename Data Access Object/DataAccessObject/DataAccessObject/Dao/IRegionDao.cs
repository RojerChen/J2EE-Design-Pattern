using System;
namespace DataAccessObject.Dao {
    public interface IRegionDao {
        bool Delete(DataAccessObject.Model.RegionModel obj);
        System.Collections.Generic.List<DataAccessObject.Model.RegionModel> GetAll();

        bool Insert(DataAccessObject.Model.RegionModel obj);
        bool Update(DataAccessObject.Model.RegionModel obj);

        System.Collections.Generic.List<DataAccessObject.Model.RegionModel> GetAll2();

        void Dispose();
    }
}
