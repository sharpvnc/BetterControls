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

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a menu item.
    /// </summary>
    partial class BetterMenuItem
    {
        /// <summary>
        /// Computes the native structure as an instance of <see cref="NativeMethods.MENUITEMINFO_T"/>.
        /// </summary>
        /// <returns>An instance of <see cref="NativeMethods.MENUITEMINFO_T"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual NativeMethods.MENUITEMINFO_T ComputeMenuItemInfoT()
        {
            NativeMethods.MENUITEMINFO_T structure = new NativeMethods.MENUITEMINFO_T();

            structure.fMask = NativeMethods.MIIM_ID | NativeMethods.MIIM_STATE | NativeMethods.MIIM_SUBMENU | NativeMethods.MIIM_DATA | NativeMethods.MIIM_FTYPE;
            structure.wID = UniqueIdentifier;

            if (Items.Count != 0)
            {
                bool visible = true;

                foreach (BetterMenu menu in Items)
                {
                    if (menu is BetterMenuButton menuButton && !menuButton.Visible)
                    {
                        visible = false;
                        
                        break;
                    }
                }

                if(visible)
                    structure.hSubMenu = Handle;
            }

            if (!Visible)
                structure.fState |= NativeMethods.MFS_HIDDEN;

            return structure;
        }
    }
}