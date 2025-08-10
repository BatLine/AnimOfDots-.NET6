using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnimOfDots
{
    /// <summary>
    /// Provides functionality to blend colors into a gradient and apply the gradient to a bitmap.
    /// </summary>
    /// <remarks>The <see cref="ColorBlender"/> class allows you to define a gradient using a set of colors
    /// and their corresponding positions, and then apply the gradient to a bitmap. This can be useful for creating
    /// visually appealing effects or overlays.</remarks>
    public sealed class ColorBlender
    {
        private const int angle = 360;
        private readonly ColorBlend colorBlend;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBlender"/> class with the specified colors and positions.
        /// </summary>
        /// <param name="colors">The gradient colors.</param>
        /// <param name="positions">The positions of the colors within the gradient.</param>
        public ColorBlender(Color[] colors, float[] positions)
        {
            colorBlend = new ColorBlend(colors.Length) { Colors = colors, Positions = positions };
        }

        /// <summary>
        /// Applies the configured color blend to the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to blend.</param>
        /// <returns>The blended bitmap.</returns>
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