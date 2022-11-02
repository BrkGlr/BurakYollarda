using BurakYollarda.Business.Services;
using BurakYollarda.Data.Dto;
using BurakYollarda.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        
        public IActionResult Index(int? categoryId=null)
        {
            ViewBag.CategoryId=categoryId;
            ViewBag.Categories = _categoryService.GetCategories();
            var subCategories = _subCategoryService.GetSubCategories(categoryId);
            var viewModel = subCategories.Select(x => new SubCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName

            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {

            ViewBag.Categories = _categoryService.GetCategories();


            return View("form", new SubCategoryFormViewModel());
        }
        [HttpPost]
        public IActionResult Save(SubCategoryFormViewModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View("form", formData);
            }
            var subCategoryDto = new SubCategoryDto()
            {
                Id = formData.Id,
                Name = formData.Name,
                CategoryId = formData.CategoryId
            };

            if (formData.Id == 0)
            {
                var responce = _subCategoryService.AddSubCategory(subCategoryDto);

                if (responce.IsSucceed)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.ErrorMessage = responce.Message;
                    return View("form", formData);
                }
            }
            else
            {
                _subCategoryService.EditSubCategory(subCategoryDto);
            }
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryService.GetCategories();
            var subCategory = _subCategoryService.GetSubCategoryById(id);

            var viewModel = new SubCategoryFormViewModel()
            {
                Id=subCategory.Id,
                Name=subCategory.Name,
                CategoryId=subCategory.CategoryId,
                
                
            };
            return View("form",viewModel);
        }
        public IActionResult Delete(int id)
        {
            _subCategoryService.DeleteSubCategory(id);
            return RedirectToAction("index");
        }
    }
}
