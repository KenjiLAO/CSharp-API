using Microsoft.EntityFrameworkCore;
using monAPI.Entities;

namespace monAPI.Context

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Characters> characters { get; set; } //Le nom de la propriété sera le nom de la table en bdd

        public DbSet<Region> region { get; set; } //Le nom de la propriété sera le nom de la table en bdd

        public DbSet<Weapon> weapon { get; set; } //Le nom de la propriété sera le nom de la table en bdd

        public DbSet<Vision> vision { get; set; } //Le nom de la propriété sera le nom de la table en bdd
    }
}
