using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using dr.Application.Contract.TimeTable;
using dr.Domain.Entities.TimeTable;

namespace dr.Application
{
    public class TimeTableApplication : ITimeTableApplication
    {
        private readonly ITimeTableRepository _timeTableRepository;

        public TimeTableApplication(ITimeTableRepository timeTableRepository)
        {
            _timeTableRepository = timeTableRepository;
        }

        public OperationResult Create(TimeTableCreateModel model)
        {
            var result = new OperationResult();
            if (_timeTableRepository.Exist(x => x.Name == model.Name))
                return result.Failed(OperationMessages.Duplicate);
            var timeTable = new TimeTable(model.Name);
            _timeTableRepository.Create(timeTable);
            _timeTableRepository.SaveChanges();
            return result.Succdded();
        }
        public OperationResult Edit(TimeTableEditModel model)
        {
            var result = new OperationResult();
            var timeTable = _timeTableRepository.Get(model.Id);
            if(_timeTableRepository.Exist(x => x.Id != model.Id && x.Name == model.Name))return result.Failed(OperationMessages.Duplicate);
            timeTable.Edit(model.Name);
            _timeTableRepository.SaveChanges();
            return result.Succdded();
        }

        public List<TimeTableViewModel> Search(TimeTableSearchModel model)
        {
            return _timeTableRepository.Search(model);
        }

        public TimeTableEditModel GetDetails(int id)
        {
            return _timeTableRepository.GetDetails(id);
        }

        public List<TimeTableViewModel> List()
        {
            return _timeTableRepository.List();
        }
    }
}
