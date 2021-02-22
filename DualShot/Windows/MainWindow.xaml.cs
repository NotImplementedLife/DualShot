using DualShot.Controls;
using DualShot.Data;
using Microsoft.Win32;
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

namespace DualShot.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Uri BaseUri;
        public MainWindow()
        {
            InitializeComponent();
            BaseUri = BaseUriHelper.GetBaseUri(this);                       
        }

        private void FrameSelector_ValueChanged(object o)
        {
            var v = (o as FrameSelector).Value;
            FrameViewer.TopScreenRect = v.TopScreenRect;
            FrameViewer.BottomScreenRect = v.BottomScreenRect;
            FrameViewer.Frame = v.Frame;            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Frames.Init();
                Dispatcher.Invoke(() =>
                {
                    Mask.Visibility = Visibility.Collapsed;
                    FrameViewer.TopScreenRect = ScreenCoords.Data["DSi"]["Black"][0];
                    FrameViewer.BottomScreenRect = ScreenCoords.Data["DSi"]["Black"][1];
                    FrameViewer.Frame = Frames.Data["DSi"]["Black"];
                });
            });
        }

        private OpenFileDialog OFD = new OpenFileDialog
        {
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg; *.jpeg; *.png",
            Multiselect = false,
            Title = "DualShot - Import"
        };

        private SaveFileDialog SFD = new SaveFileDialog
        {
            Filter = "Image files (*.png) | *.png",
            Title="DualShot - Export"
        };

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (OFD.ShowDialog() == true) 
            {
                BitmapImage source = null;
                try
                {
                    source = new BitmapImage(new Uri(OFD.FileName, UriKind.Absolute));
                }
                catch(Exception)
                {
                    MessageBox.Show("Could not load image.");
                }
                FrameViewer.Screenshot = source;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SFD.ShowDialog() == true) 
            {
                FrameViewer.Save(SFD.FileName);
            }
        }
    }
}
