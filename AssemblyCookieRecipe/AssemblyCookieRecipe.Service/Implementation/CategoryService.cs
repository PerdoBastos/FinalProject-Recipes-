using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Category Presist(Category category)
        {
            return _repository.Presist(category);
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
    }
}
