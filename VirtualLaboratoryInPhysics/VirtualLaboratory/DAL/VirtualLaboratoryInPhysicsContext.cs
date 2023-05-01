using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public partial class VirtualLaboratoryInPhysicsContext : DbContext
    {
        public VirtualLaboratoryInPhysicsContext()
        {
        }

        public VirtualLaboratoryInPhysicsContext(DbContextOptions<VirtualLaboratoryInPhysicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LaboratoryWork> LaboratoryWorks { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-RTPDA1J;Database=VirtualLaboratoryInPhysics;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaboratoryWork>(entity =>
            {
                entity.ToTable("LaboratoryWork");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("Id_Laboratory_Work");

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_LaboratoryWork");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
