using GameZoneCrudOperations.Data;
using GameZoneCrudOperations.Models;
using GameZoneCrudOperations.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameZoneCrudOperations.Services
{
    public class GamesService:IGamesService
    {
        readonly ApplicationDbContext _context;
        readonly IWebHostEnvironment _webHostEvironment;
        readonly string _imagsPath;

        public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEvironment)
        {
            _context = context;
            _webHostEvironment = webHostEvironment;
            _imagsPath = $"{_webHostEvironment.WebRootPath}/assets/images/games";
        }

        public async Task Create(CreateGameViewModel game)
        {
            var coverName = await SaveCover(game.Cover);
            var newGame = new Game()
            {
                Name = game.Name,
                CategoryId = game.CategoryId,
                Cover = coverName,
                Description = game.Description,
                Devices = game.SelectedDevices.Select(d => new GameDevice { DeviceId = d}).ToList(),
            };
            _context.Add(newGame);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = false;
            var game = _context.Games.Find(id);
            if (game is null)
                return isDeleted;

            _context.Games.Remove(game);
            var effectedRows = _context.SaveChanges();
            if (effectedRows > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imagsPath, game.Cover);
                File.Delete(cover);
            }
            return isDeleted;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(c => c.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games
               .Include(c => c.Category)
               .Include(g => g.Devices)
               .ThenInclude(d => d.Device)
               .AsNoTracking()
               .SingleOrDefault(g => g.Id == id);
        }

        public async Task<Game?> Update(EditGameViewModel model)
        {
            var game = _context.Games
                .Include(c => c.Devices)
                .SingleOrDefault(g => g.Id == model.Id);
            if(game is null)
                return null;
            
            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.CategoryId = model.CategoryId;
            game.Description = model.Description;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(); 

            if(hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();
            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagsPath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagsPath, game.Cover);
                File.Delete(cover);
                return null;
            }
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagsPath, coverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }
    }
}
