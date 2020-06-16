using EstudosAvancadosXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.ViewModels
{
    class ProductDescriptionViewModel : BaseViewModel
    {
        readonly Product selectedProduct;
        Cart cart;
        int itemQuantity = 1;
        decimal totalItemPrice = 0;
        public Command AddProductToCartCommand { get; }
        bool isBusy = false;

        public ProductDescriptionViewModel(Product selectedProduct, Cart cart)
        {
            this.selectedProduct = selectedProduct;
            this.cart = cart;
            AddProductToCartCommand = new Command(async () => await AddProductToCart(), () => !IsBusy);
            Title = "Descrição do produto";
        }

        private async Task AddProductToCart()
        {
            if(ItemQuantity <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Por favor, informe uma quantidade maior que 0", "OK");
                return;
            }
            bool confirmaInclusao = await Application.Current.MainPage.DisplayAlert("Aviso", "Tem certeza que deseja adicionar o item ao carrinho?", "Sim", "Não");
            if (!confirmaInclusao)
            {
                return;
            }
            if(cart.Products == null)
            {
                cart.Id = Guid.NewGuid();
                cart.Products = new ObservableCollection<CartItem>();
            }
            CartItem cartItem = new CartItem
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Price = selectedProduct.Price,
                Quantity = ItemQuantity,
                TotalItemPrice = TotalItemPrice
            };
            cart.Products.Add(cartItem);
            cart.TotalValue = cart.Products.Sum(c => c.TotalItemPrice);
            await Application.Current.MainPage.DisplayAlert("Aviso", "Item adicionado ao carrinho com sucesso!", "OK");
            await Navigation.PopAsync();
            MessagingCenter.Send(this, "updateCart");
        }

        private void CalculateTotalItemPrice()
        {
            TotalItemPrice = (decimal)ItemQuantity * selectedProduct.Price;
        }
        public decimal TotalItemPrice
        {
            get => totalItemPrice;
            set
            {
                totalItemPrice = value;
                OnPropertyChanged();
            }
        }
        public int ItemQuantity
        {
            get => itemQuantity;
            set
            {
                itemQuantity = value;
                OnPropertyChanged();
                CalculateTotalItemPrice();
            }
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
