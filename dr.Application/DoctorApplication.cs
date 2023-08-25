using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.Doctor;
using dr.Domain.Entities.Doctor;

namespace dr.Application
{
	public class DoctorApplication : IDoctorApplication
	{
		private readonly IDoctorRepository _repository;

		public DoctorApplication(IDoctorRepository repository)
		{
			_repository = repository;
		}

		public OperationResult Create(DoctorCreateModel model)
		{
			var result = new OperationResult();
            if (_repository.Exist(x => x.TimeTableId == model.TimeTableId))
                return result.Failed(OperationMessages.TimeTableCantDuplicate);
			if (_repository.Exist(x => x.Name == model.Name && x.Skill == model.Skill))
				return result.Failed(OperationMessages.Duplicate);
			var doctor = new Doctor(model.Name, model.Skill, model.Description, model.TimeTableId);
			_repository.Create(doctor);
			_repository.SaveChanges();
			return result.Succdded();
		}

		public OperationResult Edit(DoctorEditModel model)
		{
			var result = new OperationResult();
			var doctor = _repository.Get(model.Id);
			if (doctor == null) return result.Failed(OperationMessages.RecordNotFound);
            if (_repository.Exist(x => x.TimeTableId == model.TimeTableId && model.Id != x.Id))
                return result.Failed(OperationMessages.TimeTableCantDuplicate);
            if (_repository.Exist(x => x.Skill == model.Skill && x.Name == model.Name && x.Id != model.Id)) return result.Failed(OperationMessages.Duplicate);
			doctor.Edit(model.Name, model.Skill, model.Description);
			_repository.SaveChanges();
			return result.Succdded();
		}

		public OperationResult Active(int id)
		{
			var result = new OperationResult();
			var doctor = _repository.Get(id);
			if (doctor == null) return result.Failed(OperationMessages.Duplicate);
			doctor.Active();
			_repository.SaveChanges();
			return result.Succdded();
		}

		public OperationResult DeActive(int id)
		{
			var result = new OperationResult();
			var doctor = _repository.Get(id);
			if (doctor == null) return result.Failed(OperationMessages.Duplicate);
			doctor.DeActive();
			_repository.SaveChanges();
			return result.Succdded();
		}

		public List<DoctorViewModel> Search(DoctorSearchModel model)
		{
			return _repository.Search(model);
		}

        public DoctorEditModel GetDetails(int id)
        {
            return _repository.GetDetails(id);
        }
    }
}
