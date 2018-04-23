using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Globalization;

namespace DemoNavBar {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }
    }

    public class LerpConverter : MarkupExtension, IValueConverter {
        public double Offset { get; set; }
        public double Scale { get; set; }

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double val;
            if (value is bool)
                val = ((bool)value) ? 1.0f : 0.0f;
            else
                val = (double)value;
            return Offset + Scale * val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
