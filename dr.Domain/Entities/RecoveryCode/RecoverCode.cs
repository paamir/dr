using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace dr.Domain.Entities.RecoveryCode
{
    public class RecoverCode : EntityBase
    {
        public string Code { get;private set; }
        public DateTime ExpireDate { get;private set; }
        public int UserId { get;private set; }
        public User.User User { get;private set; }
        public RecoverCode(string code, int userId)
        {
            Code = code;
            ExpireDate = DateTime.Now.AddMinutes(2);
            UserId = userId;
        }

        public void Edit(string code)
        {
            Code = code;
            ExpireDate = DateTime.Now.AddMinutes(2);
        } 
}
}
