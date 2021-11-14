using System;

namespace DataLayer.Entity
{
    public class SickLeave
    {
        public SickLeave()
        {
            Id = Guid.NewGuid();
            Employee = new Employee();
        }

        public virtual Guid Id { get; set; }

        public virtual DateTime? Start { get; set; }

        public virtual DateTime? End { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
