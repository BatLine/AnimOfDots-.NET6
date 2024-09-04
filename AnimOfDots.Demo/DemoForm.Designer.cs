namespace AnimOfDots.Demo
{
    partial class DemoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            circular1 = new Circular();
            pulse1 = new Pulse();
            multiplePulse1 = new MultiplePulse();
            SuspendLayout();
            // 
            // circular1
            // 
            circular1.AnimationSpeed = 50;
            circular1.BackColor = Color.Transparent;
            circular1.ForeColor = Color.DodgerBlue;
            circular1.Location = new Point(12, 82);
            circular1.Name = "circular1";
            circular1.Size = new Size(100, 100);
            circular1.TabIndex = 0;
            // 
            // pulse1
            // 
            pulse1.AnimationSpeed = 65;
            pulse1.BackColor = Color.Transparent;
            pulse1.ForeColor = Color.DodgerBlue;
            pulse1.Location = new Point(12, 12);
            pulse1.Name = "pulse1";
            pulse1.Size = new Size(48, 48);
            pulse1.TabIndex = 1;
            // 
            // multiplePulse1
            // 
            multiplePulse1.AnimationSpeed = 50;
            multiplePulse1.BackColor = Color.Transparent;
            multiplePulse1.Location = new Point(66, 12);
            multiplePulse1.Name = "multiplePulse1";
            multiplePulse1.Size = new Size(48, 48);
            multiplePulse1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 248);
            Controls.Add(multiplePulse1);
            Controls.Add(pulse1);
            Controls.Add(circular1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Circular circular1;
        private Pulse pulse1;
        private MultiplePulse multiplePulse1;
    }
}
