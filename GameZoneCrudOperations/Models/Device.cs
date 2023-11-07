using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.Models
{
    public class Device:BaseEntity
    {
        [MaxLength(100)]
        public string Icon { get; set; } = null!;
    }
}
