using System.Drawing;

namespace AnimOfDots
{
    /// <summary>
    /// Represents a color palette that can be used to create and manipulate color-based graphics.
    /// </summary>
    /// <remarks>The <see cref="ColorPalette"/> class provides functionality to initialize a palette with
    /// specific dimensions and generate a blended color palette using a provided <see cref="ColorBlender"/>. This class
    /// is immutable and thread-safe, as it does not expose any mutable state.</remarks>
    public sealed class ColorPalette
    {
        private readonly Bitmap bitmap;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPalette"/> class with the specified size.
        /// </summary>
        /// <param name="size">The size of the palette.</param>
        public ColorPalette(Size size) : this(size.Width, size.Height) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPalette"/> class with the given dimensions.
        /// </summary>
        /// <param name="width">Width of the palette.</param>
        /// <param name="height">Height of the palette.</param>
        public ColorPalette(int width, int height)
        {
            bitmap = new Bitmap(width, height);
        }

        /// <summary>
        /// Creates a blended color palette using the provided color blender.
        /// </summary>
        /// <param name="colorBlender">The color blender to apply.</param>
        /// <returns>A bitmap representing the blended color palette.</returns>
        public Bitmap CreateBlendedColorPalette(ColorBlender colorBlender)
        {
            return colorBlender.BlendBitmap(bitmap);
        }
    }
}