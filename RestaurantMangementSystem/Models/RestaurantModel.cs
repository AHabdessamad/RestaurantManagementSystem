using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMangementSystem.Models
{
    public class RestaurantModel
    {
        public string? Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; } = string.Empty;
    }
}
