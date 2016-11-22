using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.DagXX.XXX1.Entities.Entities;
using Minor.DagXX.XXX1.WebApi.Controllers;
using Minor.DagXX.XXX1.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.DagXX.XXX1.WebApi.Test
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void EntityGetTest()
        {
            using (var repo = new RepositoryMock())
            {
                var target = new EntitiesController(repo);

                IEnumerable<Entity> result = target.Get();

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void EntityGetWithIdTest()
        {
            using (var repo = new RepositoryMock())
            {
                var target = new EntitiesController(repo);

                var result = target.Get(2);

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void EntityPostTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new EntitiesController(repo);

                target.Post(new Entity());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void EntityPutTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new EntitiesController(repo);

                target.Put(new Entity());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void EntitiesDeletTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new EntitiesController(repo);

                target.Delete(2);

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }
    }
}