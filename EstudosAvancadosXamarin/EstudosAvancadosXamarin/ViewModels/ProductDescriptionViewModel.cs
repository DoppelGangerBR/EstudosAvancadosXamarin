using EstudosAvancadosXamarin.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.ViewModels
{
    class ProductDescriptionViewModel : BaseViewModel
    {
        readonly Product selectedProduct;
        private Command addProductToCartCommand { get; }
        public ProductDescriptionViewModel(Product selectedProduct)
        {
            this.selectedProduct = selectedProduct;
        }


        public string Name => selectedProduct.Name;
        public int Quantity => selectedProduct.Quantity;
        public decimal Price => selectedProduct.Price;
        public int Id => selectedProduct.Id;
    }
}
