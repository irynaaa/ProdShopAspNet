﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IUserRepository:IDisposable
    {
        User Add(User user);
        IQueryable<User> GetAllUsers();
        IQueryable<Role> GetRoles();
        IQueryable<UserRoles> GetUserRoles();
        User GetUserByEmail(string email);
        User GetUserById(int id);
        void SaveChange();
    }
}
