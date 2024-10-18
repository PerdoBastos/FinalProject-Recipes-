using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.Service.Implementation
{
    //O que é
    public class IngredientService : IIngredientService
    {
        //O que tem
        private readonly IIngredientRepository _repository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _repository = ingredientRepository;
        }
        //O que faz
        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public List<Ingredient> GetAll()
        {
            return _repository.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Ingredient Presist(Ingredient ingredient)
        {
            return _repository.Presist(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _repository.Update(ingredient);
        }
    }
}
