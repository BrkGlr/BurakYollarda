using BurakYollarda.Business.Services;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.ViewComponents
{
    public class DetailsViewComponent:ViewComponent
    {

        private readonly IPostService _postService;
        public DetailsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var post = _postService.GetPostById(id);
            var viewModel = new PostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Summary = post.Summary,
                Content = post.Content,
                ImagePath = post.ImagePath,
                CategoryId = post.CategoryId,
                SubCategoryId = post.SubCategoryId,

            };
            return View(viewModel);

        }
    }
}
