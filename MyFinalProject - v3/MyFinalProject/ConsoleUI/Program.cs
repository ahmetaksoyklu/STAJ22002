using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//SOLID
//OPEN CLOSED PRİNCİPLE
ProductMenager productMenager=new ProductMenager(new EfProductDal());

foreach (var product in productMenager.GetAll())
{
    Console.WriteLine(product.ProductName);
}

foreach (var product in productMenager.GetAllByCategoryId(2))
{
    Console.WriteLine(product.ProductName);
}