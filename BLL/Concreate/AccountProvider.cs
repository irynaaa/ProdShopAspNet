using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstract;
using DAL.Entities;
using System.Web.Security;

namespace BLL.Concreate
{
    public class AccountProvider : IAccountProvider
    {
        private readonly IUserRepository _UserRepository;
        public AccountProvider(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public StatusAccountViewModel Login(LoginViewModel model)
        {
            var user = _UserRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var password = crypto.Compute(model.Password, user.PasswordSalt);
                if (password == user.Password)
                {
                    FormsAuthentication
                                .SetAuthCookie(model.Email, model.IsRememberMe);
                    return StatusAccountViewModel.Succes;
                }
            }
            return StatusAccountViewModel.Error;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public StatusAccountViewModel Register(RegisterViewModel model)
        {
            try
            {
                var user = _UserRepository.GetUserByEmail(model.Email);
                if (user != null)
                    return StatusAccountViewModel.Dublication;
                var crypto = new SimpleCrypto.PBKDF2();
                User newUser = new User();
                newUser.Email = model.Email;
                newUser.Password = crypto.Compute(model.Password);
                newUser.PasswordSalt = crypto.Salt;
                _UserRepository.Add(newUser);
                _UserRepository.SaveChange();
            }
            catch
            {
                return StatusAccountViewModel.Error;
            }
            return StatusAccountViewModel.Succes;
        }

        public IEnumerable<string> UserRoles(string email)
        {
            var user = _UserRepository.GetUserByEmail(email);
            //lazy load, select can use because Virtual Roles 
            return user.Roles.Select(r => r.Name);
        }
    }
}

