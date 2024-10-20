using AssemblyCookieRecipe.Model;

namespace AssemblyCookieRecipe.Service.Interfaces
{
    public interface ICategoryService
    {
        Category Presist(Category category);
        List<Category> GetAll();
        Category GetById(int id);
        Category Update(Category category);
        void DeleteById(int id);
    }
}
