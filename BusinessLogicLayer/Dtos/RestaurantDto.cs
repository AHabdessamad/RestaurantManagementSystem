using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dtos
{
    public class RestaurantDto
    {
        public string? Id { get; set; } 
        public string Nom { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? Image { get; set; } 
    }
}
