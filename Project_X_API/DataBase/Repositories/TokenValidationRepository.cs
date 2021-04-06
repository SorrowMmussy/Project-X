using Project_X_API.DataBase.Tables;
using System.Collections.Generic;
using System.Linq;

namespace Project_X_API.DataBase.Repositories
{
    public class TokenValidationRepository
    {
        private readonly DataBaseContext _dataBase;

        public TokenValidationRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void AddEmailVerification(TokenValidation newEmailVerification)
        {
            _dataBase.TokenValidations.Add(newEmailVerification);

            _dataBase.SaveChanges();
        }

        public List<TokenValidation> GetAllEmailRegistrations()
        {
            //_dataBase.Roles.Find(roleId);

            return _dataBase.TokenValidations.ToList();
        }
    }
}