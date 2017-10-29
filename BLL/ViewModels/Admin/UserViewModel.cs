using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels.Admin
{
    public class UserItemViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoleItemViewModel> Roles { get; set; }
    }
}

public class RoleItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}