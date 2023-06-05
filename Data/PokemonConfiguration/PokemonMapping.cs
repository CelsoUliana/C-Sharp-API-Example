using Domain.PokemonBattle;
using Domain.Pokemons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PokemonConfiguration
{
    public class PokemonMapping : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Attack)
                .IsRequired();

            builder.Property(p => p.Defense)
                .IsRequired();

            builder.Property(p => p.HP)
                .IsRequired();

            builder.Property(p => p.Speed)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Type1)
                .IsRequired();

            builder.Property(p => p.Type2);

            builder.HasKey(p => p.Id);

            builder.HasMany<PokemonBattle>()
                .WithOne(p => p.WinnerPokemon)
                .HasForeignKey(p => p.PokemonWinnerId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany<PokemonBattle>()
                .WithOne(p => p.Pokemon1)
                .HasForeignKey(p => p.Pokemon1Id)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany<PokemonBattle>()
                .WithOne(p => p.Pokemon2)
                .HasForeignKey(p => p.Pokemon2Id)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Pokemon() { Id = 1, Attack = 255, Defense = 255, Speed = 255, HP = 255, Name = "Charizad", Type1 = PokemonType.Fire, Type2 = PokemonType.Flying }
            );
        }
    }
}
