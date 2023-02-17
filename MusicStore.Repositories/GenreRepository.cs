﻿
namespace MusicStore.Repositories
{
    using MusicStore.Entities;
    using MusicStore.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public class GenreRepository : IGenreRepository
    {
        private readonly MusicStoreDbContext _context;

        public GenreRepository(MusicStoreDbContext context){
            _context = context;
        }

        public async Task<List<Genre>> ListAsync(){
            return await _context.Set<Genre>()
                .Where(p => p.Status)
                .ToListAsync();
        }

        public async Task<int> AddAsync(Genre entity) {
            await _context.Set<Genre>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Genre?> FindByIdAsync(int id){
            return await _context.Set<Genre>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Genre entity){
            _context.Set<Genre>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id){
            var entity = await _context.Set<Genre>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (entity != null) {
                entity.Status = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}