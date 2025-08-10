using System.Drawing;

namespace AnimOfDots
{
    public sealed class ColorPalette
    {
        private readonly Bitmap bitmap;

        public ColorPalette(Size size) : this(size.Width, size.Height) { }

        public ColorPalette(int width, int height)
        {
            bitmap = new Bitmap(width, height);
        }

        public Bitmap CreateBlendedColorPalette(ColorBlender colorBlender)
        {
            return colorBlender.BlendBitmap(bitmap);
        }
    }
}