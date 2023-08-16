﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "ProductName is required")]
        public string? ProductName { get; init; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = String.Empty;
        public string? ImageUrl { get; set; }//Atama işlemi daha sonra olacağından init yapılmaz

        public int? CategoryId { get; init; }//Foreign Key

       




    }
}
