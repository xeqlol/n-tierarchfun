using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category Category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoriesRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository _categoriesRepository, IUnitOfWork _unitOfWork)
        {
            categoriesRepository = _categoriesRepository;
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                return categoriesRepository.GetAll();
            }
            else
            {
                return categoriesRepository.GetAll().Where(x => x.Name == name);
            }
        }

        public Category GetCategory(int id)
        {
            return categoriesRepository.GetById(id);
        }

        public Category GetCategory(string name)
        {
            return categoriesRepository.GetCategoryByName(name);
        }

        public void CreateCategory(Category category)
        {
            categoriesRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
