using ASP_SPU221_HMW.Services.Hash;

namespace ASP_SPU221_HMW.Services.Kdf
{
    public class PasswordKdfService : IKdfService
    {
        private readonly IHashService _hashService;
        private int iterationCount;
        private int dkLength;
        public PasswordKdfService(IHashService hashService)
        {
            _hashService = hashService;
            this.iterationCount = 3;
            this.dkLength = 32;
        }

        public void Config(int iterationCount, int dkLength)
        {
            this.iterationCount = iterationCount;
            this.dkLength = dkLength;
        }
        //public string GetDerivedKey(string password, string salt)
        //{
        //    String t1 = "4";
        //    return t1;
        //}
        public string GetDerivedKey(string password, string salt)
        {
            String t1 = _hashService.Digest(password + salt);
            for (int i = 1; i < iterationCount; i++)
            {
                t1 = _hashService.Digest(t1);
            }
            if (t1.Length >= dkLength)
                return t1[..dkLength];
            else
            {
                char[] addon = new char[dkLength - t1.Length];
                for (int i = 0; i < addon.Length; i++)
                {
                    addon[i] = '0';
                }
                return t1 + new String(addon);
            }
        }
    }
}
