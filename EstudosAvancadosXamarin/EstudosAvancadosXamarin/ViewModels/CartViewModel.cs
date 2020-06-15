using EstudosAvancadosXamarin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EstudosAvancadosXamarin.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        readonly Cart cart;
        public CartViewModel(Cart cart)
        {
            this.cart = cart;
        }

        public int ItemQuantity
        {
            get => cart.Products.Count;
        }
        public string Id
        {
            get => cart.Id.ToString();
            
        }
        public decimal TotalValue
        {
            get => cart.TotalValue;
            set
            {
                cart.TotalValue = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CartItem> CartItens
        {
            get => cart.Products;
            set
            {
                cart.Products = value;
                OnPropertyChanged();
            }
        }
    }
}
