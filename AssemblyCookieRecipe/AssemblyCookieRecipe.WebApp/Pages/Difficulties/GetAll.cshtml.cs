using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Difficulties
{
    public class GetAllModel : PageModel
    {
        private readonly IDifficultieService _difficultieService;

        public GetAllModel(IDifficultieService difficultieService)
        {
            _difficultieService = difficultieService;
        }

        public List<Difficultie> Difficulties = new List<Difficultie>();
        public void OnGet()
        {
            Difficulties = _difficultieService.GetAll();
        }
        public IActionResult OnPost()
        {
            Difficultie difficultie = new Difficultie();
            difficultie.Name = Convert.ToString(Request.Form["name"]);

            _difficultieService.Presist(difficultie);

            return Redirect("/Difficulties/GetAll");
        }
    }
}
