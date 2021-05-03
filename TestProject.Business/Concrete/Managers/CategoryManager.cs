using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.DataAccess.Abstract;
using TestProject.Entity.Concrete;

namespace TestProject.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        //Depency ve injection yöntemlerinden injection kullanıyoruz. Bu işlem ile IcategoryDal içerisindeki bütün operasyonları kullanabilirim.
        //Yani ordanda IEntitiyRepositorye kadar gidebiliriz. Yani burda Core katmanı ile bir köprü olusturduk.

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //Ekleme
        public Category Add(Category category)
        {
            return _categoryDal.Add(category);
        }
        //Ekleme asenkron. Asenkronlarda await kullanılır.
        public async Task<Category> AddAsync(Category category)
        {
            return await _categoryDal.AddAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(d => d.Id == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetAll();
        }

        public Category Update(Category category)
        {
            return _categoryDal.Update(category);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            return await _categoryDal.UpdateAsync(category);
        }
    }
}
