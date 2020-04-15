using System;
using System.Drawing;
using System.Drawing.Imaging;
using static FinalFantasyXThunderBoltDodger.NativeFunctions;

namespace FinalFantasyXThunderBoltDodger
{
    internal static class ColorChecker
    {
        public static int GetLuminance(Point location)
        {
            return GetLuminance(GetColorAt(location));
        }

        private static int GetLuminance(Color color)
        {
            var argb = color.ToArgb();
            int luminance = (77 * ((argb >> 16) & 255)
                + 150 * ((argb >> 8) & 255)
                + 29 * ((argb) & 255)) >> 8;
            return luminance;
        }

        private static Color GetColorAt(Point location)
        {
            var screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    var hSrcDC = gsrc.GetHdc();
                    var hDC = gdest.GetHdc();
                    var retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }
    }
}
