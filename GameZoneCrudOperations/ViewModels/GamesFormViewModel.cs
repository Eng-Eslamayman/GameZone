using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.ViewModels
{
    public class GamesFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        [MaxLength(2500)]
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        [Display(Name = "Supported Devices")]
        public IEnumerable<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
