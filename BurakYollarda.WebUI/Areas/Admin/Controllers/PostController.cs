using BurakYollarda.Business.Services;
using BurakYollarda.Data.Dto;
using BurakYollarda.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(ISubCategoryService subCategoryService,IPostService postService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _subCategoryService = subCategoryService;
            _postService = postService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var posts = _postService.GetPosts();
            var viewModel = posts.Select(x => new PostViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Summary = x.Summary,
                ImagePath = x.ImagePath,
                SubCategoryId = x.SubCategoryId,
                CategoryId = x.CategoryId,
                CategoryName=x.CategoryName,
                SubCategoryName=x.SubCategoryName
                
            }).ToList();

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.SubCategories = _subCategoryService.GetSubCategories();
            ViewBag.Categories= _categoryService.GetCategories();
            return View("form",new PostFormViewModel());
        }
        [HttpPost]
        public IActionResult Save(PostFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SubCategories = _subCategoryService.GetSubCategories();
                ViewBag.Categories = _categoryService.GetCategories();
                return View("form", formData);
            }


            var fileName = formData.File.FileName;
            var folderPath = Path.Combine("images", "posts");
            var wwwRootFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            var wwwRootFilePath = Path.Combine(wwwRootFolderPath, fileName);

            Directory.CreateDirectory(wwwRootFolderPath);

            using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
            {
                formData.File.CopyTo(fileStream);
            }


          
            if (formData.Id == 0)
            {
                var postDto = new PostDto()
                {
                    Id = formData.Id,
                    Title = formData.Title,
                    Content = formData.Content,
                    Summary = formData.Summary,
                    ImagePath = fileName,
                    SubCategoryId = formData.SubCategoryId,
                    CategoryId = formData.CategoryId,


                };
                var responce = _postService.AddPost(postDto);

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
               var postDto = new PostDto()
                {
                    Id = formData.Id,
                    Title = formData.Title,
                    Content = formData.Content,
                    Summary = formData.Summary,
                    SubCategoryId = formData.SubCategoryId,
                    CategoryId = formData.CategoryId,


                };
                if (formData.File!=null)
                    postDto.ImagePath = fileName;
               
                _postService.EditPost(postDto);
            }
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.SubCategories = _subCategoryService.GetSubCategories();
            ViewBag.Categories = _categoryService.GetCategories();
            var post = _postService.GetPostById(id);
            var viewModel = new PostFormViewModel()
            {
                Id=post.Id,
                Title = post.Title,
                Summary = post.Summary,
                Content = post.Content,
                SubCategoryId = post.SubCategoryId,
                CategoryId = post.CategoryId
            };

            ViewBag.Image = post.ImagePath;
            return View("form",viewModel);
        }
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("index");
        }

        
    }
}
