using System.Windows.Forms.Integration;

namespace AnimOfDots.WPF
{
    /// <summary>
    /// Hosts a WinForms AnimOfDots spinner for use in WPF applications.
    /// </summary>
    /// <typeparam name="TSpinner">Spinner control type from AnimOfDots library.</typeparam>
    public class AnimOfDotsHost<TSpinner> : WindowsFormsHost
        where TSpinner : AnimOfDots.AOD.BaseControl, new()
    {
        private readonly TSpinner spinner = new TSpinner();

        public AnimOfDotsHost()
        {
            Child = spinner;
        }

        /// <summary>Gets the underlying WinForms spinner control.</summary>
        public TSpinner Spinner => spinner;

        public int AnimationSpeed
        {
            get => spinner.AnimationSpeed;
            set => spinner.AnimationSpeed = value;
        }

        public bool Running
        {
            get => spinner.Running;
            set => spinner.Running = value;
        }

        public bool HideOnStop
        {
            get => spinner.HideOnStop;
            set => spinner.HideOnStop = value;
        }
    }
}