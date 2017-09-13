using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevWeekDataAccess;
using DevWeekService;

namespace DevWeekDisplayUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var userDAO = new UserDAO();
            UserService service = new UserService(userDAO);
            Console.WriteLine(service.GetCountOfUsers());
        }
    }
}
