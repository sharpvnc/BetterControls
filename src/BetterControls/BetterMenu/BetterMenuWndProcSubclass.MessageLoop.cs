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

using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Used to intercept the message loop of the source control of a menu when opened.
    /// </summary>
    partial class BetterMenuWndProcSubclass
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="m"><inheritdoc/></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_MENUSELECT:
                    if (WmMenuSelect(ref m))
                        return;

                    break;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles the WM_MENUSELECT message.
        /// </summary>
        private protected virtual bool WmMenuSelect(ref Message m)
        {
            // If the menu item is a popup item (i.e. it has sub-items) then the data sent
            // with WM_MENUSELECT to identify which menu was selected differs than any other
            // menu item. An index to the popup item is sent instead of command identifier.
            int identifier = NativeMethods.Util.LOWORD(m.WParam);
            int flags = NativeMethods.Util.HIWORD(m.WParam);

            if ((flags & NativeMethods.MF_POPUP) != 0)
            {
                // The item that was selected has sub-items; therefore, we have to identify
                // it recursively using the internal menu tree.
                BetterMenuItem item = GetMenuItemByIndex(m.LParam, identifier);

                if (item is BetterMenuButton button)
                    button.ItemFocused();
            }
            else
            {
                // The item that was selected does not have any sub-items; therefore, we can
                // identify it using its command identifier.
                GlobalCommand globalCommand = GlobalCommand.GetCommandExecutor(identifier);

                if (globalCommand != null && globalCommand.CommandExecutor is BetterMenuReference menuReference && menuReference.Menu is BetterMenuButton button)
                    button.ItemFocused();
            }

            return false;
        }
    }
}