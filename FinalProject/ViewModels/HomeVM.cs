using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Models.Slider> sliders { get; set; }
        public IEnumerable<Product> LastProducts { get; set; }
        public IEnumerable<Product> FirstTrendingProducts { get; set; }
        public IEnumerable<Product> SecondTrendingProducts { get; set; }
        public IEnumerable<Models.Brand> Brands { get; set; }
        public IEnumerable<Models.Banner> Banners { get; set; }
        public IEnumerable<Product> OfferProduct { get; set; }


    }
}
