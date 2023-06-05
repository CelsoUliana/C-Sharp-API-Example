namespace Command.Commands.DeletePokemonCommand
{
    public interface IDeletePokemonCommand
    {
        Task Execute(int id);
    }
}
