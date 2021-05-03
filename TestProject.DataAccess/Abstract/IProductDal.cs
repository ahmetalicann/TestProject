using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concrete;

namespace TestProject.DataAccess.Abstract
{
    //DataAccess katmanıyla Business katmanı arasında bir köprü görevi oluşturur. IEntityRepositorydeki tüm özellikleri aldık.
    //complex datalarımızı buraya yazarız.
    //ProductCategoryComplexData da girilen bilgileri burda methoda çevirdik.
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductCategoryComplexData> GetProductWithCategory();
    }
}
