using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _categoryService.GetById(id);
        }
        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);

            _categoryService.Update(category);

            return Redirect("/Categories/GetAll");
        }
    }
}
