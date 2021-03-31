using Project_X_API.DataBase.Tables;
using System.Collections.Generic;
using System.Linq;

namespace Project_X_API.DataBase.Repositories
{
    public class UserDataRepository
    {
        private readonly DataBaseContext _dataBase;

        public UserDataRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void AddUserData(UserData usersData)
        {
            _dataBase.UsersPersonalInfo.Add(usersData);

            _dataBase.SaveChanges();
        }

        public List<UserData> GetAllUsersData()
        {
            return _dataBase.UsersPersonalInfo.ToList();
        }
    }
}