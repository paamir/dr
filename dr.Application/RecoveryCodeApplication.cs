using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.Recovery;
using dr.Domain.Entities.RecoveryCode;

namespace dr.Application
{
    public class RecoveryCodeApplication : IRecoveryCodeApplication
    {
        private readonly IRecoverCodeRepository _recoverCodeRepository;

        public RecoveryCodeApplication(IRecoverCodeRepository recoverCodeRepository)
        {
            _recoverCodeRepository = recoverCodeRepository;
        }

        public OperationResult Create(RecoveryCreateModel model)
        {
            var result = new OperationResult();
            var recoveryCode = _recoverCodeRepository.GetBy(x => x.UserId == model.UserId);
            if (recoveryCode == null)
            {
                 recoveryCode = new RecoverCode(model.Code, model.UserId);
                _recoverCodeRepository.Create(recoveryCode);
                _recoverCodeRepository.SaveChanges();
                return result.Succdded();
            }
            //this add 10 minutes is for we added 10 min in database for change password
            if (recoveryCode.ExpireDate > DateTime.Now.AddMinutes(10))
                return result.Failed(ValidationModel.TokenNotExpire);

            recoveryCode.Edit(model.Code);
            _recoverCodeRepository.SaveChanges();
            return result.Succdded();
        }

        public RecoverCodeViewModel GetBy(string code)
        {
            return _recoverCodeRepository.GetBy(code);
        }

        public void Delete(string token)
        {
	        _recoverCodeRepository.Delete(token);
        }

        public RecoverCodeViewModel GetBy(int Id)
        {
	        var recoverCode = _recoverCodeRepository.GetBy(x => x.UserId == Id);
	        return new RecoverCodeViewModel()
	        {
                UserId = recoverCode.UserId,
                Code = recoverCode.Code,
                ExpireDate = recoverCode.ExpireDate,
	        };
        }
    }
}
