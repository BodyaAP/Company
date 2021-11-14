using DataLayer.Entity;
using DataLayer.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    internal class SickLeaveRepository : IRepository<SickLeave>
    {
        private readonly ISessionFactory _sefact;

        public SickLeaveRepository(ISessionFactory sefact)
        {
            _sefact = sefact;
        }

        public void Create(SickLeave item)
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
                    var sickLeave = session.Get<SickLeave>(id);
                    session.Delete(sickLeave);
                    tx.Commit();
                }
            }
        }

        public SickLeave Get(Guid id)
        {
            SickLeave sickLeave;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    sickLeave = session.Get<SickLeave>(id);
                    tx.Commit();
                }
            }

            return sickLeave;
        }

        public IEnumerable<SickLeave> GetAll()
        {
            IEnumerable<SickLeave> sickLeaves;

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    sickLeaves = session.CreateSQLQuery("EXEC spGetSickLeaves").AddEntity(typeof(SickLeave)).List<SickLeave>();
                    tx.Commit();
                }
            }

            return sickLeaves;
        }

        public void Update(SickLeave item)
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

