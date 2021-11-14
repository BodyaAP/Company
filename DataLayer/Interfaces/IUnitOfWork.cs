using DataLayer.Entity;
using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<SickLeave> SickLeaves { get; }
        IRepository<Vacation> Vacations { get; }
    }
}
