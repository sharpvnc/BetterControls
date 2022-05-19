namespace BetterControls
{
    /// <summary>
    /// Represents a toolbar item that is a toggle button.
    /// </summary>
    partial class BetterToolbarToggleButton
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTON ComputeTbButton()
        {
            NativeMethods.TBBUTTON button = base.ComputeTbButton();

            button.fsStyle = NativeMethods.TBSTYLE_CHECK | 0x0010;

            return button;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTONINFO ComputeTbButtonInfo()
        {
            NativeMethods.TBBUTTONINFO button = base.ComputeTbButtonInfo();

            button.fsStyle = NativeMethods.TBSTYLE_CHECK | 0x0010;

            return button;
        }
    }
}