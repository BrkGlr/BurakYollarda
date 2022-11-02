using BurakYollarda.Business.Services;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IPostService _postService;

        public CategoriesViewComponent(ICategoryService categoryService,ISubCategoryService subCategoryService,IPostService postService )
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _postService = postService;
        }
        public IViewComponentResult Invoke(int? categoryId, int? subCategoryId)
        {
            var categories=_categoryService.GetCategories();
            var subCategories=_subCategoryService.GetSubCategories(categoryId);
            var posts=_postService.GetPosts(subCategoryId);


            var postsView = posts.Select(x => new PostTypeViewModel()
            {
                Id = x.Id,
                Title = x.Title,
               
            }).ToList();

            
          

            var subCategoriesView = subCategories.Select(x => new SubCategoryTypeViewModel()
            {
                Id = x.Id,
                Name=x.Name,
               
                
                Posts = postsView

            }).ToList();

          

            var viewModel = categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SubCategories=subCategoriesView,
              
                
                
            }).ToList();
            return View(viewModel);
        }
    }
}
