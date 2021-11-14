using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<SickLeaveDTO> SickLeaves { get; set; }

        public IList<VacationDTO> Vacations { get; set; }
    }
}
