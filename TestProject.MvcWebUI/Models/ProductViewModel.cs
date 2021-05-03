using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Entity.ComplexTypes;
using TestProject.Entity.Concrete;

namespace TestProject.MvcWebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductCategoryComplexData> Products { get; set; }
        //public List<Product> Products { get; set; }
        //Categorileri dropdown olarak çekmek için yazdık
        public List<SelectListItem> Categories { get; set; }
        public List<IFormFile> FormFiles { get; set; }
    }
}
