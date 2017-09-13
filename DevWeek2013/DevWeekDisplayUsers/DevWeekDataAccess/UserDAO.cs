using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevWeekDataAccess
{
    public interface IUserDAO
    {
        IEnumerable<User> GetUsers();
    }
    public class UserDAO : IUserDAO
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>{new User(), new User()};
        }
    }

    public class User
    {
    }
}
