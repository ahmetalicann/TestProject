using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.Entity.Concrete;
using TestProject.MvcWebUI.Models;

namespace TestProject.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        //Contoleera bir servis ekledıgımız zaman onu görebilmesi için middleware yazmamız şazım. Yani Startupa gidip configure yapmamız lazım.

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult GetCategories()
        {
            var categoryViewModel = new CategoryViewModel
            {
                Categories = _categoryService.GetList()
            };
            return View(categoryViewModel);
        }

        public IActionResult Add(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryForAdd = new Category
                {
                    AddedBy = "Ahmet Ali Can",
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Name = categoryViewModel.Category.Name
                };
                try
                {
                    _categoryService.Add(categoryForAdd);
                    return RedirectToAction("GetCategories");
                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("GetCategories");
        }

        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return Json(0);
            }
            return Json(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryIsValid = _categoryService.GetById(categoryViewModel.Category.Id);
                if (categoryIsValid == null)
                {
                    return RedirectToAction("GetCategories");
                }
                try
                {
                    var categoryForUpdate = new Category
                    {
                        AddedBy = categoryIsValid.AddedBy,
                        AddedDate = categoryIsValid.AddedDate,
                        Id=categoryIsValid.Id,
                        IsActive = categoryViewModel.Category.IsActive,
                        Name = categoryViewModel.Category.Name
                    };
                    _categoryService.Update(categoryForUpdate);
                    return RedirectToAction("GetCategories");
                }
                catch (Exception)
                {
                    return RedirectToAction("GetCategories");
                }
            }
            return RedirectToAction("GetCategories");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetCategories");
            }
            var categoryIsValid = _categoryService.GetById(id);
            if (categoryIsValid == null)
            {
                return RedirectToAction("GetCategories");
            }
            try
            {
                _categoryService.Delete(categoryIsValid);
                return RedirectToAction("GetCategories");
            }
            catch (Exception)
            {
                return RedirectToAction("GetCategories");
            }
        }
    }
}
