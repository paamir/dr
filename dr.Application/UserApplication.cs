using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using dr.Application.Contract.Recovery;
using dr.Application.Contract.Role;
using dr.Application.Contract.User;
using dr.Domain.Entities;
using dr.Domain.Entities.RecoveryCode;
using dr.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace dr.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IEmailSender _emailSender;
        private readonly IRecoveryCodeApplication _recoveryCodeApplication;
        public UserApplication(IUserRepository userRepository, IAuthHelper authHelper, IEmailSender emailSender, IRecoveryCodeApplication recoveryCodeApplication)
        {
            _userRepository = userRepository;
            _authHelper = authHelper;
            _emailSender = emailSender;
            _recoveryCodeApplication = recoveryCodeApplication;
        }

        public OperationResult Create(UserCreateModel model)
        {
            var result = new OperationResult();
            if (model.PasswordReCheck != model.Password) return result.Failed(ValidationModel.PasswordCompare);
            if (_userRepository.Exist(x => x.Mobile == model.Mobile || x.Email == model.Email))
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
            if (model.PasswordReCheck != model.NewPassword) return result.Failed(ValidationModel.PasswordCompare);
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

        public OperationResult CreateAndSendVerificationCode(string email)
        {
            var result = new OperationResult();
            var account = _userRepository.GetBy(x => x.Email == email);

            if (account == null) return result.Failed(OperationMessages.UserNotFound);
            var code = CodeGenerator.RandomNumberSixDigitNumber();
            var resultCreateRecoveryCode = _recoveryCodeApplication.Create(new RecoveryCreateModel(code, account.Id));
            if (!resultCreateRecoveryCode.IsSuccedded) return resultCreateRecoveryCode; 
            result = _emailSender.SendEmail(email, code);
            return result;
        }

        public OperationResult CheckRecoverCode(string token)
        {
            var result = new OperationResult();
            var recoverCode = _recoveryCodeApplication.GetBy(token);
            if (recoverCode == null)
                return result.Failed(ValidationModel.TokenIsWrong);
            if (recoverCode.ExpireDate < DateTime.Now)
                return result.Failed(ValidationModel.TokenIsWrong);
            return result.Succdded("کد شما تایید شد");
        }

        public int GetUserIdByTokenAndDeleteToken(string token)
        {
	        var Token = _recoveryCodeApplication.GetBy(token);
            if (Token == null) return 0;
            var userId = Token.UserId;
            _recoveryCodeApplication.Delete(token);
            return Token.UserId;
        }

        public int GetUserIdBy(string token)
        {
			var Token = _recoveryCodeApplication.GetBy(token);
			if (Token == null) return 0;
			return Token.UserId;
        }

        public OperationResult CustomerChangePassword(UserChangePasswordModel newPassword)
        {
	        var result = new OperationResult();
	        var recoverCode = _recoveryCodeApplication.GetBy(newPassword.Id);
	        if (recoverCode.ExpireDate > DateTime.Now) return result.Failed(ValidationModel.TokenExpired);
	        return result.Succdded();
        }
    }
}