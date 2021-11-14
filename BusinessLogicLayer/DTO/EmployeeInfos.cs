using System;

namespace BusinessLogicLayer.DTO
{
    public class EmployeeInfos
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountSickLeaves { get; set; }

        public int CountVacation { get; set; }
    }
}
