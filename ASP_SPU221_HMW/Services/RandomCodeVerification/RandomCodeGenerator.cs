using System;

namespace ASP_SPU221_HMW.Services.Hash
{
    public class RandomCodeGenerator : IRandCodeService
    {
        private readonly Random _random;

        public RandomCodeGenerator()
        {
            _random = new Random();
        }

        public string Digest()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
