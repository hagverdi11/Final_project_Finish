using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Comment : BaseEntity
    {
        public string CommentDetail { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime AddingTime { get; set; }
    }
}
