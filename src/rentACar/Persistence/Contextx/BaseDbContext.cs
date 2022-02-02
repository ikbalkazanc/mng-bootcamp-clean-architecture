using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contextx;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Fuel> Fuels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(Configuration.GetConnectionString("RentACarConnectionString")));
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Brand>(b =>
        {
            b.ToTable("Brands").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.HasMany(p => p.Models);
        });
        modelBuilder.Entity<Color>(b =>
        {
            b.ToTable("Colors").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.HasMany(p => p.Cars);
        });
        modelBuilder.Entity<Fuel>(b =>
        {
            b.ToTable("Fuels").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.HasMany(p => p.Models);
        });
        modelBuilder.Entity<Transmission>(b =>
        {
            b.ToTable("Transmissions").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.HasMany(p => p.Models);
        });
        modelBuilder.Entity<Car>(b =>
        {
            b.ToTable("Cars").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.ModelYear).HasColumnName("ModelYear");
            b.Property(p => p.CatState).HasColumnName("State");
            b.Property(p => p.Plate).HasColumnName("Plate");
            b.Property(p => p.ColorId).HasColumnName("ColorId");
            b.HasOne(p => p.Color);
            b.Property(p => p.ModelId).HasColumnName("ModelId");
            b.HasOne(p => p.Model);
        });

        modelBuilder.Entity<Model>(b =>
        {
            b.ToTable("Models").HasKey(k => k.Id);
            b.Property(p => p.Id).HasColumnName("Id");
            b.Property(p => p.Name).HasColumnName("Name");
            b.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
            b.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
            b.HasOne(x => x.Transmission);
            b.HasOne(x => x.Fuel);
            b.HasOne(x => x.Brand);
        });
    }
}