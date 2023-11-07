using GameZoneCrudOperations.Data;
using GameZoneCrudOperations.Models;
using GameZoneCrudOperations.Services;
using GameZoneCrudOperations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZoneCrudOperations.Controllers
{
    public class GamesController : Controller
    {
        readonly ApplicationDbContext _context;
        readonly ICategoriesService _categoriesService;
        readonly IDevicesSevice _devicesService;
        readonly IGamesService _gamesService;

        public GamesController(ApplicationDbContext context, ICategoriesService categoriesService, IDevicesSevice devicesService, IGamesService gamesService)
        {
            _context = context;
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null)
                return NotFound();
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var gameViewModel = new CreateGameViewModel()
            {
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList()
            };
            return View(gameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel gameViewModel)
        {
            if(!ModelState.IsValid)
            {
                gameViewModel.Categories = _categoriesService.GetSelectList();
                gameViewModel.Devices = _devicesService.GetSelectList();
                return View(gameViewModel);
            }

            await _gamesService.Create(gameViewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null)
                return NotFound();

            EditGameViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Categories = _categoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList(),
                CategoryId = game.CategoryId,
                Description = game.Description,
                SelectedDevices = game.Devices.Select(d=>d.DeviceId).ToList(),
                CurrentCover = game.Cover,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
            {
                gameViewModel.Categories = _categoriesService.GetSelectList();
                gameViewModel.Devices = _devicesService.GetSelectList();
                return View(gameViewModel);
            }

            var game = await _gamesService.Update(gameViewModel);
            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);  
            
            return isDeleted ? Ok() : BadRequest();
        }
    }
}
