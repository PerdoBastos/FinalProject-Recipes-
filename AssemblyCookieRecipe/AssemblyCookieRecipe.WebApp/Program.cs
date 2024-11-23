using AssemblyCookieRecipe.Repository.Implementation;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Implementation;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IIngredientRepository, IngredientRepository>();
            builder.Services.AddSingleton<IIngredientService, IngredientService>();

            builder.Services.AddSingleton<IMeasureRepository, MeasureRepository>();
            builder.Services.AddSingleton<IMeasureService, MeasureService>();

            builder.Services.AddSingleton<IDifficultieRepository, DifficultieRepository>();
            builder.Services.AddSingleton<IDifficultieService, DifficultieService>();

            builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            builder.Services.AddSingleton<ICategoryService, CategoryService>();

            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IUserService, UserService>();
            
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
