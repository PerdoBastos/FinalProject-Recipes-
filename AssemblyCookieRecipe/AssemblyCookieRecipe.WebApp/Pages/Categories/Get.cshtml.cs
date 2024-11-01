using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Categories
{
    public class GetModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public GetModel(ICategoryService categoryService)
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
            return Redirect("/Categories/GetAll");
        }
    }
}
