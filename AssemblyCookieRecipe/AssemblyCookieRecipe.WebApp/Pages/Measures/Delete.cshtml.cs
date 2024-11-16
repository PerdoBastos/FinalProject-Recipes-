using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Measures
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public DeleteModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }
        public IActionResult OnGet(int id)
        {
            _measureService.DeleteById(id);
            return Redirect("/Measures/GetAll");
        }
    }
}
