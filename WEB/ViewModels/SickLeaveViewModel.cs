using System;

namespace WEB.ViewModels
{
    public class SickLeaveViewModel
    {
        public Guid Id { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public EmployeeViewModel Employee { get; set; }
    }
}