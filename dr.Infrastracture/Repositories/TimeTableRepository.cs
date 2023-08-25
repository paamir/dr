using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Interfaces;
using dr.Application.Contract.SiftHours;
using dr.Application.Contract.TimeTable;
using dr.Domain.Entities.ShifHours;
using dr.Domain.Entities.TimeTable;
using Microsoft.EntityFrameworkCore;

namespace dr.Infrastracture.Repositories
{
    public class TimeTableRepository : GenericRepository<TimeTable> , ITimeTableRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeTableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TimeTableViewModel> Search(TimeTableSearchModel search)
        {
            var query = _dbContext.TimeTables.Select(x => new TimeTableViewModel()
            {
                CreationDate = x.CreationDate.ToPersianDate(),
                Id = x.Id,
                Name = x.Name,
                ItUsed = x.ItUsed
            });
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            return query.ToList();
        }

        public List<TimeTableViewModel> List()
        {
            return _dbContext.TimeTables.Where(x => !x.ItUsed).Select(x => new TimeTableViewModel()
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList() ?? new List<TimeTableViewModel>();
        }

        public TimeTableEditModel GetDetails(int id)
        {
            return _dbContext.TimeTables.Select(x => new TimeTableEditModel()
            {
                Name = x.Name,
                Id = x.Id,
            }).FirstOrDefault(x => x.Id == id) ?? new TimeTableEditModel();
        }
    }
}
