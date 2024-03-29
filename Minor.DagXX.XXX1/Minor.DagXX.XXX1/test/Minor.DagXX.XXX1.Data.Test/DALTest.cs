﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minor.DagXX.XXX1.DAL.DAL;
using Minor.DagXX.XXX1.DAL.DatabaseContexts;
using Minor.DagXX.XXX1.Entities.Entities;

namespace Minor.DagXX.XXX1.Data.Test
{
    [TestClass]
    public class DALTest
    {
        private DbContextOptions _options;
        private static DbContextOptions<DatabaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestInitialize]
        public void Init()
        {
            _options = CreateNewContextOptions();
        }

        [TestMethod]
        public void TestAdd()
        {
            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Entity()
                {
                    Name = "Naam"
                });
            }

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual("Naam", repo.Find(1).Name);
            }
        }

        [TestMethod]
        public void TestFind()
        {
            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Entity()
                {
                    Name = "Name"
                });
            }

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Name", result.Name);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                var pen = new Entity()
                {
                    Name = "Name"
                };
                repo.Insert(pen);
                repo.Delete(1);
            }

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(0, repo.Count());
            }
        }
        [TestMethod]
        public void TestFindAll()
        {
            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                var pen = new Entity()
                {
                    Name = "Entity"
                };
                repo.Insert(pen);
                pen = new Entity()
                {
                    Name = "Name"
                };
                repo.Insert(pen);
            }

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void TestUpdate()
        {

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Entity()
                {
                    Name = "Naam"
                });
            }

            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                repo.Update(new Entity()
                {
                    Id = 1,
                    Name = "Aangepast"
                });
            }


            using (var repo = new EntityRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual("Aangepast", repo.Find(1).Name);
            }
        }
    }
}
