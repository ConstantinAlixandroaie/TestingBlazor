using TestingBlazor.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestingBlazor.ViewModels;

namespace CompletKitInstall.ViewModels
{
    public class ProductViewModel: IUIObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
       // public string ImageUrl { get; set; }
       //// public Category Category { get; set; }
       // [Required]
       // public int CategoryId { get; set; }

       // public DateTimeOffset DateCreated { get; set; }
    }
}
