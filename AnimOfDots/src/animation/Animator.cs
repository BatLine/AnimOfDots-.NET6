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

        /// <summary>
        /// Gets a value indicating whether the timer is currently running.
        /// </summary>
        public bool Running => timer.Enabled;

        /// <summary>
        /// Gets or sets the animation speed as a percentage of the maximum speed.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class.
        /// </summary>
        /// <param name="speedBalance">The base timer interval.</param>
        public Animator(int speedBalance)
        {
            maxValue = (speedBalance * 2) + 1;
            maxValuePlusOne = maxValue + 1;
            timer.Interval = speedBalance;
            timer.Tick += TimerTick;
        }

        /// <summary>
        /// Starts the animation loop using the provided callback.
        /// </summary>
        /// <param name="animStart">Callback invoked on each tick.</param>
        public void Start(AnimatorStart animStart)
        {
            this.animStart = animStart;
            timer.Start();
        }

        /// <summary>
        /// Stops the animation loop.
        /// </summary>
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