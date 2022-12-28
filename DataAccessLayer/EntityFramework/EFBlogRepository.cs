using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    //Entity Dosya yolu yapmamızın tek sebebi bağımlılıkları minimize etmek.Yarın başka bir projeye geçtiğin zaman tek bir kalıtım yoluyla bu işi halledebilmek.
    //DependingInjection
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        Context c = new Context();
        public List<Blog> GetListWithCategory()
        {
            return c.Blogs.Include(x => x.Category).ToList(); //Include metodunu kullanmaktaki görev şu ; Blogların içinde dahil etmek istediğimiz kısmı lambda sorgusuyla eklemek.
                                                              // Include metodunun kullanabilirliği için Business Katmanına yazılması gerek
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return c.Blogs.Include(x => x.Category).Where(x => x.UserId == id).ToList();
        }
    }
}
