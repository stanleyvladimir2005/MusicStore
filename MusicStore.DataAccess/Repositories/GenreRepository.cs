
namespace MusicStore.DataAccess.Repository
{
    using MusicStore.Entities;

    public class GenreRepository
    {
        private MusicStoreDbContext _context;

        public GenreRepository(MusicStoreDbContext context)
        {
            _context = context;
        }

        public List<Genre> List()
        {
            return _context.Genres.ToList();
        }

        public void Add(Genre entity)
        {
            _context.Genres.Add(entity);
            _context.SaveChanges();
        }
    }
}