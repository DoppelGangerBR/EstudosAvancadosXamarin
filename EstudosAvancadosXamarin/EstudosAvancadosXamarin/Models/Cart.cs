using System.Collections.Generic;

namespace EstudosAvancadosXamarin.Models
{
    class Cart
    {
        public int Id { get; set; }
        public decimal TotalValue { get; set; }
        public List<CartItem> Products { get; set; }
    }
}
