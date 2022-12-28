using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //buraya öyle bir instans yazıcaz ki sadece ilgili entity muadili olacak.
        //constractor devreye girecek :) 


        ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public void AddCategory(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetCategoryId(int id)
        {
            return _categoryDal.GetById(id);
        }

        public IQueryable<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public List<Category> ListAllCategory()
        {
            return _categoryDal.GetListAlll();
        }


        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }

        IQueryable<Category> ICategoryService.ListAllCategory()
        {
            throw new NotImplementedException();
        }
    }


}
