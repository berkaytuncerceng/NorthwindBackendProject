using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SucceededResult(Messages.ProductAdded);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SucceededResult(Messages.ProductUpdated);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SucceededResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SucceededDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SucceededDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SucceededDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }


    }
}
