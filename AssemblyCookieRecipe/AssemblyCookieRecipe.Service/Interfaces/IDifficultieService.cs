using AssemblyCookieRecipe.Model;

namespace AssemblyCookieRecipe.Service.Interfaces
{
    public interface IDifficultieService
    {
        Difficultie Presist(Difficultie difficultie);
        List<Difficultie> GetAll();
        Difficultie GetById(int id);
        Difficultie Update(Difficultie difficultie);
        void DeleteById(int id);
    }
}
