using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dr.Application.Contract.Recovery
{
    public class RecoveryCreateModel
    {
        public string Code { get; set; }
        public int UserId { get; set; }

        public RecoveryCreateModel(string code, int userId)
        {
            Code = code;
            UserId = userId;
        }
    }
}
