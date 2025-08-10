using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnimOfDots
{
    /// <summary>
    /// Represents a class that provides animation capabilities for controls.
    /// </summary>
    /// <remarks>The <see cref="AOD"/> class serves as a container for animation-enabled controls. It includes
    /// a nested <see cref="BaseControl"/> class, which extends the functionality of standard controls by adding support
    /// for animations. This class is designed to be used as a base for creating custom animated controls.</remarks>
    public class AOD
    {
        /// <summary>
        /// Provides a base class for controls with animation capabilities.
        /// </summary>
        /// <remarks>The <see cref="BaseControl"/> class extends the functionality of the <see
        /// cref="Control"/> class by adding support for animations. It includes properties to control animation speed,
        /// start and stop animations, and determine whether the control is hidden when the animation stops. Derived
        /// classes can override methods such as <see cref="Animate"/> and <see cref="Reset"/> to customize animation
        /// behavior.</remarks>
        public class BaseControl : Control
        {
            private Animator animator;
            private bool hideOnStop = true;

            public override string Text => "";
            public override Font Font { get => base.Font; }

            /// <summary>
            /// Gets or sets the animation speed as a percentage of the maximum speed.
            /// </summary>
            /// <remarks>The value represents the speed of the animation relative to its maximum
            /// speed. A value of 100 corresponds to the maximum speed, while a value of 0 stops the
            /// animation.</remarks>
            [Description("The animation speed in % of the max speed."), DefaultValue(50)]
            public int AnimationSpeed
            {
                get => animator.AnimationSpeed;
                set => animator.AnimationSpeed = value;
            }

            /// <summary>
            /// Gets or sets a value indicating whether the control's animation is currently running.
            /// </summary>
            /// <remarks>Setting this property to <see langword="true"/> starts the animation, while
            /// setting it to  <see langword="false"/> stops it. The default value is <see langword="false"/>.</remarks>
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

            /// <summary>
            /// Gets or sets a value indicating whether the control is hidden when the animation stops.
            /// </summary>
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

            /// <summary>
            /// Performs an animation sequence.
            /// </summary>
            protected virtual void Animate() { }

            /// <summary>
            /// Begins the animation.
            /// </summary>
            public virtual void Start()
            {
                if (!animator.Running)
                {
                    Show();
                    animator.Start(Animate);
                }
            }

            /// <summary>
            /// Stops the animation.
            /// </summary>
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

    /// <summary>
    /// Provides mathematical utility methods for common calculations.
    /// </summary>
    /// <remarks>This class contains static methods for performing mathematical operations, such as
    /// calculating percentages. All methods in this class are generic and support numeric types.</remarks>
    public static class AodMath
    {
        /// <summary>
        /// Calculates the percentage of a number.
        /// </summary>
        /// <typeparam name="T">Numeric type.</typeparam>
        /// <param name="num">The value to apply the percentage to.</param>
        /// <param name="perc">The percentage value.</param>
        /// <returns>The calculated percentage.</returns>
        public static T Percentage<T>(T num, T perc)
        {
            dynamic _num = num;
            dynamic _perc = perc;
            return (_num * _perc) / 100;
        }
    }
}