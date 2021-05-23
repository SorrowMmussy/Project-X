using System.Collections.Generic;
using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.Services
{
    public class ExplosivesDataServices
    {
        private readonly ExplosivesRepository _explosivesRepository;

        public ExplosivesDataServices(ExplosivesRepository explosivesRepository)
        {
            _explosivesRepository = explosivesRepository;
        }

        public void AddExplosivesDataToDataBase(ExplosiveData explosiveData)
        {
            if (explosiveData.Name == null)
            {
                return;
            }

            _explosivesRepository.AddExplosivesData(explosiveData);
        }

        public void DeleteExplosivesDataFromDataBase(int explosiveDataId)
        {
            _explosivesRepository.DeleteExplosivesData(explosiveDataId);
        }

        public void EditExplosivesDataInDataBase(ExplosiveData explosiveData)
        {
            if (explosiveData.Name == null)
            {
                return;
            }

            _explosivesRepository.EditExplosivesData(explosiveData);
        }

        public List<ExplosiveData> GetAllExplosivesDatas()
        {
            return _explosivesRepository.GetAllExplosivesData();
        }
    }
}