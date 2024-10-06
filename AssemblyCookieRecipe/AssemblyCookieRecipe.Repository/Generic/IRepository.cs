namespace AssemblyCookieRecipe.Repository.Generic
{
    //CRUD
    public interface IRepository<T, ID>
    {
        T Presist(T value);
        List<T> GetAll();
        T GetById(ID id);
        T Update(T value);
        void DeleteById(ID id);
    }
}
