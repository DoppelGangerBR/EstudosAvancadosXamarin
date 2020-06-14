using System.Collections.Generic;

namespace EstudosAvancadosXamarin.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public static List<Product> AvailableProducts()
        {
            return new List<Product>
            {
                new Product{ Id = 1, Name = "Monitor 18' LG", Quantity = 5, Price =  899.99m},
                new Product{ Id = 1, Name = "Processador AMD FX8350", Quantity = 15, Price =  399.99m},
                new Product{ Id = 1, Name = "Memoria 4GB 1666Mhz Markvision", Quantity = 1, Price =  199.99m},
                new Product{ Id = 1, Name = "Memoria 8GB 1666Mhz Markvision", Quantity = 1, Price =  399.99m},
                new Product{ Id = 1, Name = "Processador AMD Ryzen 5 3600X", Quantity = 1, Price =  1999.99m},
                new Product{ Id = 1, Name = "Placa Mãe B450M DS3P GigaBye", Quantity = 1, Price =  699.99m},
                new Product{ Id = 1, Name = "Cooler 120mm", Quantity = 15, Price =  99.99m}
            };
        }
    }
}
