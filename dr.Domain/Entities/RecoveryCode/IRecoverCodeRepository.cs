using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Application;

namespace dr.Domain.Entities.RecoveryCode
{
    public interface IRecoverCodeRepository : IGenericRepository<RecoverCode>
    {
        public RecoverCodeViewModel GetBy(string code);
    }
}
