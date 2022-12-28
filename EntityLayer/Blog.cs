using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogThumbnailImage { get; set; }
        public string? BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; } //ForeingKey ID eşleşmesi
        public Category Category { get; set; }  //ForeingKey'e dahil edilcek classname , Blog Anneleri gibi düşün Category ise yavruları.Blog classına barındı.
        //public int WriterID { get; set; }
        //public Writer Writer { get; set; }
        public List<Comment>? Comments { get; set; }
        public int UserId { get; set; }
    }
}
