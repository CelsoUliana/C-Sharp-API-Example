using Domain.PokemonBattle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PokemonBattleConfiguration
{
    public class PokemonBattleMapping : IEntityTypeConfiguration<PokemonBattle>
    {
        public void Configure(EntityTypeBuilder<PokemonBattle> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Pokemon1Id)
                .IsRequired();

            builder.Property(p => p.Pokemon2Id)
                .IsRequired();

            builder.Property(p => p.PokemonWinnerId)
                .IsRequired();

            builder.HasKey(p => p.Id);
        }
    }
}
