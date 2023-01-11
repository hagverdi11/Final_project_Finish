using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<ProductCategory> categories { get; set; }
        public IEnumerable<Models.Size> Sizes { get; set; }
        public IEnumerable<Models.Brand> Brands { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}
