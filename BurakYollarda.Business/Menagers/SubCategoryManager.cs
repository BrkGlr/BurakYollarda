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
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly IRepository<SubCategoryEntity> _subCategoryRepository;
        public SubCategoryManager(IRepository<SubCategoryEntity> subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public ServiceMessage AddSubCategory(SubCategoryDto subCategory)
        {
            var hasSubCategory = _subCategoryRepository.GetAll(x => x.Name.ToLower() == subCategory.Name.ToLower()).ToList();

            if (hasSubCategory.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu Alt Kategori Mevcut"
                };
            }
            var subCategoryEntity = new SubCategoryEntity()
            {
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId
            };

            _subCategoryRepository.Add(subCategoryEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteSubCategory(int id)
        {
            _subCategoryRepository.Delete(id);
        }

        public void EditSubCategory(SubCategoryDto subCategory)
        {
            var subCategoryEntity = _subCategoryRepository.GetById(subCategory.Id);
            subCategoryEntity.Name=subCategory.Name;
            subCategoryEntity.CategoryId=subCategory.CategoryId;
            _subCategoryRepository.Update(subCategoryEntity);
        }

        public List<SubCategoryDto> GetSubCategories(int? categoryId=null)
        {
            var query = _subCategoryRepository.GetAll();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            var subCategoryEntities = query.OrderBy(x => x.Category.Name);
            var subCategoryList = subCategoryEntities.Select(x => new SubCategoryDto
            {
                Id=x.Id,
                Name=x.Name,
                CategoryId=x.CategoryId,
                CategoryName=x.Category.Name
            }).ToList();
            return subCategoryList;
        }

        public SubCategoryDto GetSubCategoryById(int id)
        {
            var subCategoryEntity=_subCategoryRepository.GetById(id);
            var subCategoryDto=new SubCategoryDto
            {
                Id = subCategoryEntity.Id,
                Name = subCategoryEntity.Name,
                CategoryId = subCategoryEntity.CategoryId,
               
            };
            return subCategoryDto;
        }
    }
}
