using GameZoneCrudOperations.Models;
using GameZoneCrudOperations.ViewModels;

namespace GameZoneCrudOperations.Services
{
    public interface IGamesService
    {
        Task Create(CreateGameViewModel game);
        Task<Game?> Update(EditGameViewModel game);
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        bool Delete(int id);
    }
}
