using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concrete;

namespace TestProject.Business.Abstract
{
    public interface IProductService
    {
        //Burda yazdığımız methodları proje içine çekerek kullanıcaz

        //Ürün ekleme
        Product Add(Product product);
        Task<Product> AddAsync(Product product);
        //Ürün Güncelleme
        Product Update(Product product);
        Task<Product> UpdateAsync(Product product);
        //Ürün silme
        void Delete(Product product);
        //******ismi kontrol etmek istedik. O yüzden businessa gelip bu kuralı buraya yazmamız gerekir. Daha sonrasında da managere yazarız.*****
        Product GetByName(string name);
        //Id ye göre ürün bulma
        Product GetById(int id);
        //Ürünleri listeleme
        List<Product> GetList();
        //Category Id ye göre ürün listeleme
        List<Product> GetListByCategoryId(int categoryId);
        //Categorye göre ürün getirme komplex datası
        List<ProductCategoryComplexData> GetProductWithCategory();
    }
}
