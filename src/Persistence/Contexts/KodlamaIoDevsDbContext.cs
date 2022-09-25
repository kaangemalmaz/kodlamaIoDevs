using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class KodlamaIoDevsDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }


        public KodlamaIoDevsDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
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
