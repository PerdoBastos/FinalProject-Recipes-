using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Ingredients
{
    public class GetModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public GetModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient Ingredient { get; set; }

        public void OnGet(int id)
        {
            Ingredient = _ingredientService.GetById(id);
        }
        public IActionResult OnPost()
        {
            return Redirect("/Ingredients/GetAll");
        }
    }
}
