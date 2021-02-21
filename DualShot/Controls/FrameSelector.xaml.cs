using DualShot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DualShot.Controls
{
    /// <summary>
    /// Interaction logic for FrameSelector.xaml
    /// </summary>
    public partial class FrameSelector : UserControl
    {
        public FrameSelector()
        {
            InitializeComponent();
            DataContext = new Image { Source = new BitmapImage(new Uri("/DualShot;component/Images/Icons/DSi/Black.png", UriKind.Relative)) };           
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(FrameType), typeof(FrameSelector),
            new PropertyMetadata(new FrameType(ConsoleType.DSi, "Black"), ValuePropertyChanged));

        public FrameType Value
        {
            get => GetValue(ValueProperty) as FrameType;
            set => SetValue(ValueProperty, value);
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as FrameSelector).ValueChanged?.Invoke(d);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var srcpath = (ComboBox.SelectedItem as ComboBoxItem).Tag;
            if (srcpath == null) return;
            (DataContext as Image).Source = new BitmapImage(new Uri(srcpath as string, UriKind.Relative));            
            Value = FrameType.FromString((ComboBox.SelectedItem as ComboBoxItem).Name);
        }

        public delegate void OnValueChanged(object o);
        public event OnValueChanged ValueChanged;
    }
}
