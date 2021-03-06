﻿using System.Threading.Tasks;
using ServiceInterfaces;
using Todo.Models.Users;

namespace Todo.Hubs
{
    public class UserHub : AuthenticatingHub
    {
        private readonly IUserService _userService;

        public UserHub(IUserService userService)
        {
            _userService = userService;
        }

        public Task<UserViewModel> GetUser()
        {
            return Task.Factory.StartNew(() =>
                    {
                        if (IsAuthenticated())
                        {
                            var user = _userService.GetUser();
                            var model = new UserViewModel {Name = user.Name, IsAuthenticated = true};
                            return model;
                        }
                        return null;
                    });
        }
    }
}