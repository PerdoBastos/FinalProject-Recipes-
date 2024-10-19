using AssemblyCookieRecipe.Model;
using AssemblyCookieRecipe.Repository.Interfaces;
using AssemblyCookieRecipe.Service.Interfaces;

namespace AssemblyCookieRecipe.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteById(int id)
        {
            _userRepository.DeleteById(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Presist(User user)
        {
            return _userRepository.Presist(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
