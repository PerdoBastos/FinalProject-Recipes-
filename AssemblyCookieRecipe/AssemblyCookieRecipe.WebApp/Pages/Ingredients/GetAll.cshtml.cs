using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Ingredients
{
    public class GetAllModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public GetAllModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public void OnGet()
        {
            Ingredients = _ingredientService.GetAll();
        }

        public IActionResult OnPost()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = Convert.ToString(Request.Form["name"]);

            _ingredientService.Presist(ingredient);

            return Redirect("/Ingredients/GetAll");
        }
    }
}
