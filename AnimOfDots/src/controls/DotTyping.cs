using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots {
    /// <summary>
    /// Represents a control that visually simulates a "typing" animation using animated dots.
    /// </summary>
    /// <remarks>The <see cref="DotTyping"/> control displays three animated dots that simulate a typing
    /// effect. The animation is automatically handled by the control and adapts to changes in size, foreground color,
    /// and background color. The control is double-buffered to ensure smooth rendering.</remarks>
    public class DotTyping : AOD.BaseControl {
        private Bitmap bmp = new Bitmap(1, 1);
        private readonly SolidBrush solidBrush = new SolidBrush(Color.DodgerBlue);
        private readonly RectangleF[] rects = new RectangleF[3];
        private int dotSize = 24, count = 0;
        private readonly int[] rectY = new int[3] { 0, 0, 0 };

        /// <summary>
        /// Initializes a new instance of the <see cref="DotTyping"/> class.
        /// </summary>
        public DotTyping() {
            DoubleBuffered = true;
            AnimationSpeedBalance(100);
            ForeColor = Color.DodgerBlue;
            Size = new Size(64, 48);
            FillGraphic();
        }

        protected override void Animate() {
            base.Animate();
            Reset();
            switch (count) {
                case 0:
                    rectY[count] = dotSize / 2;
                    break;
                case 1:
                    rectY[count] = dotSize / 2;
                    break;
                case 2:
                    rectY[count] = dotSize / 2;
                    break;
            }
            count = (count + 1) % 10;
            FillGraphic();
        }

        /// <summary>
        /// Updates the rectangles used to draw the typing dots.
        /// </summary>
        public void UpdateRectangles() {
            rects[1] = new RectangleF((Width / 2) - (dotSize / 2), (Height / 2) - (dotSize / 2) - rectY[1], dotSize, dotSize);
            rects[0] = new RectangleF(rects[1].X - (dotSize + (dotSize / 3)), (Height / 2) - (dotSize / 2) - rectY[0], dotSize, dotSize);
            rects[2] = new RectangleF(rects[1].X + (dotSize + (dotSize / 3)), (Height / 2) - (dotSize / 2) - rectY[2], dotSize, dotSize);
        }

        private void FillGraphic() {
            UpdateRectangles();
            using (Graphics graphics = Graphics.FromImage(bmp)) {
                graphics.Clear(BackColor);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                for (int i = 0; i < rects.Length; i++) {
                    graphics.FillEllipse(solidBrush, rects[i]);
                }
            }
            Refresh();
        }

        protected override void OnBackColorChanged(EventArgs e) {
            base.OnBackColorChanged(e);
            FillGraphic();
        }

        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);
            solidBrush.Color = ForeColor;
            FillGraphic();
        }

        protected override void Reset() {
            base.Reset();
            for (int i = 0; i < rectY.Length; i++) {
                rectY[i] = 0;
            }
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            bmp = new Bitmap(Width, Height);
            dotSize = (int)((Height + 1) - (Height * 0.75f));
            FillGraphic();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
