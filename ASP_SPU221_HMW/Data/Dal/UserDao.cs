using ASP_SPU221_HMW.Data.Context;
using ASP_SPU221_HMW.Data.Entities;
using ASP_SPU221_HMW.Services.Kdf;

namespace ASP_SPU221_HMW.Data.Dal
{
    public class UserDao
    {
        private readonly DataContext _context;
        private readonly IKdfService _kdfService;
        private readonly Object _dbLocker;
        public UserDao(DataContext context, IKdfService kdfService, object dbLocker)
        {
            _context = context;
            _kdfService = kdfService;
            _dbLocker = dbLocker;
        }
        public bool IsEmailFree(String email)
        {
            return ! _context
                .Users
                .Where(u=>u.Email ==email)
                .Any();
        }
        public void SignupUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User? Authenticate(String email, String password)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == email);
            if ((user != null) && (_kdfService.GetDerivedKey(password, user.Salt) == user.DerivedKey))
            {
                return user;
            }
            return null;
        }
        public User? GetUserById(String id)
        {
            User? user;
            lock (_dbLocker)
            {
                try { user = _context.Users.Find(Guid.Parse(id)); }
                catch { user = null; }
            }
            return user;
        }
    }
}
