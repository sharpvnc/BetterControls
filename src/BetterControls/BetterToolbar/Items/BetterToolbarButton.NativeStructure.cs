using System.Runtime.InteropServices;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item that is a button.
    /// </summary>
    partial class BetterToolbarButton
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTON ComputeTbButton()
        {
            NativeMethods.TBBUTTON structure = base.ComputeTbButton();

            structure.fsStyle |= NativeMethods.BTNS_AUTOSIZE;

            if (ShowImage)
                structure.iBitmap = ImageIndexer.ComputedIndex;
            if (Enabled)
                structure.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (Pressed)
                structure.fsState |= NativeMethods.TBSTATE_PRESSED;

            structure.iString = _stringIndex = OwnerToolbar.AddString(Text);

            return structure;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.TBBUTTONINFO ComputeTbButtonInfo()
        {
            NativeMethods.TBBUTTONINFO structure = base.ComputeTbButtonInfo();

            structure.dwMask |= NativeMethods.TBIF_IMAGE | NativeMethods.TBIF_STATE | NativeMethods.TBIF_STYLE;

            if (ShowImage)
                structure.iImage = ImageIndexer.ComputedIndex;
            if (Enabled)
                structure.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (Pressed)
                structure.fsState |= NativeMethods.TBSTATE_PRESSED;

            structure.dwMask |= NativeMethods.TBIF_TEXT;

            structure.pszText = Marshal.StringToHGlobalAuto(Text);

            _previousText = Text;

            return structure;
        }
    }
}