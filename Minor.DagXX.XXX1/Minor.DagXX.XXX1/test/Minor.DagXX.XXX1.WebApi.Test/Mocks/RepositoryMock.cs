using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Minor.DagXX.XXX1.DAL.DAL;
using Minor.DagXX.XXX1.Entities.Entities;
using Minor.DagXX.XXX1.DAL.DatabaseContexts;

namespace Minor.DagXX.XXX1.WebApi.Test.Mocks
{
    public class RepositoryMock
        : EntityRepository
    {
        public int TimesCalled { get; set; }
        public RepositoryMock(DatabaseContext context) : base(context)
        {
        }

        public RepositoryMock() : base(new DatabaseContext())
        {
           
        }

        public override IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Entity> GetDbSet()
        {
            return _context.Entities;
        }
        public override Entity Find(int id)
        {
            TimesCalled++;
            return null;
        }
        protected override int GetKeyFrom(Entity item)
        {        
            return item.Id; ;
        }

        public int Count()
        {
            TimesCalled++;
            return 0;
        }

        public override int Insert(Entity item)
        {
            return TimesCalled++;
        }

        public override int Update(Entity item)
        {
            return TimesCalled++;
        }
        public override int Delete(int id)
        {
            return TimesCalled++;
        }
        public override IEnumerable<Entity> FindAll()
        {
            TimesCalled++;
            return null;
        }
    }
}