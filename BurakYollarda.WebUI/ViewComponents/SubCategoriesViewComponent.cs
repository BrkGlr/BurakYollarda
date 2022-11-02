using BurakYollarda.Business.Services;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.ViewComponents
{
    public class SubCategoriesViewComponent : ViewComponent
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IPostService _postService;
        public SubCategoriesViewComponent(ISubCategoryService subCategoryService, IPostService postService)
        {
            _subCategoryService = subCategoryService;
            _postService = postService;
        }

        public IViewComponentResult Invoke(int?categoryId=null,int? subCategoryId = null)
        {
            var subCategories = _subCategoryService.GetSubCategories();
            var posts = _postService.GetPosts(subCategoryId);

            var postsView = posts.Select(x => new PostTypeViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();

            var viewModel = subCategories.Select(x => new SubCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Posts = postsView



            }).ToList();
            return View(viewModel);
        }
    }
}
