using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace dr.Application.Contract.Recovery
{
    public interface IRecoveryCodeApplication
    {
        public OperationResult Create(RecoveryCreateModel model);
        public RecoverCodeViewModel GetBy(string token);
        public void Delete(string token);
        public RecoverCodeViewModel GetBy(int UserId);
    }
}
