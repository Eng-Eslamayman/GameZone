using GameZoneCrudOperations.Attributes;
using GameZoneCrudOperations.Models;
using GameZoneCrudOperations.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.ViewModels
{
    public class CreateGameViewModel:GamesFormViewModel
    {
        [AllowedExtension(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        
        public IFormFile Cover { get; set; } = default!;
       
    }
}
