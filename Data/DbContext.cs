#pragma warning restore CS8602 
#pragma warning disable CS8602 
using AulaEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace AulaEntity.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Estudante> Estudantes { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudante>()
                .Property(e => e.Ativo)
                .HasColumnType("NUMBER(1)");


            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {

                entity.SetTableName(entity.GetTableName().ToUpper());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToUpper());
                }
            }
        }

    }
}