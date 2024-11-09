using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultieService _difficultieService;

        public UpdateModel(IDifficultieService difficultieService)
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
            Difficultie difficultie = new Difficultie();
            difficultie.Id = Convert.ToInt32(Request.Form["id"]);
            difficultie.Name = Convert.ToString(Request.Form["name"]);

            _difficultieService.Update(difficultie);

            return Redirect("/Difficulties/GetAll");
        }
    }
}
