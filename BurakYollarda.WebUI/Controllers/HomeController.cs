using BurakYollarda.Business.Services;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public HomeController(IPostService postService,ICategoryService categoryService,ISubCategoryService subCategoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        [Route("/")]
        [Route("postlar/{categoryName}/{categoryId}/{subcategoryName?}/{subcategoryId?}/{postName?}/{postId?}")]
        public IActionResult Index(int? categoryId,int? subCategoryId,int? postId)
        {
            
            ViewBag.CategoryId = categoryId;
            ViewBag.SubCategoryId = subCategoryId;
            ViewBag.PostId = postId;

          

            return View();
        }
        [Route("Postlar/")]
        public IActionResult Details(int id)
        {
            var post = _postService.GetPostById(id);
            //var viewModel = new PostViewModel
            {
                //Id = post.Id,
                //Title = post.Title,
                //Summary = post.Summary,
                //Content = post.Content,
                //ImagePath = post.ImagePath

            };
            return View(id);
        }
    }

}
