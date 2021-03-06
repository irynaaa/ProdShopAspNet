﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене")]
        public bool IsRememberMe { get; set; }
    }
    public enum StatusAccountViewModel
    {
        Succes=0,
        Dublication=1,
        Error=2
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public class RoleViewModel
    {
        public RoleViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Name { get; set; }
    }

    public class UserViewModel
    {
        public int Id { get; set; }

        [Required, EmailAddress, Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        public int RoleId { get; set; }

       // [Display(Name = "Role")]
        public Role Role { get; set; }


        /////////
        public IEnumerable<SelectRoleViewModel> Roles { get; set; }
    }


    public class UserRolesViewModel
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Role_Id { get; set; }
    }

}
