using System;

namespace BusinessLogicLayer.DTO
{
    public class VacationDTO
    {
        public Guid Id { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}
