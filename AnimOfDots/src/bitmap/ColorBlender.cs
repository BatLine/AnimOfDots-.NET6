using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnimOfDots
{
    public sealed class ColorBlender
    {
        private const int angle = 360;
        private readonly ColorBlend colorBlend;

        public ColorBlender(Color[] colors, float[] positions)
        {
            colorBlend = new ColorBlend(colors.Length) { Colors = colors, Positions = positions };
        }

        public Bitmap BlendBitmap(Bitmap bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(rectangle, Color.Transparent, Color.Transparent, angle))
                {
                    gradientBrush.InterpolationColors = colorBlend;
                    graphics.FillRectangle(gradientBrush, rectangle);
                }
            }
            return bitmap;
        }
    }
}