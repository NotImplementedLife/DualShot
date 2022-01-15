using DualShot.Data;
using System;
using System.Collections.Generic;
using System.IO;
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

            //TopScreenImage.Background = Brushes.Red;
            //BottomScreenImage.Background = Brushes.Blue;
        }

        public Int32Rect TopScreenRect = new Int32Rect(0, 0, 1, 1);
        public Int32Rect BottomScreenRect = new Int32Rect(0, 0, 1, 1);

        public Image FrameImage = new Image();
        public Image TopScreenImage = new Image { Stretch = Stretch.Fill };
        public Image BottomScreenImage = new Image { Stretch = Stretch.Fill };
        //public Canvas TopScreenImage = new Canvas();
        //public Canvas BottomScreenImage = new Canvas();

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

        public static DependencyProperty ScreenshotProperty = DependencyProperty.Register("Screenshot", typeof(BitmapImage), typeof(FrameViewer),
            new PropertyMetadata(null, ScreenshotPropertyChanged));

        public BitmapImage Screenshot
        {
            get => GetValue(ScreenshotProperty) as BitmapImage;
            set => SetValue(ScreenshotProperty, value);
        }

        private static void ScreenshotPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var o = d as FrameViewer;
            var ss = e.NewValue as BitmapImage;
            if (ss == null)
            {
                o.TopScreenImage = null;
                o.BottomScreenImage = null;
                return;
            }
            if(ss.Height==1)
            {
                o.TopScreenImage = null;
                o.BottomScreenImage = null;
                return;
            }
            var cnv = new Canvas { Width = (int)ss.Width, Height = (int)(ss.Height / 2) };
            var img = new Image { Source = ss };
            cnv.Children.Add(img);
            SetLeft(img, 0);
            SetTop(img, 0);
            cnv.Measure(new Size(cnv.Width, cnv.Height));
            cnv.Arrange(new Rect(new Size(cnv.Width, cnv.Height)));
            var topHalf = new RenderTargetBitmap((int)cnv.Width, (int)cnv.Height, 96, 96, PixelFormats.Pbgra32);
            topHalf.Render(cnv);
            SetTop(img, -cnv.Height);
            cnv.Measure(new Size(cnv.Width, cnv.Height));
            cnv.Arrange(new Rect(new Size(cnv.Width, cnv.Height)));
            var bottomHalf = new RenderTargetBitmap((int)cnv.Width, (int)cnv.Height, 96, 96, PixelFormats.Pbgra32);
            bottomHalf.Render(cnv);
            o.TopScreenImage.Source = topHalf;
            o.BottomScreenImage.Source = bottomHalf;
        }

        public void Save(string filename)
        {
            RenderTargetBitmap result = new RenderTargetBitmap((int)Width, (int)Height, 96, 96, PixelFormats.Pbgra32);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(this);
                ctx.DrawRectangle(vb, null, new Rect(new Point(), new Size((int)Width,(int)Height)));
            }
            result.Render(dv);
                        
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(result));
            using (var file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
}
