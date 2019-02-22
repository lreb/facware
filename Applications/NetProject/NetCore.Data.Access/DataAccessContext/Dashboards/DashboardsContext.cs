using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCore.Data.Access.DataAccessModels.Dashboards
{
    public partial class DashboardsContext : DbContext
    {
        public DashboardsContext()
        {
        }

        public DashboardsContext(DbContextOptions<DashboardsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<AreasProperties> AreasProperties { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MXCHIM0MIDSQL01;User ID=jabil\\\\\\\\chisqladmin;Password=N3w5q1Adm1n2012;Initial Catalog=JabilMaster2;Integrated Security=True;Timeout=1200;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Customers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Users");
                entity.HasMany<AreasProperties>();
            });

            modelBuilder.Entity<AreasProperties>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Group).IsUnicode(false);

                entity.Property(e => e.Parameter).IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreasProperties)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreasProperties_Areas");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AreasProperties)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AreasProperties_Users");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shifts_Customers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmployeeId).IsUnicode(false);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });
        }
    }
}
