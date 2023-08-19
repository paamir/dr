using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Domain.Entities.RecoveryCode;

namespace dr.Domain.Entities.User
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int RoleId { get; private set; }
        public Role.Role Role { get; set; }
        public RecoverCode RecoverCode { get; set; }

        public User(string name, string mobile, string password, string email, int roleId)
        {
            Name = name;
            Mobile = mobile;
            Password = password;
            Email = email;
            RoleId = roleId;
        }

        public void Edit(string name, string mobile, string email, int roleId)
        {
            Name = name;
            Mobile = mobile;
            Email = email;
            if (roleId != 0)
                RoleId = roleId;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
