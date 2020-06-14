using EstudosAvancadosXamarin.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EstudosAvancadosXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _titlePage;
        public string TitlePage
        {
            get { return _titlePage; }
            set
            {
                OnPropertyChanged();
            }
        }

        public virtual Task LoadAsync(object[] args) => Task.FromResult(true);

        public virtual Task LoadAsync() => Task.FromResult(true);

        protected NavigationService Navigation => NavigationService.Current;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
