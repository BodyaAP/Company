using System;
using System.Collections.Generic;

namespace WEB.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<SickLeaveViewModel> SickLeaves { get; set; }

        public IList<VacationViewModel> Vacations { get; set; }
    }
}