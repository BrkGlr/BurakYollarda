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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;

        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceMessage AddCategory(CategoryDto category)
        {
            var hasCategory = _categoryRepository.GetAll(x => x.Name.ToLower() == category.Name.ToLower()).ToList();
            if (hasCategory.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu Kategori Mevcut."
                };
            }
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };

            _categoryRepository.Add(categoryEntity);
            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public void EditCategory(CategoryDto category)
        {
            var categoryEntity = _categoryRepository.GetById(category.Id);

            categoryEntity.Name = category.Name;
           

            _categoryRepository.Update(categoryEntity);
        }

        public List<CategoryDto> GetCategories()
        {
            var categoryEntities = _categoryRepository.GetAll().OrderBy(x=>x.Name);

            var categoryList = categoryEntities.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return categoryList;
        }

        public CategoryDto GetCategoryById(int id)
        {

            var categoryEntity = _categoryRepository.GetById(id);

            var categoryDto = new CategoryDto
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name
                
            };

            return categoryDto;
        }
    }
}
