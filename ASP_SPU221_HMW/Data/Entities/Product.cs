namespace ASP_SPU221_HMW.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public Boolean IsActive { get; set; } = true;
        public Double Price { get; set; }
    }
}
