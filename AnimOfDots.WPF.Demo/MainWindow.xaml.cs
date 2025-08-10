using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AnimOfDots.WPF.Demo
{
    public partial class MainWindow : Window
    {
        private IEnumerable<dynamic> Spinners => new dynamic[]
        {
            CircularControl,
            ColorfulCircularControl,
            DotFlashingControl,
            DotGridFlashingControl,
            DotScalingControl,
            DotTypingControl,
            DoubleDotSpinControl,
            MultiplePulseControl,
            OverlayControl,
            PulseControl
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (dynamic host in Spinners)
            {
                host.Spinner.Start();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (dynamic host in Spinners)
            {
                host.Spinner.Stop();
            }
        }

        private void RunningCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            bool running = RunningCheckBox.IsChecked == true;
            foreach (dynamic host in Spinners)
            {
                host.Running = running;
            }
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int speed = (int)e.NewValue;
            foreach (dynamic host in Spinners.Where(x => x != null))
            {
                host.AnimationSpeed = speed;
            }
        }

        private void HideOnStopCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            bool hide = HideOnStopCheckBox.IsChecked == true;
            foreach (dynamic host in Spinners)
            {
                host.HideOnStop = hide;
            }
        }
    }
}