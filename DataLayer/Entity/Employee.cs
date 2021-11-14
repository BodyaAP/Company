using System;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
            SickLeaves = new List<SickLeave>();
            Vacations = new List<Vacation>();
        }

        public virtual Guid Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual ICollection<SickLeave> SickLeaves { get; set; }

        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
