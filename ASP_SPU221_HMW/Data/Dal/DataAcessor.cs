using ASP_SPU221_HMW.Data.Context;

namespace ASP_SPU221_HMW.Data.Dal
{
    public class DataAcessor
    {
        private readonly DataContext _context;
        public UserDao UserDao { get; private set; }
        public DataAcessor(DataContext context)
        {
            _context = context;
            UserDao = new(_context);
        }
    }
}
