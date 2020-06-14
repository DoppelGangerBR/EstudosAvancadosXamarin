using EstudosAvancadosXamarin.Models;
using System.Collections.Generic;

namespace EstudosAvancadosXamarin.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        readonly Cart cart;
        public CartViewModel(Cart cart)
        {
            this.cart = cart;
        }

    }
}
