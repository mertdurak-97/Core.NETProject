using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IQueryable<T> GetListAll();
        List<T> GetListAlll();
        T GetById(int id);
        //Bu Generic'in amacı Abstract klasörü içindeki Class'ları beslemek Genericlik kurmak Interface yollamak.
        //Şimdi önceden tanımladığımız Blog ve Category Interfacelerinin içlerini siliyoruz.Çünkü tanımlanmış halleri var nerede ? işte burada :)
        //Category ve Blog'uniçine tekrar tekrar doldurmak yerine GenericDal'dan Interface ettik.
        //Yarın bi gün yeniden bir entity tanımlamak için her bir classların içine bunu defalarca yazmak yerine buraya yapıştır ve geç...
        List<T> GetListAll(Expression<Func<T, bool>> filter);
        //bu metot bloglara göre listeleme işlemi yapacak.
        //Doğru gidelim buunu GenericRepository içine de tanımlayalım.
    }
}
