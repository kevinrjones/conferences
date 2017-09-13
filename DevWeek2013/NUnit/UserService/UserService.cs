using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        private readonly IDataAccess _data;

        public UserService(IDataAccess data)
        {
            _data = data;
        }

        public UserService() : this(new DataAccess())
        {
        }

        public User Get(int id)
        {
            return _data.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _data.Users();
        }
    }

    public class User
    {
        public int Id { get; set; }
    }


    public interface IDataAccess
    {
        User Get(int id);
        IEnumerable<User> Users();
    }

    public class DataAccess : IDataAccess
    {
        public User Get(int id)
        {
            // hit the database
            return new User { Id = id };
        }

        public IEnumerable<User> Users()
        {
            throw new NotImplementedException();
        }
    }

}
