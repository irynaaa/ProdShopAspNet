using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
   public class RoleRepository: IRoleRepository
    {

        private readonly IEFContext _context;
        public RoleRepository(IEFContext context)
        {
            _context = context;
        }
        public Role Add(Role role)
        {
            _context.Set<Role>().Add(role);
            return role;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public IQueryable<Role> GetAllRoles()
        {
            return this._context.Set<Role>()/*.Include(c => c.Roles)*/;
        }

        public Role GetRoleById(int id)
        {
            return this.GetAllRoles().SingleOrDefault(r => r.Id == id);
        }

        //public Role GetUserById(int id)
        //{
        //    return this.GetAllRoles()
        //        .SingleOrDefault(c => c.Id == id);
        //}

        //public User GetUserByEmail(string email)
        //{
        //    return this.GetAllRoles()
        //        .SingleOrDefault(c => c.Email == email);
        //}

        public IQueryable<Role> GetRoles()
        {
            return this._context.Set<Role>();
        }

        public IQueryable<UserRoles> GetUserRoles()
        {
            return this._context.Set<UserRoles>();
        }

        public void SaveChange()
        {
            this._context.SaveChanges();
        }

    }
}
