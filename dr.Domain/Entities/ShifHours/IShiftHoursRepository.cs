using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Application.Contract.SiftHours;

namespace dr.Domain.Entities.ShifHours
{
    public interface IShiftHoursRepository : IGenericRepository<ShiftHours>
    {
        List<ShiftHoursViewModel> Search(SiftHoursSearchModel model);
    }
}
