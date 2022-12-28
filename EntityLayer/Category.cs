using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category
    {

        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //CodeFirst ile ilişkili tablolar yapacağımız zaman silme problem olacağından bunun durumunu aktif ya da pasife çekeceğiz.
        public List<Blog>? Blogs { get; set; }//Bir Blog Sayfasının Birden Fazla Category'si olur.  
    }
}
