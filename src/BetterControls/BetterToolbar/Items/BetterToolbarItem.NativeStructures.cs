using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item.
    /// </summary>
    partial class BetterToolbarItem
    {
        /// <summary>
        /// Computes the native structure as an instance of <see cref="NativeMethods.TBBUTTON"/>.
        /// </summary>
        /// <returns>An instance of <see cref="NativeMethods.TBBUTTON"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual NativeMethods.TBBUTTON ComputeTbButton()
        {
            NativeMethods.TBBUTTON structure = new NativeMethods.TBBUTTON();

            if (!Visible)
                structure.fsState |= NativeMethods.TBSTATE_HIDDEN;

            structure.idCommand = UniqueIdentifier;
            structure.dwData = (IntPtr)0;
            structure.iBitmap = NativeMethods.I_IMAGENONE;
            structure.iString = (IntPtr)(-1);

            return structure;
        }

        /// <summary>
        /// Computes the native structure as an instance of <see cref="NativeMethods.TBBUTTONINFO"/>.
        /// </summary>
        /// <returns>An instance of <see cref="NativeMethods.TBBUTTONINFO"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual NativeMethods.TBBUTTONINFO ComputeTbButtonInfo()
        {
            NativeMethods.TBBUTTONINFO structure = new NativeMethods.TBBUTTONINFO();

            structure.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBBUTTONINFO));

            if (!Visible)
                structure.fsState |= NativeMethods.TBSTATE_HIDDEN;

            structure.idCommand = UniqueIdentifier;

            // Always update the width. Lots of other changes can cause issues
            // with the width, so updating to be sure.
            structure.dwMask = NativeMethods.TBIF_SIZE;
            structure.fsState = 0;
            structure.cx = (short)ComputedWidth;

            // Set the default image. This may be overridden by a child class.
            structure.iImage = NativeMethods.I_IMAGENONE;

            return structure;
        }
    }
}