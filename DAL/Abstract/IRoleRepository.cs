using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   
        public interface IRoleRepository : IDisposable
        {
            Role Add(Role user);
            IQueryable<Role> GetAllRoles();
            IQueryable<Role> GetRoles();
          //  IQueryable<UserRoles> GetUserRoles();
            Role GetRoleById(int id);
           
            void SaveChange();
        }
    }

