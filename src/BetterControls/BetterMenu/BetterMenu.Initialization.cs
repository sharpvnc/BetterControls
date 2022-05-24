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

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Menu classes.
    /// </summary>
    partial class BetterMenu
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void CreateHandle()
        {
            if (!IsHandleCreated)
                _handle = UnsafeNativeMethods.CreatePopupMenu();

            base.CreateHandle();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void DestroyHandle()
        {
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.DestroyMenu(GetHandleRef());
                _handle = IntPtr.Zero;

                foreach (BetterMenuItem item in Items)
                    item.DestroyHandle();
            }

            base.DestroyHandle();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="e"><inheritdoc/></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            InitializeItems();
        }

        /// <summary>
        /// Initializes items in the menu.
        /// </summary>
        private void InitializeItems()
        {
            foreach (BetterMenuItem item in Items)
            {
                if (!item.Visible)
                    continue;

                NativeMethods.MENUITEMINFO_T structure = item.ComputeMenuItemInfoT();

                UnsafeNativeMethods.InsertMenuItem(GetHandleRef(), -1, true, structure);
            }
        }
    }
}