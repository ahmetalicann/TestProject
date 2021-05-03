using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess.EntityFrameworkCore;
using TestProject.DataAccess.Abstract;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concrete;
using System.Linq;

namespace TestProject.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductDal : EfEntityRepositoryBase<Product, TestProjectDbContext>, IProductDal
    {
        //complexData methodumuzu buraya implement ettik. Linq kullanarak içeriği yazdık.
        //Producttaki categoryId yi Category nin Id sine bagladık ve ComplexData ilişkimizi kurduk.
        public List<ProductCategoryComplexData> GetProductWithCategory()
        {
            using (var _context = new TestProjectDbContext())
            {
                var result = from p in _context.Products
                             join c in _context.Categories on p.CategoryId equals c.Id
                             select new ProductCategoryComplexData
                             {
                                 CategoryName = c.Name,
                                 Height = p.Height,
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 Weight = p.Weight,
                                 Widht = p.Widht
                             };
                return result.ToList();
            }
        }
    }
}
