using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.Role;
using dr.Application.Contract.User;
using dr.Domain.Entities;
using dr.Domain.Entities.User;

namespace dr.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;

        public UserApplication(IUserRepository userRepository, IAuthHelper authHelper)
        {
            _userRepository = userRepository;
            _authHelper = authHelper;
        }

        public OperationResult Create(UserCreateModel model)
        {
            var result = new OperationResult();
            if (_userRepository.Exist(x => x.Mobile == model.Mobile))
                return result.Failed(OperationMessages.DuplicateUser);
            var hashedPassword = model.Password.ToHash();
            var user = new User(model.Name, model.Mobile, hashedPassword, model.Email, model.RoleId);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return result.Succdded();
        }

        public OperationResult ChangePassword(UserChangePasswordModel model)
        {
            var result = new OperationResult();

            var user = _userRepository.Get(model.Id);
            if (user == null) return result.Failed(OperationMessages.UserNotFound);

            // var hashedOldPassword = model.OldPassword.ToHash();
            // if (hashedOldPassword != user.Password) return result.Failed(OperationMessages.PasswordsNotMatch);

            var hashedNewPassword = model.NewPassword.ToHash();
            user.ChangePassword(hashedNewPassword);
            _userRepository.SaveChanges();
            return result.Succdded();
        }

        public UserEditModel GetDetails(int id)
        {
            return _userRepository.GetDetails(id);
        }

        public OperationResult Login(UserLoginModel model)
        {
            var result = new OperationResult();
            var passwordHash = model.Password.ToHash();
            var user = _userRepository.GetBy(model.Mobile);
            if (user == null || user.Password != passwordHash)
                return result.Failed(OperationMessages.PasswordOrMobileIsNotOk);

            var authViewModel = new AuthViewModel(user.Id, user.RoleId, user.Mobile, user.Name);
            _authHelper.Signin(authViewModel);
            return result.Succdded();
        }

        public List<RoleViewModel> GetAllRoles()
        {
            return _userRepository.GetAllRoles();
        }

        public void LogOut()
        {
            _authHelper.SignOut();
        }

        public OperationResult Edit(UserEditModel model)
        {
            var result = new OperationResult();
            var user = _userRepository.Get(model.Id);

            if (user == null) return result.Failed(OperationMessages.UserNotFound);
            if (_userRepository.Exist(x => x.Mobile == model.Mobile && x.Id != model.Id))
                return result.Failed(OperationMessages.DuplicateUser);

            user.Edit(model.Name, model.Mobile, model.Email, model.RoleId);
            _userRepository.SaveChanges();
            return result.Succdded();
        }

        public List<UserViewModel> Search(UserSearchModel model)
        {
            return _userRepository.Search(model);
        }
    }
}