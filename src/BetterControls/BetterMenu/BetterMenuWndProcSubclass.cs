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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Used to intercept the message loop of the source control of a menu when opened.
    /// </summary>
    internal partial class BetterMenuWndProcSubclass : NativeWindow
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuWndProcSubclass"/>.
        /// </summary>
        /// <param name="control">The control whose window procedure should be subclassed.</param>
        public BetterMenuWndProcSubclass(Control control)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            AssignHandle(control.Handle);
        }

        /// <summary>
        /// Gets a drop-down menu item by its index.
        /// </summary>
        /// <param name="handle">The handle of the menu.</param>
        /// <param name="index">The index of the item in the menu to get.</param>
        /// <returns>The menu item as an instance of <see cref="BetterMenuItem"/>.</returns>
        private BetterMenuItem GetMenuItemByIndex(IntPtr handle, int index)
        {
            int identifier = UnsafeNativeMethods.GetMenuItemID(new HandleRef(null, handle), index);

            if (identifier == -1)
            {
                // This menu item has sub-items. We have to recurse through the menu tree until we find an
                // item that does not have any sub-items, and then iterate back up its menu tree based on its
                // stored parent information.
                IntPtr childHandle = UnsafeNativeMethods.GetSubMenu(new HandleRef(null, handle), index);
                int childMenuCount = UnsafeNativeMethods.GetMenuItemCount(new HandleRef(null, childHandle));

                for (int i = 0; i < childMenuCount;)
                {
                    BetterMenuItem item = GetMenuItemByIndex(childHandle, i++);

                    if (item != null && item.OwnerElement != null && item.OwnerElement is BetterMenuItem parentItem)
                        return parentItem;
                }
            }
            else
            {
                // This menu item does not have any sub-items.
                GlobalCommand globalCommand = GlobalCommand.GetCommandExecutor(identifier);

                if (globalCommand != null && globalCommand.CommandExecutor is BetterMenuReference menuReference && menuReference.Menu is BetterMenuItem item)
                    return item;
            }

            return null;
        }
    }
}