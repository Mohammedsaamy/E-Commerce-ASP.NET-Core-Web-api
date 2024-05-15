// CategoryService class
using AutoMapper;
using DTOs.Display;
using Repository.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public List<GetAllCategories> GetAll()
        {
            var Categories = categoryRepository.GetAll().Select(
                c => new GetAllCategories
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                }).ToList();
            return Categories;
        }
    }
}
