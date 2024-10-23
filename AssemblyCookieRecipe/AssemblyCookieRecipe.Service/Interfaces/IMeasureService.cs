using AssemblyCookieRecipe.Model;

namespace AssemblyCookieRecipe.Service.Interfaces
{
    public interface IMeasureService
    {
        Measure Presist(Measure measure);
        List<Measure> GetAll();
        Measure GetById(int id);
        Measure Update(Measure measure);
        void DeleteById(int id);
    }
}
