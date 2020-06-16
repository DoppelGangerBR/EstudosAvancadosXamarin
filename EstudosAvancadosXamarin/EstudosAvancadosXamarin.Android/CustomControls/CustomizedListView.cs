using Android.Content;
using EstudosAvancadosXamarin.Customs;
using EstudosAvancadosXamarin.Droid.CustomControls;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomizedListView))]
namespace EstudosAvancadosXamarin.Droid.CustomControls
{
    class CustomizedListView : ListViewRenderer
    {
        public CustomizedListView(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
        }
    }
}