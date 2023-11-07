using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.Models
{
    public class Game:BaseEntity
    {     
        [MaxLength(2500)]
        public string Description { get; set; } = null!;
        [MaxLength(500)]
        public string Cover { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set;} = new List<GameDevice>();
    }
}
