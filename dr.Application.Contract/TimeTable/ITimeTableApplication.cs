using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace dr.Application.Contract.TimeTable
{
    public interface ITimeTableApplication
    {
        OperationResult Create(TimeTableCreateModel model);
        OperationResult Edit(TimeTableEditModel model);
        List<TimeTableViewModel> Search(TimeTableSearchModel model);
        TimeTableEditModel GetDetails(int id);
        List<TimeTableViewModel> List();
    }
}
