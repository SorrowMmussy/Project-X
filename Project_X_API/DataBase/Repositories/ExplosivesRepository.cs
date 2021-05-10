using System.Collections.Generic;
using System.Linq;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase.Repositories
{
    public class ExplosivesRepository
    {
        private readonly DataBaseContext _dataBase;

        public ExplosivesRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void AddExplosivesData(ExplosiveData explosiveData)
        {
            _dataBase.ExplosiveData.Add(explosiveData);

            _dataBase.SaveChanges();
        }

        public List<ExplosiveData> GetAllExplosivesData()
        {
            return _dataBase.ExplosiveData.ToList();
        }
    }
}