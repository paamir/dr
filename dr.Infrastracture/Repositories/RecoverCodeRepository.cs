using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework.Interfaces;
using dr.Application;
using dr.Domain.Entities.RecoveryCode;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture.Repositories
{
    public class RecoverCodeRepository : GenericRepository<RecoverCode>, IRecoverCodeRepository
    {
        private readonly ApplicationDbContext _context;
        public RecoverCodeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public RecoverCodeViewModel GetBy(string code)
        {
            return _context.RecoverCodes.Select(x => new RecoverCodeViewModel() {Code = x.Code, ExpireDate = x.ExpireDate, UserId = x.UserId}).FirstOrDefault(x => x.Code == code);
        }
    }
}
