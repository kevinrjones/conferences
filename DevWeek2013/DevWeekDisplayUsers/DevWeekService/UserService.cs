using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevWeekDataAccess;

namespace DevWeekService
{
    public class UserService
    {
        IUserDAO _userDao;

        public UserService(IUserDAO userDao)
        {
            _userDao = userDao;
        }

        public int GetCountOfUsers()
        {
            var users = _userDao.GetUsers();
            return users.Count();
        }
    }
}
