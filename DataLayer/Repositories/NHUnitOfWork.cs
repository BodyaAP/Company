using DataLayer.Entity;
using DataLayer.Interfaces;
using NHibernate;
using System;

namespace DataLayer.Repositories
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sefact;
        private EmployeeRepository employeeRepository;
        private SickLeaveRepository sickLeaveRepository;
        private VacationRepository vacationRepository;

        public NHUnitOfWork(string connectionString)
        {
            _sefact = NHConfig.Configuration(connectionString);
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(_sefact);
                }

                return employeeRepository;
            }
        }

        public IRepository<SickLeave> SickLeaves
        {
            get
            {
                if (sickLeaveRepository == null)
                {
                    sickLeaveRepository = new SickLeaveRepository(_sefact);
                }

                return sickLeaveRepository;
            }
        }
        public IRepository<Vacation> Vacations
        {
            get
            {
                if (vacationRepository == null)
                {
                    vacationRepository = new VacationRepository(_sefact);
                }

                return vacationRepository;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
