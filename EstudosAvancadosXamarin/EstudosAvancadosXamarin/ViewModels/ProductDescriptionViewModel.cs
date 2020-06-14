using EstudosAvancadosXamarin.Models;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.ViewModels
{
    class ProductDescriptionViewModel : BaseViewModel
    {
        readonly Product selectedProduct;
        Command AddProductToCartCommand { get; }
        bool isBusy = false;

        public ProductDescriptionViewModel(Product selectedProduct)
        {
            this.selectedProduct = selectedProduct;
            AddProductToCartCommand = new Command(AddProductToCart, () => IsBusy);
        }

        private void AddProductToCart()
        {

        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                AddProductToCartCommand.ChangeCanExecute();
            }
        }

        public string Name => selectedProduct.Name;
        public int Quantity => selectedProduct.Quantity;
        public decimal Price => selectedProduct.Price;
        public int Id => selectedProduct.Id;
    }
}
