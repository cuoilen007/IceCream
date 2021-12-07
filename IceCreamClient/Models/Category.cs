using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> a2e3cbe94dca43b032e8a5575609f02caf0e884a

namespace IceCreamClient.Models
{
    public class Category
    {
<<<<<<< HEAD
=======
        public Category()
        {
            BookIceCreams = new HashSet<Book>();
            Recipes = new HashSet<Recipe>();
        }

>>>>>>> a2e3cbe94dca43b032e8a5575609f02caf0e884a
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateAt { get; set; }
<<<<<<< HEAD
=======

        public virtual ICollection<Book> BookIceCreams { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
>>>>>>> a2e3cbe94dca43b032e8a5575609f02caf0e884a
    }
}
