using Microsoft.EntityFrameworkCore;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Infrastructure.DAL;

namespace Minor.Dag39.GamesBackend.DAL.Repositories
{
    public class RoomRepository
        : BaseRepository<Room, long, GamesBackendContext>
    {
        public RoomRepository(GamesBackendContext context) : base(context)
        {
        }

        protected override DbSet<Room> GetDbSet()
        {
            return _context.Games;
        }

        protected override long GetKeyFrom(Room item)
        {
            return item.Id;
        }
    }
}