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
    /// Wrapper of the Windows Toolbar classes.
    /// </summary>
    partial class BetterToolbar
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="m"><inheritdoc/></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_COMMAND + NativeMethods.WM_REFLECT:
                    if (WmReflectCommand(ref m))
                        return;

                    break;
                case NativeMethods.WM_NOTIFY:
                    if (WmNotify(ref m))
                        return;

                    break;
                case NativeMethods.WM_NOTIFY + NativeMethods.WM_REFLECT:
                    if (WmReflectNotify(ref m))
                        return;

                    break;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles the WM_COMMAND + WM_REFLECT message.
        /// </summary>
        private protected virtual bool WmReflectCommand(ref Message m)
        {
            int index = NativeMethods.Util.LOWORD(m.WParam);

            if (Items[index] is BetterToolbarClickableButton button)
                button.PerformClick();

            ResetMouseEventArgs();

            return false;
        }

        ///// <summary>
        ///// Handles the WM_MENUSELECT message.
        ///// </summary>
        //private protected virtual bool WmMenuSelect(ref Message m)
        //{
        //    // If the menu item is a popup item (i.e. it has sub-items) then the data sent
        //    // with WM_MENUSELECT to identify which menu was selected differs than any other
        //    // menu item. An index to the popup item is sent instead of command identifier.
        //    int identifier = NativeMethods.Util.LOWORD(m.WParam);
        //    int flags = NativeMethods.Util.HIWORD(m.WParam);

        //    if ((flags & NativeMethods.MF_POPUP) != 0)
        //    {
        //        // The item that was selected has sub-items; therefore, we have to identify
        //        // it recursively using the internal menu tree.
        //        BetterMenuItem item = GetMenuItemByIndex(m.LParam, identifier);

        //        if (item is BetterMenuButton button)
        //            button.ItemFocused();
        //    }
        //    else
        //    {
        //        // The item that was selected does not have any sub-items; therefore, we can
        //        // identify it using its command identifier.
        //        GlobalCommand globalCommand = GlobalCommand.GetCommandExecutor(identifier);

        //        if (globalCommand != null && globalCommand.CommandExecutor is BetterMenuReference menuReference && menuReference.Menu is BetterMenuButton button)
        //            button.ItemFocused();
        //    }

        //    return false;
        //}

        /// <summary>
        /// Handles the WM_NOTIFY message.
        /// </summary>
        private protected virtual bool WmNotify(ref Message m) => WmReflectNotify(ref m);

        /// <summary>
        /// Handles the WM_NOTIFY + WM_REFLECT message.
        /// </summary>
        private protected virtual unsafe bool WmReflectNotify(ref Message m)
        {
            NativeMethods.NMHDR* note = (NativeMethods.NMHDR*)m.LParam;

            switch (note->code)
            {
                case NativeMethods.TBN_QUERYINSERT:
                    m.Result = (IntPtr)1;
                    break;

                case NativeMethods.TBN_DROPDOWN:
                    TbnDropDown(ref m);
                    break;
                case NativeMethods.TTN_NEEDTEXTA:
                    TtnNeedTextA(ref m);
                    m.Result = (IntPtr)1;
                    break;

                case NativeMethods.TTN_NEEDTEXTW:
                    if (Marshal.SystemDefaultCharSize == 2)
                    {
                        TtnNeedTextW(ref m);
                        m.Result = (IntPtr)1;
                    }
                    break;
                case NativeMethods.TBN_HOTITEMCHANGE:
                    TbnHotItemChange(ref m);
                    break;
                case NativeMethods.NM_CUSTOMDRAW:
                    if (!AutoSizeItems)
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, 0, NativeMethods.Util.MAKELPARAM(0, ItemHeight));

                    return true;
            }

            return false;
        }

        /// <summary>
        /// Handles the TBN_DROPDOWN message within the WM_NOTIFY and WM_NOTIFY + WM_REFLECT messages.
        /// </summary>
        private protected virtual bool TbnDropDown(ref Message m)
        {
            NativeMethods.NMTOOLBAR note = (NativeMethods.NMTOOLBAR)m.GetLParam(typeof(NativeMethods.NMTOOLBAR));

            BetterToolbarItem item = Items.GetItemByUniqueIdentifier(note.iItem);

            if (item != null && item is BetterToolbarDropDownButton button)
                PerformDropDown(button, false);

            return false;
        }

        /// <summary>
        /// Handles the TTN_NEEDTEXTA message within the WM_NOTIFY and WM_NOTIFY + WM_REFLECT messages.
        /// </summary>
        private protected virtual bool TtnNeedTextA(ref Message m) => TtnNeedTextW(ref m);

        /// <summary>
        /// Handles the TTN_NEEDTEXTW message within the WM_NOTIFY and WM_NOTIFY + WM_REFLECT messages.
        /// </summary>
        private protected virtual bool TtnNeedTextW(ref Message m)
        {
            NativeMethods.TOOLTIPTEXT toolTipText = (NativeMethods.TOOLTIPTEXT)m.GetLParam(typeof(NativeMethods.TOOLTIPTEXT));

            BetterToolbarItem item = Items.GetItemByUniqueIdentifier((int)toolTipText.hdr.idFrom);

            // Only items that are buttons (i.e. not a separator) are capable
            // of showing tool tips.
            if (item != null && item is BetterToolbarButton button)
            {
                toolTipText.hinst = IntPtr.Zero;

                if (button.ToolTipText != null)
                    toolTipText.lpszText = GetToolTipText(button);

                if (string.IsNullOrEmpty(toolTipText.lpszText))
                    toolTipText.lpszText = null;

                if (RightToLeft == RightToLeft.Yes)
                    toolTipText.uFlags |= NativeMethods.TTF_RTLREADING;

                Marshal.StructureToPtr(toolTipText, m.LParam, false);
            }

            return false;
        }

        /// <summary>
        /// Handles the TBN_HOTITEMCHANGE message within the WM_NOTIFY and WM_NOTIFY + WM_REFLECT messages.
        /// </summary>
        private protected virtual bool TbnHotItemChange(ref Message m)
        {
            // Should we set the hot item?
            NativeMethods.NMTBHOTITEM nmTbHotItem = (NativeMethods.NMTBHOTITEM)m.GetLParam(typeof(NativeMethods.NMTBHOTITEM));

            BetterToolbarItem item = Items.GetItemByUniqueIdentifier(nmTbHotItem.idNew);

            if (item != null && item is BetterToolbarButton button)
            {
                if (NativeMethods.HICF_ENTERING == (nmTbHotItem.dwFlags & NativeMethods.HICF_ENTERING))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_LEAVING == (nmTbHotItem.dwFlags & NativeMethods.HICF_LEAVING))
                {
                    _hotButton = null;
                }
                else if (NativeMethods.HICF_MOUSE == (nmTbHotItem.dwFlags & NativeMethods.HICF_MOUSE))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_ARROWKEYS == (nmTbHotItem.dwFlags & NativeMethods.HICF_ARROWKEYS))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_ACCELERATOR == (nmTbHotItem.dwFlags & NativeMethods.HICF_ACCELERATOR))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_DUPACCEL == (nmTbHotItem.dwFlags & NativeMethods.HICF_DUPACCEL))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_RESELECT == (nmTbHotItem.dwFlags & NativeMethods.HICF_RESELECT))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_LMOUSE == (nmTbHotItem.dwFlags & NativeMethods.HICF_LMOUSE))
                {
                    _hotButton = button;
                }
                else if (NativeMethods.HICF_TOGGLEDROPDOWN == (nmTbHotItem.dwFlags & NativeMethods.HICF_TOGGLEDROPDOWN))
                {
                    _hotButton = button;
                }
            }

            return false;
        }
    }
}