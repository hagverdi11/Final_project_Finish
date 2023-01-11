using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels.Social
{
    public class SocialCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
