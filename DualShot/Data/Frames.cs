using DualShot.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DualShot.Data
{
    public static class Frames
    {
        public static Dictionary<string, Dictionary<string, BitmapImage>> Data = new Dictionary<string, Dictionary<string, BitmapImage>>
        {
             {
                "DSLite", new Dictionary<string, BitmapImage>
                {
                    { "EnamelNavy"  , null },
                    { "IceBlue"     , null },
                    { "JetBlack"    , null },
                    { "LimeGreen"   , null },
                    { "Pink"        , null },
                    { "PolarWhite"  , null },
                    { "Red"         , null },
                    { "RoseMetal"   , null },
                }
            },
            {
                "DSi", new Dictionary<string, BitmapImage>
                {
                    { "Black"       , null },
                    { "Blue"        , null },
                    { "MetallicBlue", null },
                    { "Pink"        , null },
                    { "Red"         , null },
                    { "White"       , null },
                }
            },
            {
                "DSiXL", new Dictionary<string, BitmapImage>
                {
                    { "DarkBrown"   , null },
                    { "Green"       , null },
                    { "MidnightBlue", null },
                    { "WineRed"     , null },
                    { "Yellow"      , null },
                }
            },
        };

        public static void Init()
        {
            foreach (var entry in Data)
            {
                var lst = new List<string>();
                foreach(var subentry in entry.Value)
                {
                    lst.Add(subentry.Key);                    
                }
                foreach(var color in lst)
                {
                    Data[entry.Key][color] = new BitmapImage();
                    Data[entry.Key][color].BeginInit();
                    Data[entry.Key][color].UriSource = new Uri(MainWindow.BaseUri, $"/DualShot;component/Images/Frames/{entry.Key}/{color}.png");
                    Data[entry.Key][color].EndInit();
                    Data[entry.Key][color].Freeze();
                }               
            }               
        }
    }
}
