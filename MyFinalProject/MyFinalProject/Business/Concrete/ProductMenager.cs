using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductMenager : IProductService
    {
        IProductDal _productDal;

        public ProductMenager(IProductDal productDal)
        {
            _productDal = productDal;
        }

       //InMemoryProductDal inMemory=new InMemoryProductDal();
        
        public List<Product> GetAll()
        {
            //inMemory.GetAll();
            //iş kodları gelicek
           return _productDal.GetAll();
        }
    }
}
