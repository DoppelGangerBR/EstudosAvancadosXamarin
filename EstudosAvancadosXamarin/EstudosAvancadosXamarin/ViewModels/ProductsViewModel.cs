//https://www.youtube.com/watch?v=GZDQptTQZsk
using EstudosAvancadosXamarin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.ViewModels
{
    class ProductsViewModel : BaseViewModel
    {
        Product selectedProduct;
        readonly List<Product> products;
        public Command OpenCartCommand { get; }
        public ProductsViewModel()
        {
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
            await Navigation.PushAsync<ProductDescriptionViewModel>(false, SelectedProduct);
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
            }
        }
    }
}
