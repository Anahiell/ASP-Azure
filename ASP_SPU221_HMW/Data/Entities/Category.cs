namespace ASP_SPU221_HMW.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Slug { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public Boolean IsActive { get; set; } = true;
    }
}
