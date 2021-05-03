using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;


namespace TestProject.Core.DataAccess
{
    //T bir değişkendir. T classtır, tipi IEntity dir ve new lenebilir.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Task oalrak belirttiklerimiz biizm asenkron modellerimiz üst satırlarındakiye aynı işlem.
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        //bize return etmesini istemediğimizde void kullanırız.
        void Delete(T entity);
        Task DeleteAsync(T entity);
        //Linq kullanarak herhangi bir filtre olabilir o yüzden Expression kullanıyoruz.
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
