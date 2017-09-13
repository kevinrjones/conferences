using Todo.Authentication;

namespace Todo.Models.Users
{
    public class UserViewModel : ITodoIdentity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }

    }
}
