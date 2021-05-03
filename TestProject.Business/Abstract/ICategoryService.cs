using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entity.Concrete;

namespace TestProject.Business.Abstract
{
    //Abstract folderlarda interfacelerimiz olur ce concrete folderına implement edilir. Burda service yazıyoruz.
    public interface ICategoryService
    {
        //Burda yazdığımız methodları proje içine çekerek kullanıcaz

        //Kategori ekleme servisi senkron ve asenkron
        Category Add(Category category);
        Task<Category> AddAsync(Category category);
        //Kategori güncelleme servisi senkron ve asenkron
        Category Update(Category category);
        Task<Category> UpdateAsync(Category category);
        //Kategori silme servisi senkron
        void Delete(Category category);
        //Kategori bulma Id ye göre
        Category GetById(int id);
        //Kategori Listeleme 
        List<Category> GetList();
    }
}
