using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Difficulties
{
    public class GetModel : PageModel
    {
        private readonly IDifficultieService _difficultieService;

        public GetModel(IDifficultieService difficultieService)
        {
            _difficultieService = difficultieService;
        }

        public Difficultie Difficultie { get; set; }
        public void OnGet(int id)
        {
            Difficultie = _difficultieService.GetById(id);
        }
        public IActionResult OnPost()
        {
            return Redirect("/Difficulties/GetAll");
        }
    }
}
