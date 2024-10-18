using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.Service.Implementation
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _repository;
        public MeasureService(IMeasureRepository measureRepository)
        {
            _repository = measureRepository;
        }
        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public List<Measure> GetAll()
        {
            return _repository.GetAll();
        }

        public Measure GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Measure Presist(Measure measure)
        {
            return _repository.Presist(measure);
        }

        public Measure Update(Measure measure)
        {
            return _repository.Update(measure);
        }
    }
}
