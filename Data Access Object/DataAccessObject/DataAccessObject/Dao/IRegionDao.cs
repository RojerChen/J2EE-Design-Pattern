using System;
namespace DataAccessObject.Dao {
    public interface IRegionDao {
        System.Collections.Generic.List<DataAccessObject.Model.RegionModel> GetAll();
    }
}
