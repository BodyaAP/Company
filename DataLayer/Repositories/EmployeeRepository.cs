using DataLayer.Entity;
using DataLayer.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    internal class EmployeeRepository : IRepository<Employee>
    {
        private readonly ISessionFactory _sefact;

        public EmployeeRepository(ISessionFactory sefact)
        {
            _sefact = sefact;
        }

        public void Create(Employee item)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(item);

                    tx.Commit();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var employee = session.Get<Employee>(id);
                    session.Delete(employee);
                    tx.Commit();
                }
            }
        }

        public Employee Get(Guid id)
        {
            Employee employee;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    employee = session.Get<Employee>(id);
                    tx.Commit();
                }
            }

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    employees = session.CreateSQLQuery("EXEC spGetEmployees").AddEntity(typeof(Employee)).List<Employee>();
                    tx.Commit();
                }
            }

            return employees;
        }

        public void Update(Employee item)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(item);
                    tx.Commit();
                }
            }
        }
    }
}
