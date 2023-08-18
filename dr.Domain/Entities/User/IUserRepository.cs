using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Domain;
using dr.Application.Contract.Role;
using dr.Application.Contract.User;

namespace dr.Domain.Entities.User
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<UserViewModel> Search(UserSearchModel model);
        UserEditModel GetDetails(int id);
        User GetBy(string mobile);
        List<RoleViewModel> GetAllRoles();
    }
}
