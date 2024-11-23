using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssemblyCookieRecipe.WebApp.Pages.Users
{
    public class GetAllModel : PageModel
    {
        private readonly IUserService _userService;

        public GetAllModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> Users = new List<User>();
        public void OnGet()
        {
            Users = _userService.GetAll();
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.IsAdmin = Convert.ToBoolean(Request.Form["isadmin"]);
            user.IsBlocked = Convert.ToBoolean(Request.Form["isblocked"]);

            _userService.Presist(user);

            return Redirect("/Users/GetAll");
        }
    }
}
