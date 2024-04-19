namespace ASP_SPU221_HMW.Services.Kdf
{
    public interface IKdfService
    {
        String GetDerivedKey(String password, String salt);
    }
}
