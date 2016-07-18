using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Blog
{
    public class BlogIndexViewModel
    {
        public IEnumerable<Entities.Blog> Blogs { get; set; } 
    }
}
