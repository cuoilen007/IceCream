using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamClient.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
