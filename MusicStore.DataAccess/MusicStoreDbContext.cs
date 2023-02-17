namespace MusicStore.DataAccess;

using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using System.Reflection;

public class MusicStoreDbContext : DbContext
{
    public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
