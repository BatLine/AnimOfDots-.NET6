namespace AnimOfDots.Demo
{
    public partial class DemoForm : Form
    {
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
            multiplePulse2.Start();
            multiplePulse3.Start();
            multiplePulse4.Start();
            multiplePulse5.Start();
            multiplePulse6.Start();
            multiplePulse7.Start();
            multiplePulse8.Start();
            multiplePulse9.Start();
            multiplePulse10.Start();
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
