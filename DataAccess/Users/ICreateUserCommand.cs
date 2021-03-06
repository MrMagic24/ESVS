﻿using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface ICreateUserCommand
    {
        Task<UserResponse> ExecuteAsync(CreateUserRequest request);
    }
}
