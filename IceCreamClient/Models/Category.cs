using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamClient.Models
{
    public class Category
    {
        public Category()
        {
            BookIceCreams = new HashSet<BookIceCream>();
            Recipes = new HashSet<Recipe>();
        }

        public int CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<BookIceCream> BookIceCreams { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
