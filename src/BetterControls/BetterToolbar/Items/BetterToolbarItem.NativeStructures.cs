/* COPYRIGHT NOTICE

MIT License

Copyright (c) 2022 SharpVNC Limited

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

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