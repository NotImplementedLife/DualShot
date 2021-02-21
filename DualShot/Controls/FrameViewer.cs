using DualShot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DualShot.Controls
{
    public class FrameViewer : Canvas
    {
        public FrameViewer()
        {                       
            SetLeft(FrameImage, 0);
            SetTop(FrameImage, 0);
            Children.Add(FrameImage);

            SetLeft(TopScreenImage, 0);
            SetTop(TopScreenImage, 0);
            Children.Add(TopScreenImage);

            SetLeft(BottomScreenImage, 0);
            SetTop(BottomScreenImage, 0);
            Children.Add(BottomScreenImage);

            TopScreenImage.Background = Brushes.Red;
            BottomScreenImage.Background = Brushes.Blue;
        }

        public Int32Rect TopScreenRect = new Int32Rect(0, 0, 1, 1);
        public Int32Rect BottomScreenRect = new Int32Rect(0, 0, 1, 1);

        public Image FrameImage = new Image();
        /*public Image TopScreenImage    = new Image();
        public Image BottomScreenImage = new Image();*/
        public Canvas TopScreenImage = new Canvas();
        public Canvas BottomScreenImage = new Canvas();

        public static DependencyProperty FrameProperty = DependencyProperty.Register("Frame", typeof(BitmapImage), typeof(FrameViewer),
            new PropertyMetadata(null, FramePropertyChanged));

        public BitmapImage Frame
        {
            get => GetValue(FrameProperty) as BitmapImage;
            set => SetValue(FrameProperty, value);
        }

        private static void FramePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var o = d as FrameViewer;
            var i = e.NewValue as BitmapSource;
            o.FrameImage.Source = i;
            o.Width = o.FrameImage.Width = i.PixelWidth;
            o.Height = o.FrameImage.Height = i.PixelHeight;

            SetLeft(o.TopScreenImage, o.TopScreenRect.X);
            SetTop(o.TopScreenImage, o.TopScreenRect.Y);
            o.TopScreenImage.Width = o.TopScreenRect.Width;
            o.TopScreenImage.Height = o.TopScreenRect.Height;

            SetLeft(o.BottomScreenImage, o.BottomScreenRect.X);
            SetTop(o.BottomScreenImage, o.BottomScreenRect.Y);
            o.BottomScreenImage.Width = o.BottomScreenRect.Width;
            o.BottomScreenImage.Height = o.BottomScreenRect.Height;
        }

        /*public static DependencyProperty ScreenshotProperty = DependencyProperty.Register("Screenshot", typeof(BitmapImage), typeof(FrameViewer),
            new PropertyMetadata(null, ScreenshotPropertyChanged);

        private static void ScreenshotPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var o = d as FrameViewer;
            var ss = e.NewValue as BitmapImage;
            if(ss==null)
            {

            }
        }*/
    }
}
