using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public string CategoryName { get; set; }
        public string ProductColor { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public Product product { get; set; }
        public IEnumerable<Models.Product> FeaturedProducts { get; set; }
        public int SizeId { get; set; }
        public List<Models.Size> Sizes { get; set; }
        public IEnumerable<int> Product_sizeList { get; set; }
        public Comment Comments { get; set; }
        public IEnumerable<Comment> dbComments { get; set; }

    }
}
