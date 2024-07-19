using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService

    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SucceededResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SucceededResult(Messages.CategoryDeleted);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SucceededDataResult<Category>(_categoryDal.Get(c => c.CategoryID == id) , Messages.CategoryAdded);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SucceededDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SucceededResult(Messages.CategoryUpdated);
        }
    }
}
