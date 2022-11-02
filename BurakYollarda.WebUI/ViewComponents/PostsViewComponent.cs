using BurakYollarda.Business.Services;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.ViewComponents
{
    public class PostsViewComponent :ViewComponent
    {
        private readonly IPostService _postService;
        public PostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public IViewComponentResult Invoke(int? categoryId=null,int?subCategoryId=null) 
        {
            var posts=_postService.GetPosts(categoryId,subCategoryId);
            var viewModel = posts.Select(x => new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Summary = x.Summary,
                ImagePath=x.ImagePath,
                CategoryId=x.CategoryId,
                SubCategoryId=x.SubCategoryId
             
                
            }).ToList();
            return View(viewModel);
        }

    }
}
