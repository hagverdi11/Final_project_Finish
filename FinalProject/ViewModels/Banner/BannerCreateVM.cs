using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels.Banner
{
    public class BannerCreateVM
    {
        [Required(ErrorMessage = "Title can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Header can't be empty")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Description can't be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Image can't be empty")]
        public IFormFile Photo { get; set; }
    }
}
