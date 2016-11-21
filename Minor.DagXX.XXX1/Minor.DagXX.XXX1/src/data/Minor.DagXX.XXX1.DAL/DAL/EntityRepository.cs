using Minor.DagXX.XXX1.DAL.DatabaseContexts;
using Minor.DagXX.XXX1.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Minor.DagXX.XXX1.DAL.DAL
{
    public class EntityRepository
        : BaseRepository<Entity, int, DatabaseContext>
    {
        public EntityRepository(DatabaseContext context)
            : base(context)
        {

        }
        protected override DbSet<Entity> GetDbSet()
        {
            return _context.Entities;
        }

        protected override int GetKeyFrom(Entity item)
        {
            return item.Id;
        }
    }
}
