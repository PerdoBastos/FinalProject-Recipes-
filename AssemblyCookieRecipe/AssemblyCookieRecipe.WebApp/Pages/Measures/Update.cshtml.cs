using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public UpdateModel(IMeasureService measureService)
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
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);

            _measureService.Update(measure);

            return Redirect("/Measures/GetAll");
        }
    }
}
