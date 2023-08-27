namespace dr.Application.Contract.SiftHours
{
    public class ShiftHoursViewModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsReserved { get; set; }
        public int TimeTableId { get; set; }
        public string TimeTableName { get; set; }
    }
}