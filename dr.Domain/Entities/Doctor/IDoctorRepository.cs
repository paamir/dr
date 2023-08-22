using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using dr.Application.Contract.Doctor;

namespace dr.Domain.Entities.Doctor
{
	public interface IDoctorRepository : IGenericRepository<Doctor>
	{
		List<DoctorViewModel> Search(DoctorSearchModel model);
        DoctorEditModel GetDetails(int id);
    }
}
