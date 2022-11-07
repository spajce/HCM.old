using Microsoft.EntityFrameworkCore;
using Audit.Domain.Entities;

#nullable disable

namespace Audit.Domain
{
    public partial class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        public virtual DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<AuditEntry>(entity =>
            {
                entity.ToTable("auditentries");

                entity.Property(e => e.AuditEntryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AuditEntryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EntitySetName).HasMaxLength(255);

                entity.Property(e => e.EntityTypeName).HasMaxLength(255);

                entity.Property(e => e.State).HasColumnType("int(11)");

                entity.Property(e => e.StateName).HasMaxLength(255);
            });

            modelBuilder.Entity<AuditEntryProperty>(entity =>
            {
                entity.ToTable("auditentryproperties");

                entity.HasIndex(e => e.AuditEntryId, "fk_auditentries_properties_idx");

                entity.Property(e => e.AuditEntryPropertyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AuditEntryPropertyID");

                entity.Property(e => e.AuditEntryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AuditEntryID");

                entity.Property(e => e.NewValue).HasColumnType("text");

                entity.Property(e => e.OldValue).HasColumnType("text");

                entity.Property(e => e.PropertyName).HasMaxLength(255);

                entity.Property(e => e.RelationName).HasMaxLength(255);

                entity.HasOne(d => d.AuditEntry)
                    .WithMany(p => p.AuditentryProperties)
                    .HasForeignKey(d => d.AuditEntryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_auditentries_properties");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("auditlog");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("Id");

                entity.Property(e => e.Action).HasColumnType("text");

                entity.Property(e => e.TableName).HasMaxLength(255);

                entity.Property(e => e.Values).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(255);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
