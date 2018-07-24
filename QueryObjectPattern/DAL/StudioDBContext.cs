using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QueryObjectPattern.DAL
{
    public partial class StudioDBContext : DbContext
    {
        public StudioDBContext()
        {
        }

        public StudioDBContext(DbContextOptions<StudioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientData> ClientData { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<RegulatoryEmailHistory> RegulatoryEmailHistory { get; set; }
        public virtual DbSet<SellOutImportTranscoding> SellOutImportTranscoding { get; set; }
        public virtual DbSet<Spices> Spices { get; set; }
        public virtual DbSet<Test1> Test1 { get; set; }

        // Unable to generate entity type for table 'dbo.ClientiRanbaxy'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NewClientiRanbaxy'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Contacts'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudioDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientData>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDateUtc)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Cognome).HasMaxLength(30);

                entity.Property(e => e.Nome).HasMaxLength(30);
            });

            modelBuilder.Entity<RegulatoryEmailHistory>(entity =>
            {
                entity.Property(e => e.EmailRecipients).HasMaxLength(2000);

                entity.Property(e => e.EmailSubject).HasMaxLength(1000);

                entity.Property(e => e.SentDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");
            });

            modelBuilder.Entity<SellOutImportTranscoding>(entity =>
            {
                entity.HasKey(e => new { e.TranscodingType, e.SourceValue });

                entity.ToTable("SellOut_ImportTranscoding");

                entity.Property(e => e.TranscodingType).HasMaxLength(50);

                entity.Property(e => e.SourceValue).HasMaxLength(100);

                entity.Property(e => e.DestinationValue)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Spices>(entity =>
            {
                entity.HasKey(e => e.SpiceId);

                entity.Property(e => e.SpiceId)
                    .HasColumnName("SpiceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SpiceMixName).HasMaxLength(64);

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<Test1>(entity =>
            {
                entity.Property(e => e.Cognome).HasMaxLength(200);

                entity.Property(e => e.Nome).HasMaxLength(200);
            });
        }
    }
}
