using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var button = parameter as Button;

            if ((bool?)value == null && button.Text == "Busy")
                return Color.Red;
            else if ((bool?)value == true && button.Text == "Available")
                return Color.YellowGreen;
            else if ((bool?)value == false && button.Text == "Away")
                return Color.Orange;
            else
                return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
