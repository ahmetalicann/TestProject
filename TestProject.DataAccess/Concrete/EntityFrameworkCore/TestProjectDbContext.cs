using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using TestProject.Entity.Concrete;

namespace TestProject.DataAccess.Concrete.EntityFrameworkCore
{
    public class TestProjectDbContext : DbContext
    {
        //onconfuring özelliğimizi override ederek kendi connectionumuzu yazarız.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E087HU5;Database=TestProject;integrated security=true;MultipleActiveResultSets=True;");
        }
        //Veritabanında oluşmasını istediğimiz tabloları buraya gireriz. Ekleme yapmak sitediğimizde de buraya eklemek zorundayız.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        //Model oluşturma özelliini override ederek kendi oluşturduğumuz configuration maplerimizi tanıtırız.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());
            modelBuilder.ApplyConfiguration<ProductImage>(new ProductImageMap());
        }
    }
}
