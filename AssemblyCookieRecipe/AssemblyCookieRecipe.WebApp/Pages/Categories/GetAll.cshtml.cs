using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Categories
{
    public class GetAllModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public GetAllModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public void OnGet()
        {
            Categories = _categoryService.GetAll();
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);

            _categoryService.Presist(category);

            return Redirect("/Categories/GetAll");
        }
    }
}
