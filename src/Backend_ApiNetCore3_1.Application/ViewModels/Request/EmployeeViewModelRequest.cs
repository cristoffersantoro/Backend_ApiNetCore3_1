using System;



namespace Backend_ApiNetCore3_1.Application.ViewModels.Request
{

    public class EmployeeViewModelRequest : ViewModelBase
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public string EmployeeName { get; set; }
        public string GenderCode { get; set; }
        public DateTime? HiringDate { get; set; }
        public string DependentsQuantity { get; set; }
        public string SalaryValue { get; set; }

    }

}
