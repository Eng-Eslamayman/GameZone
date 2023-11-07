using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.Models
{
    public class Category:BaseEntity
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
