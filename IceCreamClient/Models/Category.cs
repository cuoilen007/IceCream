using System;

namespace IceCreamClient.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
