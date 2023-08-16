﻿using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser> GetOneUsers(string username);
        Task<UserDtoForUpdate>GetOneUserForUpdate(string username);//Rolleri elde etmek için yazıldı
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task Update(UserDtoForUpdate userDto);
        Task<IdentityResult>ResetPassword(ResetPasswordDto model);
        Task<IdentityResult>DeleteOneUser(string userName);




    }
}
