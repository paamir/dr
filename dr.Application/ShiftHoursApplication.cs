using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.SiftHours;
using dr.Domain.Entities.ShifHours;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace dr.Application
{
    public class ShiftHoursApplication : IShiftHoursApplication
    {
        private readonly IShiftHoursRepository _repository;

        public ShiftHoursApplication(IShiftHoursRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(ShiftHoursCreateModel model)
        {
            var result = new OperationResult();
            if (_repository.Exist(x => x.TimeTableId == model.TimeTableId &&
                                       ((x.StartDate < model.StartDate && x.EndDate > model.StartDate) ||
                                        (x.StartDate < model.EndDate && x.EndDate > model.EndDate))))
            {
                return result.Failed(OperationMessages.ShiftConflicted);
            }

            var shiftTime = new ShiftHours(model.StartDate, model.EndDate, model.TimeTableId);
            _repository.Create(shiftTime);
            _repository.SaveChanges();
            return result.Succdded();
        }

        public OperationResult Edit(ShiftHoursEditModel model)
        {
            var result = new OperationResult();
            var shiftHours = _repository.Get(model.Id);
            if (shiftHours == null) return result.Failed(OperationMessages.RecordNotFound);
            shiftHours.Edit(model.StartDate, model.EndDate, model.TimeTableId);
            _repository.SaveChanges();
            return result.Succdded();
        }

        public OperationResult Reserve(int id)
        {
            var result = new OperationResult();
            var shiftHours = _repository.Get(id);
            if (shiftHours == null) return result.Failed(OperationMessages.RecordNotFound);
            shiftHours.Reserve();
            _repository.SaveChanges();
            return result.Succdded();
        }

        public OperationResult DeReserve(int id)
        {
            var result = new OperationResult();
            var shiftHours = _repository.Get(id);
            if (shiftHours == null) return result.Failed(OperationMessages.RecordNotFound);
            shiftHours.DeReserve();
            _repository.SaveChanges();
            return result.Succdded();
        }

        public List<ShiftHoursViewModel> Search(SiftHoursSearchModel model)
        {
            return _repository.Search(model);
        }
    }
}
