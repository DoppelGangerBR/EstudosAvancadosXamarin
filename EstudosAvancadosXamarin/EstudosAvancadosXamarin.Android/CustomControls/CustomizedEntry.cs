using Android.Content;
using EstudosAvancadosXamarin.Customs;
using EstudosAvancadosXamarin.Droid.CustomControls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomizedEntry))]
namespace EstudosAvancadosXamarin.Droid.CustomControls
{
    class CustomizedEntry : EntryRenderer
    {
        private int maxCharacters;
        public CustomizedEntry(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                if(e.NewElement != null && e.NewElement is CustomEntry customEntry)
                {
                    maxCharacters = customEntry.MaxLenghtBeforeError;
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(Control != null)
            {
                if (e.PropertyName == "Text")
                    if (Control.Text.Length > maxCharacters)
                        Control.SetTextColor(Android.Graphics.Color.Red);
                    else
                        Control.SetTextColor(Android.Graphics.Color.Black);
            }
        }
    }
}