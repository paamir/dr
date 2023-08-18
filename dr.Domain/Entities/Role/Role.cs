using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace dr.Domain.Entities.Role
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public string FaName { get; set; }
        public List<User.User> Users { get; set; }

        public Role(string name, string faName)
        {
            Name = name;
            FaName = faName;
        }

        public void Edit(string name, string faName)
        {
            Name = name;
            FaName = faName;
        }
    }
}
