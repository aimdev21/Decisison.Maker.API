using Decisison.Maker.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Decisison.Maker.API.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Decision> Decisions => Set<Decision>();
    public DbSet<Pro> Pros => Set<Pro>();
    public DbSet<Con> Cons => Set<Con>();
    public DbSet<UserSelection> UserSelections => Set<UserSelection>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
