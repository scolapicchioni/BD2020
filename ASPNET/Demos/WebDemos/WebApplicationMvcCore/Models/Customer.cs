namespace WebApplicationMvcCore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProductId { get; set; } //foreign_key
        public Product Product { get; set; }
    }
}
