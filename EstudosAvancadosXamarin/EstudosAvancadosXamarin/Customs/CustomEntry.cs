using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EstudosAvancadosXamarin.Customs
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty MaxLenghtBeforeErrorProperty =
            BindableProperty.Create(nameof(MaxLenghtBeforeError), typeof(int), typeof(CustomEntry));

        public int MaxLenghtBeforeError
        {
            get
            {
                return GetValue<int>(MaxLenghtBeforeErrorProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }
        public T GetValue<T>(BindableProperty property)
        {
            return (T)GetValue(property);
        }
        public CustomEntry()
        {

        }
    }
}
