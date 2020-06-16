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
        public Command ClearCartCommand { get; }

        private Cart cart;
        string itensInCart;
        public ProductsViewModel()
        {
            cart = new Cart();
            itensInCart = "Carrinho Vazio";
            OpenCartCommand = new Command(async () => await OpenCart(), () => !IsBusy);
            ClearCartCommand = new Command(async() => await ClearCart());
            Title = "Produtos Disponiveis";
            MessagingCenter.Subscribe<ProductDescriptionViewModel>(this, "updateCart", (arg) =>
            {
                if (cart == null || cart.Products == null || cart.Products.Count == 0)
                {
                    ItensInCart = "Carrinho vazio";
                }
                else
                {
                    ItensInCart = cart.Products.Count + " Produto(s)";
                }
                OnPropertyChanged(nameof(Cart));
            });
        }
        
        public List<Product> Products
        {
            get => Product.AvailableProducts();
        }

        async Task OpenCart()
        {
            if(cart == null || cart.Products == null)
            {
                return;
            }
            await Navigation.PushAsync<CartViewModel>(false, Cart);
        }
        async Task ClearCart()
        {
            bool confirmation = await Application.Current.MainPage.DisplayAlert("Aviso", "Deseja realmente limpar o carrinho de compras?", "Sim", "Nãoi");
            if (!confirmation)
            {
                return;
            }
            Cart = new Cart();
            OnPropertyChanged(nameof(Cart));
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
                if (cart == null || cart.Products == null || cart.Products.Count == 0)
                {
                    ItensInCart = "Carrinho vazio";
                }
                else
                {
                    ItensInCart = cart.Products.Count + " Produto(s)";
                }
                OnPropertyChanged(nameof(ItensInCart));
            }
        }

        public string ItensInCart
        {
            get => itensInCart;
            set
            {
                itensInCart = value;
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
                if(selectedProduct != null)
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
