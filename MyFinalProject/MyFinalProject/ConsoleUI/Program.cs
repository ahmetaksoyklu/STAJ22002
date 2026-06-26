using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductMenager productMenager=new ProductMenager(new InMemoryProductDal());

foreach (var product in productMenager.GetAll())
{
    Console.WriteLine(product.ProductName);
}

//new Product { ProductName = "sdfasf" };


