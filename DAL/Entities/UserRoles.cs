using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Таблица не в миграции!!! Этот метод не работает! Такая таблица есть в базе, но она там создалась автоматически после добавления
/// таблиц User и Role. Как вытянуть User_Id, Role_Id?
/// </summary>
namespace DAL.Entities
{
    [Table("dbo.UserRoles")]
    public class UserRoles
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Role_Id { get; set; }

        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
