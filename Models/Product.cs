using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormApp.Models
{
    public class Product
    {
        [Display(Name = "Product Code")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name field must be filled")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Out of range")]
        [Range(0, 1000000)]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }


    }
}