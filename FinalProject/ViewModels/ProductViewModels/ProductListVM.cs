using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels.ProductViewModels
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public string Brand { get; set; }
    }
}
