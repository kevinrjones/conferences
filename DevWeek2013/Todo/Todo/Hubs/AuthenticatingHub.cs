using Microsoft.AspNet.SignalR;
using Todo.Authentication;
using Todo.Infrastructure;

namespace Todo.Hubs
{
    public abstract class AuthenticatingHub : Hub
    {
        protected bool IsAuthenticated()
        {
            return UserName != null;
        }

        protected string UserName
        {
            get
            {
                try
                {
                    return ((ITodoIdentity)Context.User.Identity).Name;
                }
                catch
                {
                    throw new NotLoggedInException();
                }
            }
        }
    }
}