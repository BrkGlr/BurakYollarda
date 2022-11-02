using BurakYollarda.Business.Types;
using BurakYollarda.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Business.Services
{
    public interface IPostService
    {
        ServiceMessage AddPost(PostDto post);
        List<PostDto> GetPosts(int? categoryId=null,int? subCategoryId=null);
        PostDto GetPostById(int id);
        void EditPost(PostDto post);
        void DeletePost(int id);
    }
}
