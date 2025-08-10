using System;
using System.Windows.Forms;

namespace AnimOfDots
{
    public sealed class Animator
    {
        private const int MAX_SPEED = 101;
        private readonly int maxValue = 0;
        private readonly int maxValuePlusOne = 0;
        private int animationSpeed = 50;
        private readonly Timer timer = new Timer();
        private AnimatorStart animStart;
        public bool Running => timer.Enabled;

        public int AnimationSpeed
        {
            get => animationSpeed;
            set
            {
                if (value < MAX_SPEED)
                {
                    animationSpeed = value;
                    timer.Interval = maxValuePlusOne - ((maxValue * value) / 100);
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Animator(int speedBalance)
        {
            maxValue = (speedBalance * 2) + 1;
            maxValuePlusOne = maxValue + 1;
            timer.Interval = speedBalance;
            timer.Tick += TimerTick;
        }

        public void Start(AnimatorStart animStart)
        {
            this.animStart = animStart;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void TimerTick(object sender, EventArgs eventArgs)
        {
            animStart();
        }
    }
}