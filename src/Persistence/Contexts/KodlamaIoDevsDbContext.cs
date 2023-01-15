using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class KodlamaIoDevsDbContext : DbContext
    {
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        
        // 
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public KodlamaIoDevsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).UseIdentityColumn();
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });



            ProgramingLanguage[] someProgramingLanguagesSeeds = { new(1, "Python"), new(2, "C#"), new(3, "Java") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(someProgramingLanguagesSeeds);


            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(t => t.Id).UseIdentityColumn();
                a.Property(t => t.Id).HasColumnName("Id");
                a.Property(t => t.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                a.Property(t => t.Name).HasColumnName("Name");
                a.HasOne(t => t.ProgramingLanguage);
            });

            Technology[] someTechnologiesSeeds = { new(1, "Java", 3), new(2, "C#", 2), new(3, "Django", 1) };
            modelBuilder.Entity<Technology>().HasData(someTechnologiesSeeds);


        }
    }
}
