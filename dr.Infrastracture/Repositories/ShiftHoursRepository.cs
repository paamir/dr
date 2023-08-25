using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Interfaces;
using dr.Application.Contract.SiftHours;
using dr.Domain.Entities.ShifHours;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture.Repositories
{
    public class ShiftHoursRepository : GenericRepository<ShiftHours>, IShiftHoursRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftHoursRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public List<ShiftHoursViewModel> Search(SiftHoursSearchModel model)
        {
            return _context.ShiftHours.Select(x => new ShiftHoursViewModel()
            {
                EndDate = x.EndDate.ToFarsiFull(),
                StartDate = x.StartDate.ToFarsiFull(),
                IsReserved = x.IsReserved,
                TimeTableId = x.TimeTableId,
            }).ToList();
        }
    }
}
