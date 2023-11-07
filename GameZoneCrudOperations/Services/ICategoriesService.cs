using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZoneCrudOperations.Services
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
