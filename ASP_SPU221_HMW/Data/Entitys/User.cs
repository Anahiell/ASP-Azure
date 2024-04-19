namespace ASP_SPU221_HMW.Data.Entitys
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
        public DateTime? Birthdate { get; set; }
        public DateTime? Registered { get; set; }
        public String Salt { get; set; } = null!;
        public String DerivedKey { get; set; } = null!;

    }
}
