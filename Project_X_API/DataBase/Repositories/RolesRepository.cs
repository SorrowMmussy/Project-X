using System.Collections.Generic;
using System.Linq;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase.Repositories
{
    public class RolesRepository
    {
        private readonly DataBaseContext _dataBase;

        public RolesRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void AddRole(Role newRole)
        {
            _dataBase.Roles.Add(newRole);

            _dataBase.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            //_dataBase.Roles.Find(roleId);

            return _dataBase.Roles.ToList();
        }
    }
}