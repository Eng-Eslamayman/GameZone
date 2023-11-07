using GameZoneCrudOperations.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZoneCrudOperations.Services
{
    public class DevicesSevice : IDevicesSevice
    {
        readonly ApplicationDbContext _context;

        public DevicesSevice(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices
               .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
               .OrderBy(d => d.Text)
               .AsNoTracking()
               .ToList();
        }
    }
}
