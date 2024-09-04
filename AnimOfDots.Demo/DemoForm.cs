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
        }
    }
}
