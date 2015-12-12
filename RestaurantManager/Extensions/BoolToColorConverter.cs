using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Extensions
{
    public class BoolToColorConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty TrueColorProperty =
            DependencyProperty.Register("TrucColor", typeof(Color), typeof(BoolToColorConverter), null);

        public Color TrueColor
        {
            get { return (Color)GetValue(TrueColorProperty); }
            set { SetValue(TrueColorProperty, value); }
        }

        public static readonly DependencyProperty FalseColorProperty =
            DependencyProperty.Register("FalseColor", typeof(Color), typeof(BoolToColorConverter), null);

        public Color FalseColor
        {
            get { return (Color)GetValue(FalseColorProperty); }
            set { SetValue(FalseColorProperty, value); }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
                return (bool)value ? TrueColor : FalseColor;
            else
                return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public BoolToColorConverter()
        {
            TrueColor = Colors.Green;
            FalseColor = Colors.Red;
        }
    }
}
