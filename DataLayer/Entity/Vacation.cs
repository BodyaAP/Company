using System;

namespace DataLayer.Entity
{
    public class Vacation
    {
        public Vacation()
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
