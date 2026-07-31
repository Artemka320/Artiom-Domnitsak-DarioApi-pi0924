using projeto.Models;

namespace projeto.Data
{
    public static class InMemoryDatabase
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Computador", Price = 999.99m },
            new Product { Id = 2, Name = "Teclado", Price = 45.50m }
        };

        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "123" }
        };
    }
}