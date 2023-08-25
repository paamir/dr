using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Application.Contract.TimeTable;

namespace dr.Domain.Entities.TimeTable
{
    public interface ITimeTableRepository : IGenericRepository<TimeTable>
    {
        List<TimeTableViewModel> Search(TimeTableSearchModel  search);
        List<TimeTableViewModel> List();
        TimeTableEditModel GetDetails(int id);
    }
}
