using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag39.GamesBackend.DAL.Repositories;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DALTest
{
    [TestClass]
    public class Test
    {
        private DbContextOptions _options;
        private static DbContextOptions<GamesBackendContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<GamesBackendContext>();
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

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                repo.Insert(new Room()
                {
                    Name = "Naam"
                });
            }


            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFind()
        {
            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                repo.Insert(new Room()
                {
                    Name = "Name"
                });
            }

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Name", result.Name);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                var pen = new Room()
                {
                    Name = "Name"
                };
                repo.Insert(pen);
                repo.Delete(1);
            }

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                Assert.AreEqual(0, repo.Count());
            }
        }
        [TestMethod]
        public void TestFindAll()
        {
            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                var pen = new Room()
                {
                    Name = "Entity"
                };
                repo.Insert(pen);
                pen = new Room()
                {
                    Name = "Name"
                };
                repo.Insert(pen);
            }

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void TestUpdate()
        {

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                repo.Insert(new Room()
                {
                    Name = "Naam"
                });
            }

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                repo.Insert(new Room()
                {
                    Name = "UpdatedName"
                });
            }

            using (var repo = new RoomRepository(new GamesBackendContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual("UpdateName", repo.Find(1).Name);
            }
        }
    }
}