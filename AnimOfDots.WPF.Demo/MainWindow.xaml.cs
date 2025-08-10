using System;
using System.Windows;

namespace AnimOfDots.WPF.Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StartButton_Click(this, null);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Start animations
            StartAnimations();

            // Update the checkbox without triggering its change event
            RunningCheckBox.Checked -= RunningCheckBox_Changed;
            RunningCheckBox.Unchecked -= RunningCheckBox_Changed;
            RunningCheckBox.IsChecked = true;
            RunningCheckBox.Checked += RunningCheckBox_Changed;
            RunningCheckBox.Unchecked += RunningCheckBox_Changed;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            // Stop animations
            StopAnimations();

            // Update the checkbox without triggering its change event
            RunningCheckBox.Checked -= RunningCheckBox_Changed;
            RunningCheckBox.Unchecked -= RunningCheckBox_Changed;
            RunningCheckBox.IsChecked = false;
            RunningCheckBox.Checked += RunningCheckBox_Changed;
            RunningCheckBox.Unchecked += RunningCheckBox_Changed;
        }

        private void RunningCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (RunningCheckBox.IsChecked == true)
            {
                StartAnimations();
            } else
            {
                StopAnimations();
            }
        }

        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int speed = (int)e.NewValue;
            SetPropertyForAllControls(control => control.AnimationSpeed = speed);
        }

        private void HideOnStopCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            bool hideOnStop = HideOnStopCheckBox.IsChecked == true;
            SetPropertyForAllControls(control => control.HideOnStop = hideOnStop);
        }

        private void StartAnimations()
        {
            SetPropertyForAllControls(control => control.Running = true);
        }

        private void StopAnimations()
        {
            SetPropertyForAllControls(control => control.Running = false);
        }

        // Helper method to set properties on all animation controls
        private void SetPropertyForAllControls(Action<dynamic> propertyAction)
        {
            var controls = new dynamic[]
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

            foreach (var control in controls)
            {
                if (control != null)
                    propertyAction(control);
            }
        }
    }
}