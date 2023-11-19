using Microsoft.EntityFrameworkCore;

namespace FormulaOneAPI.Models.EDMs;

public partial class FormulaContext : DbContext
{
    public FormulaContext()
    {
    }

    public FormulaContext(DbContextOptions<FormulaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<GrandPrix> GrandPrixes { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DatabaseConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("drivers_pkey");

            entity.ToTable("drivers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasColumnName("nationality");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");
        });

        modelBuilder.Entity<GrandPrix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grand_prix_pkey");

            entity.ToTable("grand_prix");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("points_pkey");

            entity.ToTable("points");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.TotalPoints).HasColumnName("total_points");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Driver).WithMany(p => p.Points)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("points_driver_id_fkey");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("results_pkey");

            entity.ToTable("results");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.GrandPrixId).HasColumnName("grand_prix_id");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Driver).WithMany(p => p.Results)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_driver_id_fkey");

            entity.HasOne(d => d.GrandPrix).WithMany(p => p.Results)
                .HasForeignKey(d => d.GrandPrixId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("results_grand_prix_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
