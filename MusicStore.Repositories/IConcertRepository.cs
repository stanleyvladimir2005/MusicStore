﻿using MusicStore.Entities;
using MusicStore.Entities.infos;

namespace MusicStore.Repositories
{
    public interface IConcertRepository {
        Task<ICollection<ConcertInfo>> ListAsync(string? filter, int page, int rows);
        Task<Concert?> FindByIdAsync(int id);
        Task<int> AddAsync(Concert entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
        Task FinalizeAsync(int id);
    }
}
