using Microsoft.EntityFrameworkCore;
using MusicStore.DataAccess;
using MusicStore.Entities;
using MusicStore.Entities.infos;

namespace MusicStore.Repositories
{
    public class ConcertRepository : IConcertRepository{
        
        private readonly MusicStoreDbContext _context;

        public ConcertRepository(MusicStoreDbContext context) {
            _context = context;
        }


        public async Task<int> AddAsync(Concert entity) {
            await _context.Set<Concert>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Concert?> FindByIdAsync(int id){
            return await _context.Set<Concert>()
            .Include(p => p.Genre)   
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ConcertInfo>> ListAsync(string? filter, int page, int rows) {
          return await _context.Set<Concert>()
            .Include(p => p.Genre) //Eager Loading -> Es una precarga
            .Where(p => p.Status  && (p.Title.Contains(filter ?? string.Empty)))
            .OrderByDescending(p => p.DateEvent)
            .Skip((page - 1) * rows)
            .Take(rows)
            .Select(p => new ConcertInfo {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                DateEvent = p.DateEvent.ToString("yyyy-MM-dd"),
                TimeEvent = p.DateEvent.ToString("HH:mm:ss"),
                Genre = p.Genre.Name, // Lazy Loading -> Solo cuando se necesita utiliza el dato
                UnitPrice = p.UnitPrice,
                ImageUrl = p.ImageUrl,
                Place = p.Place,
                TicketsQuantity = p.TicketsQuantity,
                Status = p.Finalized ? "Finalizado" : "Pendiente"
            })
             .AsNoTracking() // Permite traer los datos sin el ChangeTracker de EF Core
            .ToListAsync();
        }

        public async Task UpdateAsync() {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var entity = await _context.Set<Concert>().FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null) {
                entity.Status = false;
                await UpdateAsync();
            }
            else
                throw new InvalidOperationException("No se encontró el concierto");
        }

        public async Task FinalizeAsync(int id) {
            var entity = await _context.Set<Concert>().SingleOrDefaultAsync(x => x.Id == id && x.Status);

            if (entity == null) throw new InvalidOperationException("No se encontró el concierto");
            entity.Finalized = true;
            await UpdateAsync();

        }
    }
}
