using Project_X_API.DataBase.Tables;
using System.Collections.Generic;
using System.Linq;

namespace Project_X_API.DataBase.Repositories
{
    public class UserRepository
    {
        private readonly DataBaseContext _dataBase;

        public UserRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void AddUser(User newUser)
        {
            _dataBase.UsersLoginInfo.Add(newUser);

            _dataBase.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _dataBase.UsersLoginInfo.ToList();
        }
    }
}