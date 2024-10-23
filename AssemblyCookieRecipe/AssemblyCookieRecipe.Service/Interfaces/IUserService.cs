using AssemblyCookieRecipe.Model;

namespace AssemblyCookieRecipe.Service.Interfaces
{
    public interface IUserService
    {
        User Presist(User user);
        List<User> GetAll();
        User GetById(int id);
        User Update(User user);
        void DeleteById(int id);
    }
}
