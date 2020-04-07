using SchoolTemplate.ViewModels;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace SchoolTemplate.Views{
    public partial class StudentCollectionView : UserControl {
        public StudentCollectionView() {
            InitializeComponent();
        }
    }


    public class con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            if(value is StudentCollectionViewModel)
                return ((StudentCollectionViewModel)value);


            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
