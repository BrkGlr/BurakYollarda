using BurakYollarda.Business.Types;
using BurakYollarda.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Business.Services
{
    public interface ISubCategoryService
    {
        ServiceMessage AddSubCategory(SubCategoryDto subCategory);
        List<SubCategoryDto> GetSubCategories(int? categoryId=null);
        SubCategoryDto GetSubCategoryById(int id);
        void EditSubCategory(SubCategoryDto subCategory);
        void DeleteSubCategory(int id);
      
    }
}
