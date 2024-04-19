using System.Security.Cryptography;
using System.Text;

namespace ASP_SPU221_HMW.Services.Kdf
{
    public class PasswordKdfService : IKdfService
    {
        private int iterationCount = 3;
        private int dkLenght = 32;

        public string GetDerivedKey(string password, string salt)
        {
            String t1 = Convert.ToHexString(
            System.Security.Cryptography.MD5.HashData(
                    System.Text.Encoding.UTF8.GetBytes(password + salt)));
            for (int i = 1; i < iterationCount; i++)
            {
                t1 = Convert.ToHexString(
            System.Security.Cryptography.MD5.HashData(
                    System.Text.Encoding.UTF8.GetBytes(t1)));
            }
            if (t1.Length >= dkLenght)
            {
                return t1[..dkLenght];
            }
            else
            {
                char[] addon = new char[dkLenght - t1.Length];
                for (int i = 0; i < addon.Length; i++)
                {
                    addon[i] = '0';
                }
                return t1 + new String(addon);
            }
        }
      
    }
}
