#pragma warning restore CS8602 
#pragma warning disable CS8602 
using AulaEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace AulaEntity.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Estudante> Estudantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(connectionString: "Data Source=localhost:1521/XE;User Id=system;Password=@Wtms12481632");
            base.OnConfiguring(optionsBuilder);
        }

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