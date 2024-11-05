using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IDifficultieService _difficultieService;

        public DeleteModel(IDifficultieService difficultieService)
        {
            _difficultieService = difficultieService;
        }

        public IActionResult OnGet(int id)
        {
            _difficultieService.DeleteById(id);
            return Redirect("/Difficulties/GetAll");
        }
    }
}
