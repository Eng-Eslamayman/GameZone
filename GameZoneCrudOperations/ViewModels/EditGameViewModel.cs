using GameZoneCrudOperations.Attributes;
using GameZoneCrudOperations.Settings;

namespace GameZoneCrudOperations.ViewModels
{
    public class EditGameViewModel:GamesFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }
        [AllowedExtension(FileSettings.AllowedExtensions),
          MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
