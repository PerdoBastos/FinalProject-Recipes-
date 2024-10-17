using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.Service.Implementation
{
    public class DifficultieService : IDifficultieService
    {
        private readonly IDifficultieRepository _repository;
        public DifficultieService(IDifficultieRepository difficultieRepository)
        {
            _repository = difficultieRepository;
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public List<Difficultie> GetAll()
        {
            return _repository.GetAll();
        }

        public Difficultie GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Difficultie Presist(Difficultie difficultie)
        {
            return _repository.Presist(difficultie);
        }

        public Difficultie Update(Difficultie difficultie)
        {
            return _repository.Update(difficultie);
        }
    }
}
