using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace dr.Application.Contract.Doctor
{
	public interface IDoctorApplication
	{
		OperationResult Create(DoctorCreateModel model);
		OperationResult Edit(DoctorEditModel model);
		OperationResult Active(int id);
		OperationResult DeActive(int id);
		List<DoctorViewModel> Search(DoctorSearchModel model);
        DoctorEditModel GetDetails(int id);
    }
}
