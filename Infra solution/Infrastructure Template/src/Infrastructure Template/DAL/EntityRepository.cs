using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Case2.NAAM.APPLICATIENAAM.Infrastructure.DatabaseContexts;

namespace Case2.NAAM.APPLICATIENAAM.Infrastructure.DAL
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
