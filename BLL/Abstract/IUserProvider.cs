using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
 public interface IUserProvider
    {
        IEnumerable<SelectRoleViewModel> GetSelectRoles();
        IEnumerable<UserViewModel> GetUsers();

        int DeleteUserRole(int userId, int roleId);
    }
}
