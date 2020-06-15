using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EstudosAvancadosXamarin.Models
{
    class Cart
    {
        public Guid Id { get; set; }
        public decimal TotalValue { get; set; }
        public ObservableCollection<CartItem> Products { get; set; }
    }
}
