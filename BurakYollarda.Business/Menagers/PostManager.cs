using BurakYollarda.Business.Services;
using BurakYollarda.Business.Types;
using BurakYollarda.Data.Dto;
using BurakYollarda.Data.Entities;
using BurakYollarda.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Business.Menagers
{
    public class PostManager:IPostService
    {
        private readonly IRepository<PostEntity> _postRepository;
        public PostManager(IRepository<PostEntity> postRepository)
        {
            _postRepository = postRepository;
        }

        public ServiceMessage AddPost(PostDto post)
        {
            var hasPost=_postRepository.GetAll(x=>x.Title.ToLower() == post.Title.ToLower()).ToList();

            if (hasPost.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu İsimde Bir Post Mevcut"
                };
            }

            var postEntity = new PostEntity()
            {
                Id = post.Id,
                Title = post.Title,
                Summary=post.Summary,
                Content=post.Content,
                ImagePath=post.ImagePath,
                SubCategoryId=post.SubCategoryId,
                CategoryId=post.CategoryId
            };

            _postRepository.Add(postEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeletePost(int id)
        {
            _postRepository.Delete(id);
        }

        public void EditPost(PostDto post)
        {

            var postEntity = _postRepository.GetById(post.Id);
            postEntity.Title=post.Title;
            postEntity.Summary=post.Summary;
            postEntity.Content=post.Content;
            postEntity.SubCategoryId = post.SubCategoryId;
            postEntity.CategoryId = post.CategoryId;

            if (post.ImagePath!=null)
             postEntity.ImagePath = post.ImagePath;
            

            _postRepository.Update(postEntity);
        }

        public PostDto GetPostById(int id)
        {
            var postEntity = _postRepository.GetById(id);
            var postDto = new PostDto
            {
                Id=postEntity.Id,
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Content = postEntity.Content,
                ImagePath = postEntity.ImagePath,
                SubCategoryId = postEntity.SubCategoryId,
                CategoryId = postEntity.CategoryId

            };
            return postDto;
        }

        public List<PostDto> GetPosts(int? categoryId=null,int? subCategoryId=null)
        {
            var query = _postRepository.GetAll();
          
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);

            }
            if (subCategoryId.HasValue)
            {
                query = query.Where(x => x.SubCategoryId == subCategoryId.Value);

            }
            var postEntities = query.OrderBy(x => x.Title);
            var postList = postEntities.Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Summary = x.Summary,
                ImagePath = x.ImagePath,
                SubCategoryId = x.SubCategoryId,
                CategoryId = x.CategoryId,
                SubCategoryName = x.SubCategory.Name,
                CategoryName = x.Category.Name
            }).ToList();
            return postList;
            
        }
    }
}
