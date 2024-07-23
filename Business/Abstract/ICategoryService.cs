using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetList();
        public IResult Add(Category category);
        public IResult Update(Category category);
        public IResult Delete(Category category);
    }
}
