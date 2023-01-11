using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
