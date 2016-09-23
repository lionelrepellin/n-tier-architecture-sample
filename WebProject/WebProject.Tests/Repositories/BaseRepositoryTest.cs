using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DAL;

namespace WebProject.Tests.Repositories
{
    [TestFixture]
    public abstract class BaseRepositoryTest
    {
        protected MainContext MainContext;
        private DbContextTransaction _transaction;

        [SetUp]
        public void BeginTransaction()
        {
            MainContext = new MainContext();
            _transaction = MainContext.Database.BeginTransaction();
        }

        [TearDown]
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
