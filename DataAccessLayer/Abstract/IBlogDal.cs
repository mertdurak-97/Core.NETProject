
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory(); // kategoriyle birlikte Blog List'i getir demektir.
                                          // Bu metot sadece bloglara özgü olduğu için geldik burada tanımladık.
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
