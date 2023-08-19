using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Interfaces;
using dr.Application.Contract.Role;
using dr.Application.Contract.User;
using dr.Domain.Entities.RecoveryCode;
using dr.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserViewModel> Search(UserSearchModel searchModel)
        {
            var query = _dbContext.Users.Select(x => new UserViewModel
            {
                Mobile = x.Mobile,
                Password = x.Password,
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsiFull(),
                RoleId = x.RoleId,
                Role = Roles.GetRoleBy(x.RoleId.ToString())
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
            {
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
            {
                query = query.Where(x => x.Mobile.Contains(searchModel.Email));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }

            return query.ToList();
        }

        public UserEditModel GetDetails(int id)
        {
            return _dbContext.Users.Select(x => new UserEditModel
            {
                Name = x.Name,
                Email = x.Email,
                Id = x.Id,
                Mobile = x.Mobile,
                RoleId = x.RoleId
            }).FirstOrDefault(x => x.Id == id) ?? new UserEditModel();
        }

        public User GetBy(string mobile)
        {
	        return _dbContext.Users.FirstOrDefault(x => x.Mobile == mobile);
        }

        public List<RoleViewModel> GetAllRoles()
        {
	        return _dbContext.Roles.Select(x => new RoleViewModel{Id = x.Id, Name = x.FaName}).ToList();
        }

    }
}