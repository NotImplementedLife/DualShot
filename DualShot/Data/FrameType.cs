using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DualShot.Data
{
    public class FrameType
    {
        public FrameType(ConsoleType consoleType,string color)
        {
            ConsoleType = consoleType;
            Color = color;
        }

        public ConsoleType ConsoleType;
        public string Color;

        public static FrameType FromString(string str)
        {
            var parts = str.Split('_');
            if (parts.Length != 2) return new FrameType(ConsoleType.DSi, "Black");
            return new FrameType((ConsoleType)Enum.Parse(typeof(ConsoleType), parts[0]), parts[1]);
        }

        public override string ToString()
        {
            return Color + " " + ConsoleType.ToString();
        }

        public BitmapImage Frame
        {
            get => Frames.Data[ConsoleType.ToString()][Color];
        }

        public Int32Rect TopScreenRect
        {
            get => ScreenCoords.Data[ConsoleType.ToString()][Color][0];
        }

        public Int32Rect BottomScreenRect
        {
            get => ScreenCoords.Data[ConsoleType.ToString()][Color][1];
        }
    }
}
