using System.Collections;
using System.Collections.Generic;
using _0_Framework.Application;
using dr.Application.Contract.Role;

namespace dr.Application.Contract.User
{
    public interface IUserApplication
    {
        OperationResult Create(UserCreateModel model);
        OperationResult Edit(UserEditModel model);
        List<UserViewModel> Search(UserSearchModel model);
        public OperationResult ChangePassword(UserChangePasswordModel model);
        UserEditModel GetDetails(int id);
        OperationResult Login(UserLoginModel model);
        List<RoleViewModel> GetAllRoles();
        void LogOut();
    }
}
