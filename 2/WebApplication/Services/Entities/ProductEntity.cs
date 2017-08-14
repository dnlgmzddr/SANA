namespace WebApplication.Services.Entities
{
    public class ProductEntity : IEntity
    {
        public long ProductNumber { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public long GetKey()
        {
            return ProductNumber;
        }
    }
}