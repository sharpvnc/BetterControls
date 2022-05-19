namespace BetterControls
{
    /// <summary>
    /// Represents a toolbar separator.
    /// </summary>
    partial class BetterToolbarSeparator
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTON ComputeTbButton()
        {
            NativeMethods.TBBUTTON structure = base.ComputeTbButton();

            structure.fsStyle |= NativeMethods.TBSTYLE_SEP;

            return structure;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTONINFO ComputeTbButtonInfo()
        {
            NativeMethods.TBBUTTONINFO structure = base.ComputeTbButtonInfo();

            structure.fsStyle |= NativeMethods.TBSTYLE_SEP;

            return structure;
        }
    }
}