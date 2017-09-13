using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DfTModel
{
    public interface IApplication
    {
        int Run();
    }

    public class Application : IApplication
    {
        private readonly IUserDao _dao;


        public Application(IUserDao dao)
        {
            _dao = dao;
        }

        public int Run()
        {
            int count = _dao.GetCountOfUsers();
            if (count == 0)
            {
                throw new Exception("No users");
            }
            return count;
        }
    }


    public interface IUserDao
    {
        int GetCountOfUsers();
    }

    public class UserDao : IUserDao
    {
        public int GetCountOfUsers()
        {
            return 23;
        }
    }
}
