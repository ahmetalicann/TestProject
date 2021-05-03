using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.DataAccess;
using TestProject.Entity.Concrete;

namespace TestProject.DataAccess.Abstract
{
    //DataAccess katmanıyla Business katmanı arasında bir köprü görevi oluşturur. IEntityRepositorydeki tüm özellikleri aldık.
    public interface ICategoryDal : IEntityRepository<Category>
    {

    }
}
