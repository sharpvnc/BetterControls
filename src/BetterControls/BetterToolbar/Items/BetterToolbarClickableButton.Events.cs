using System;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item that is a clickable button.
    /// </summary>
    partial class BetterToolbarClickableButton
    {
        /// <summary>
        /// This method is raised when the toolbar button is clicked.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnClick(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Click?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised when the toolbar button is clicked.
        /// </summary>
        public event EventHandler<EventArgs> Click;
    }
}