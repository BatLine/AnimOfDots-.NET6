using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots {
    /// <summary>
    /// Represents a circular animated control that rotates and displays a series of dots in a circular pattern.
    /// </summary>
    /// <remarks>The <see cref="Circular"/> control is a custom UI element that animates a rotating circular
    /// pattern. It is double-buffered to reduce flickering during animation and supports customization of its size and
    /// color. The control automatically adjusts its internal configuration when resized and updates its appearance when
    /// the <see cref="System.Windows.Forms.Control.ForeColor"/> property changes.</remarks>
    public class Circular : AOD.BaseControl {

        private Bitmap bmp;
        private readonly List<Rectangle> rectangles = new List<Rectangle>();
        private int rotation, coordination = 0, circleSize = 10, dotSize = 5;
        private Point p = new Point(0, 0);
        private readonly SolidBrush solidBrush = new SolidBrush(Color.DodgerBlue);

        /// <summary>
        /// Initializes a new instance of the <see cref="Circular"/> class.
        /// </summary>
        public Circular() {
            DoubleBuffered = true;
            AnimationSpeedBalance(40);
            Size = new Size(48, 48);
            ForeColor = Color.DodgerBlue;
        }

        protected override void Animate() {
            base.Animate();
            rotation = (rotation + 5) % 360;
            Refresh();
        }

        private void CreateEllipse() {
            using (Graphics graph = Graphics.FromImage(bmp)) {
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graph.Clear(Color.Transparent);
                graph.FillEllipse(solidBrush, new Rectangle(circleSize, circleSize, dotSize, dotSize));
            }
        }

        private void CloneRectangle() {
            for (int i = 0; i < 5; i++) {
                rectangles.Add(new Rectangle(coordination, coordination, dotSize, dotSize));
            }
        }

        private void Configration() {
            circleSize = (int)((Height - 1) / 4.1f);
            dotSize = (circleSize / 2);
        }

        private void Coordination() {
            coordination = 0;
            for (int i = Height; i >= 80; i -= 80) {
                coordination = (coordination - 1);
            }
        }

        private void RotateBitmap() {
            using (Graphics graphics = Graphics.FromImage(bmp)) {
                for (int i = 0; i < rectangles.Count; i++) {
                    graphics.TranslateTransform(rectangles[i].Left + rectangles[i].Width / 10, rectangles[i].Top + rectangles[i].Height / 10);
                    graphics.RotateTransform(rotation);
                    graphics.DrawImage(bmp, new Point(-rectangles[i].Width / 10, rectangles[i].Height / 10));
                }
            }
        }

        protected override void Reset() {
            base.Reset();
            rotation = 0;
        }

        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);
            solidBrush.Color = ForeColor;
            CreateEllipse();
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            Configration();
            Coordination();
            bmp = new Bitmap(circleSize * 2, circleSize * 2);
            rectangles.Clear();
            rectangles.Add(new Rectangle((Width) - ((Width / 2) + (AodMath.Percentage<int>(Width, 5))), (Height) - ((Height / 2) + AodMath.Percentage<int>(Height, 5)), bmp.Width, bmp.Height));
            CloneRectangle();
            CreateEllipse();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            for (int i = 0; i < rectangles.Count; i++) {
                e.Graphics.TranslateTransform(rectangles[i].Left + rectangles[i].Width / 10, rectangles[i].Top + rectangles[i].Height / 10);
                e.Graphics.RotateTransform(rotation);
                p.X = -rectangles[i].Width / 10;
                p.Y = rectangles[i].Height / 10;
                e.Graphics.DrawImage(bmp, p);
            }
        }
    }
}
