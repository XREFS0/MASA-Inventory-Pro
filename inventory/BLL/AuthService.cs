using inventory.DAL;
using inventory.Models;

namespace inventory.BLL
{
    public class AuthService
    {
        private UserRepository _userRepository = new UserRepository();

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            return _userRepository.Login(username, password);
        }

        public bool Register(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return false;

            return _userRepository.Register(user);
        }
    }
}
