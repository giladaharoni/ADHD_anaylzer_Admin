namespace ADHD_anaylzer_Admin.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserByUserName(String username);
        void AddUser(User user);

        void RemoveUser(User user);
        void UpdateUser(User user);
        void DeleteAll();

    }
    public class UserModel : IUserRepository
    {
        private readonly myDBContext _context;

        public UserModel(myDBContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByUserName(string username)
        {
            var user = _context.Users.Where(e => e.UserName == username).FirstOrDefault();
            return user;
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            foreach (var data in _context.Users)
            {
                _context.Users.Remove(data);
            }
            _context.SaveChanges();
        }

    }
}
