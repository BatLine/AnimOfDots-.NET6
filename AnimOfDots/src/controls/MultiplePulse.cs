using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots {
    /// <summary>
    /// Represents a control that displays multiple animated pulsing dots, with customizable size and opacity
    /// transitions.
    /// </summary>
    /// <remarks>The <see cref="MultiplePulse"/> control is designed to provide a visually appealing animation
    /// of pulsing dots. The animation dynamically adjusts the size and opacity of the dots based on the control's
    /// dimensions and foreground color. This control is double-buffered to reduce flickering during
    /// rendering.</remarks>
    public class MultiplePulse : AOD.BaseControl {
        private readonly SolidBrush[] brushes = new[] {
            new SolidBrush(Color.DodgerBlue),
            new SolidBrush(Color.DodgerBlue),
            new SolidBrush(Color.DodgerBlue),
            new SolidBrush(Color.DodgerBlue)
        };
        private readonly RectangleF[] rects = new RectangleF[4];
        private readonly byte[] colorAlpha = new byte[4] { 255, 255, 255, 255 };
        private readonly byte[] colorOpacity = new byte[3];
        private readonly float[] dotSize = new float[4];
        private float sizeChangeInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePulse"/> class.
        /// </summary>
        public MultiplePulse() {
            DoubleBuffered = true;
            AnimationSpeedBalance(40);
            Size = new Size(48, 48);
        }

        protected override void Animate() {
            base.Animate();

            float h = Height;
            for (int i = 0; i < dotSize.Length - 1; i++) {
                dotSize[i] = (dotSize[i] + sizeChangeInterval) % h;
            }
            for (int i = 0; i < colorOpacity.Length; i++) {
                byte opacity = (byte)((colorOpacity[i] + 5) % 256);

                colorOpacity[i] = opacity;
                colorAlpha[i] = (byte)(255 - opacity);
            }

            float halfW = Width / 2f;
            float halfH = h / 2f;
            Color foreColor = ForeColor;
            for (int i = 0; i < rects.Length; i++)
            {
                float size = dotSize[i];
                rects[i] = new RectangleF(halfW - size / 2f, halfH - size / 2f, size, size);
                brushes[i].Color = Color.FromArgb(colorAlpha[i], foreColor);
            }
            Invalidate();
        }

        private void UpdateDotsSize() {
            float h = Height;
            dotSize[0] = h - (h / 3f);
            dotSize[1] = h / 2f;
            dotSize[2] = h / 3f;
            dotSize[3] = h * 0.1f;
        }

        private void UpdateDotsOpacity() {
            colorOpacity[0] = ((255 - (255 / 3))) - 1;
            colorOpacity[1] = (255 / 2) - 1;
            colorOpacity[2] = (255 / 3) - 1;
        }

        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);
            for (int i = 0; i < brushes.Length; i++)
            {
                brushes[i].Color = Color.FromArgb(colorAlpha[i], ForeColor);
            }
            Invalidate();
        }

        protected override void Reset() {
            base.Reset();
            UpdateDotsSize();
            UpdateDotsOpacity();

            for (int i = 0; i < colorOpacity.Length; i++)
            {
                colorAlpha[i] = (byte)(255 - colorOpacity[i]);
            }
            for (int i = 0; i < brushes.Length; i++)
            {
                brushes[i].Color = Color.FromArgb(colorAlpha[i], ForeColor);
            }

            sizeChangeInterval = Height / (256.0f / 5.0f);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            Reset();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            for (int i = 0; i < rects.Length; i++) {
                e.Graphics.FillEllipse(brushes[i], rects[i]);
            }
        }
    }
}
