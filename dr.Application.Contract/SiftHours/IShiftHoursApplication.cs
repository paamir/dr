using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace dr.Application.Contract.SiftHours
{
    public interface IShiftHoursApplication
    {
        OperationResult Create(ShiftHoursCreateModel model);
        OperationResult Edit(ShiftHoursEditModel model);
        OperationResult Reserve(int id);
        OperationResult DeReserve(int id);
        List<ShiftHoursViewModel> Search(SiftHoursSearchModel model);
    }
}
