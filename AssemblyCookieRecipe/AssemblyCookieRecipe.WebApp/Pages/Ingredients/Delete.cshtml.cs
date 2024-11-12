using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public DeleteModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult OnGet(int id)
        {
            _ingredientService.DeleteById(id);
            return Redirect("/Ingredients/GetAll");
        }
    }
}
