// https://www.youtube.com/watch?v=GZDQptTQZsk
// https://stackoverflow.com/questions/30095689/set-background-color-depending-on-data-bound-value
using EstudosAvancadosXamarin.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.ViewModels
{
    
    class ProductsViewModel : BaseViewModel
    {
        Product selectedProduct;
        readonly List<Product> products;
        public Command OpenCartCommand { get; }
        private Cart cart;
        string itensInCart;
        public ProductsViewModel()
        {
            cart = new Cart();
            OpenCartCommand = new Command(async () => await OpenCart(), () => !IsBusy);
        }

        public List<Product> Products
        {
            get => Product.AvailableProducts();
        }

        async Task OpenCart()
        {
            await Navigation.PushAsync<CartViewModel>(false);
        }

        async Task OpenProductDescription()
        {
            await Navigation.PushAsync<ProductDescriptionViewModel>(false, SelectedProduct, Cart);
        }

        public Cart Cart
        {
            get => cart;
            set
            {
                cart = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ItensInCart));
            }
        }

        public string ItensInCart
        {
            get => itensInCart;
            set
            {
                if(cart != null && cart.Products != null)
                {
                    itensInCart = cart.Products.Count + " Produto(s)";
                }
                else
                {
                    itensInCart = "Carrinho vazio";
                }
                OnPropertyChanged();
            }
        }
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
                OpenProductDescription();
            }
        }
        private bool _busy = false;
        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                OnPropertyChanged();
                OpenCartCommand.ChangeCanExecute();
                OnPropertyChanged(nameof(Cart));
            }
        }
    }
}
