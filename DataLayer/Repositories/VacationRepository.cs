using DataLayer.Entity;
using DataLayer.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    internal class VacationRepository : IRepository<Vacation>
    {
        private readonly ISessionFactory _sefact;

        public VacationRepository(ISessionFactory sefact)
        {
            _sefact = sefact;
        }

        public void Create(Vacation item)
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
                    var vacation = session.Get<Vacation>(id);
                    session.Delete(vacation);
                    tx.Commit();
                }
            }
        }

        public Vacation Get(Guid id)
        {
            Vacation vacation;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    vacation = session.Get<Vacation>(id);
                    tx.Commit();
                }
            }

            return vacation;
        }

        public IEnumerable<Vacation> GetAll()
        {
            IEnumerable<Vacation> vacations;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    vacations = session.CreateSQLQuery("EXEC spGetVacation").AddEntity(typeof(Vacation)).List<Vacation>();
                    tx.Commit();
                }
            }

            return vacations;
        }

        public void Update(Vacation item)
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

