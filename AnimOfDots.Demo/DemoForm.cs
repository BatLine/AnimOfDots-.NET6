namespace AnimOfDots.Demo
{
    public partial class DemoForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoForm"/> class.
        /// </summary>
        public DemoForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pulse1.Start();
            multiplePulse1.AnimationSpeed = 65;
            multiplePulse1.ForeColor = Color.FromArgb(255, 128, 0);
            multiplePulse1.Start();
            circular1.Start();
        }

        private void chkRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRunning.Checked)
            {
                pulse1.Start();
                multiplePulse1.Start();
            }
            else
            {
                pulse1.Stop();
                multiplePulse1.Stop();
            }

            // Other example
            circular1.Running = chkRunning.Checked;
        }
    }
}
