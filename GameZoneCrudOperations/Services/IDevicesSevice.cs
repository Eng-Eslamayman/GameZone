using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZoneCrudOperations.Services
{
    public interface IDevicesSevice
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
