using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels.Brand
{
    public class BrandEditVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
