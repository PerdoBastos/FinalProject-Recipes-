using AssemblyCookieRecipe.Model;

namespace AssemblyCookieRecipe.Service.Interfaces
{
    public interface IIngredientService
    {
        Ingredient Presist(Ingredient ingredient);
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        Ingredient Update(Ingredient ingredient);
        void DeleteById(int id);
    }
}
