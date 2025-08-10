using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots {
    public class MultiplePulse : AOD.BaseControl {

        private readonly SolidBrush solidBrush = new SolidBrush(Color.DodgerBlue);
        private readonly RectangleF[] rects = new RectangleF[4];
        private readonly byte[] colorAlpha = new byte[4] { 255, 255, 255, 255 };
        private readonly byte[] colorOpacity = new byte[3];
        private readonly float[] dotSize = new float[4];
        private float sizeChangeInterval;

        public MultiplePulse() {
            DoubleBuffered = true;
            AnimationSpeedBalance(40);
            Size = new Size(48, 48);
        }

        protected override void Animate() {
            base.Animate();
            for (int i = 0; i < dotSize.Length - 1; i++) {
                dotSize[i] = (dotSize[i] + sizeChangeInterval) % Height;
            }
            for (int i = 0; i < colorOpacity.Length; i++) {
                colorOpacity[i] = (byte)((colorOpacity[i] + 5) % 256);
                colorAlpha[i] = (byte)(255 - colorOpacity[i]);
            }
            Refresh();
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

        private void UpdateRectangles() {
            float w = Width / 2f;
            float h = Height / 2f;
            for (int i = 0; i < rects.Length; i++) {
                rects[i].X = w - (dotSize[i] / 2f);
                rects[i].Y = h - (dotSize[i] / 2f);
                rects[i].Width = dotSize[i];
                rects[i].Height = dotSize[i];
            }
        }

        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);
            solidBrush.Color = ForeColor;
            Refresh();
        }

        protected override void Reset() {
            base.Reset();
            UpdateDotsSize();
            UpdateDotsOpacity();
            sizeChangeInterval = Height / (256.0f / 5.0f);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            Reset();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            UpdateRectangles();
            for (int i = 0; i < rects.Length; i++) {
                solidBrush.Color = Color.FromArgb(colorAlpha[i], ForeColor);
                e.Graphics.FillEllipse(solidBrush, rects[i]);
            }
        }
    }
}
