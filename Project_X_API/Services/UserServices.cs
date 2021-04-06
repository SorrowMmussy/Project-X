using Project_X_API.DataBase.Repositories;
using Project_X_API.DataBase.Tables;
using System.Collections.Generic;

namespace Project_X_API.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUserToDataBase(User user)
        {
            if (user.Username == null)
            {
                return;
            }

            _userRepository.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}