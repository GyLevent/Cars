using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
