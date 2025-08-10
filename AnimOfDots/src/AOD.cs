using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots
{
    public class AOD
    {
        public class BaseControl : Control
        {
            private Animator animator;
            private bool hideOnStop = true;

            public override string Text => "";
            public override Font Font { get => base.Font; }

            [Description("The animation speed in milliseconds."), DefaultValue(50)]
            public int AnimationSpeed
            {
                get => animator.AnimationSpeed;
                set => animator.AnimationSpeed = value;
            }

            [Description("Determines whether the control's animation is running."), DefaultValue(false)]
            public bool Running
            {
                get => animator?.Running ?? false;
                set
                {
                    if ((animator?.Running ?? false) == value)
                        return;

                    if (value)
                        Start();
                    else
                        Stop();
                }
            }

            [Description("Indicates whether the control is hidden when the animation stops."), DefaultValue(true)]
            public bool HideOnStop
            {
                get => hideOnStop;
                set => hideOnStop = value;
            }

            protected BaseControl()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                BackColor = System.Drawing.Color.Transparent;
            }

            protected void AnimationSpeedBalance(int speedBalance)
            {
                animator = new Animator(speedBalance);
            }

            protected virtual void Animate() { }

            public virtual void Start()
            {
                if (!animator.Running)
                {
                    Show();
                    animator.Start(Animate);
                }
            }

            public virtual void Stop()
            {
                if (animator.Running)
                {
                    if (hideOnStop)
                        Hide();
                    animator.Stop();
                    Reset();
                }
            }

            protected virtual void Reset() { }
        }
    }

    public static class AodMath
    {
        public static T Percentage<T>(T num, T perc)
        {
            dynamic _num = num;
            dynamic _perc = perc;
            return (_num * _perc) / 100;
        }
    }
}