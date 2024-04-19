namespace ASP_SPU221_HMW.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public String? AvatarUrl { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Registered { get; set; }
        public String Salt { get; set; } = null!;
        public String DerivedKey { get; set; } = null!;

    }
}
