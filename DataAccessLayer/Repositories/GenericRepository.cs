using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return c.Set<T>().Find(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IQueryable<T> GetListAll()
        {
            return c.Set<T>().AsQueryable(); // burada kullanacğımız her hangi bir entity olmadığından dışardan set etmek zorunda kaldık
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
            //direk listelemek yerine şartlı bir listeleme seçeneği sunduk.filter'dan gelen değerleri tabiki
        }

        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }

        public List<T> GetListAlll()
        {
            return c.Set<T>().ToList();
        }
    }
}
