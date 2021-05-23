using Project_X_API.DataBase.Tables;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteExplosivesData(int explosiveDataId)
        {
            var explosive = _dataBase.ExplosiveData.FirstOrDefault(data => data.Id == explosiveDataId);
            _dataBase.ExplosiveData.Remove(explosive);

            _dataBase.SaveChanges();
        }

        public void EditExplosivesData(ExplosiveData explosiveData)
        {
            var explosive = _dataBase.ExplosiveData.FirstOrDefault(data => data.Id == explosiveData.Id);

            _dataBase.Entry(explosive).CurrentValues.SetValues(explosiveData);
            _dataBase.ExplosiveData.Update(explosive);
            _dataBase.SaveChanges();
        }

        public List<ExplosiveData> GetAllExplosivesData()
        {
            return _dataBase.ExplosiveData.ToList();
        }
    }
}