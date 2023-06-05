using Command.Commands.CreatePokemonBattleCommand;
using Command.Commands.CreatePokemonCommand;
using Command.Commands.DeletePokemonCommand;
using Command.Commands.UpdatePokemonCommand;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Domain.DomainNotification;
using Domain.DomainNotification.Handlers;
using Domain.DomainNotification.Interfaces;
using Domain.PokemonBattle.Interfaces;
using Domain.PokemonBattle.Services;
using Microsoft.EntityFrameworkCore;
using Query.Queries.GetPokemon;
using Query.Queries.GetPokemonBattleList;
using Query.Queries.GetPokemonsList;

namespace C_Sharp_API_Example.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PokemonDb");
            services.AddDbContext<PokemonBattleDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandlerAsync<DomainNotification>, DomainNotificationHandlerAsync>();
            services.AddScoped<IPokemonBattleDbContext, PokemonBattleDbContext>();
            services.AddScoped<IGetPokemonListQuery, GetPokemonListQuery>();
            services.AddScoped<IGetPokemonQuery, GetPokemonQuery>();
            services.AddScoped<ICreatePokemonCommand, CreatePokemonCommand>();
            services.AddScoped<IUpdatePokemonCommand, UpdatePokemonCommand>();
            services.AddScoped<IPokemonBattleService, PokemonBattleService>();
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IPokemonBattleRepository, PokemonBattleRepository>();
            services.AddScoped<ICreatePokemonBattleCommand, CreatePokemonBattleCommand>();
            services.AddScoped<IGetPokemonBattleListQuery, GetPokemonBattleListQuery>();
            services.AddScoped<IDeletePokemonCommand, DeletePokemonCommand>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
    }
}
