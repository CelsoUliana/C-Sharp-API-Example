using Data.Interfaces;
using Data.PokemonBattleConfiguration;
using Data.PokemonConfiguration;
using Domain.PokemonBattle;
using Domain.Pokemons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class PokemonBattleDbContext : DbContext, IPokemonBattleDbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<PokemonBattle> PokemonBattles { get; set; }

        public PokemonBattleDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Save()
        {
            return await this.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("PokemonDb");

            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("C-Sharp-API-Example"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new PokemonMapping().Configure(builder.Entity<Pokemon>());
            new PokemonBattleMapping().Configure(builder.Entity<PokemonBattle>());
        }
    }
}
