using EstudosAvancadosXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstudosAvancadosXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = new ProductsViewModel();
        }
    }
}