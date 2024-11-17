using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Measures
{
    public class GetModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public GetModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }
        public Measure Measure {  get; set; }
        public void OnGet(int id)
        {
            Measure = _measureService.GetById(id);
        }
        public IActionResult OnPost()
        {
            return Redirect("/Measures/GetAll");
        }
    }
}
