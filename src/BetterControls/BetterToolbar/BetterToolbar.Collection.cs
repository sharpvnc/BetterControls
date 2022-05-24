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

using BetterControls.Collections;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BetterControls
{
    partial class BetterToolbar
    {
        /// <summary>
        /// This method is raised when the items collection is changed.
        /// </summary>
        /// <param name="changeType">The way the items collection was changed.</param>
        /// <param name="startIndex">The index that the items were changed at.</param>
        /// <param name="items">One or more items that were changed in the items collection as instances of <see cref="BetterToolbarItem"/>.</param>
        internal void PerformItemsCollectionChanged(ElementCollectionChangeType changeType, int startIndex, params BetterToolbarItem[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            switch (changeType)
            {
                case ElementCollectionChangeType.Add:
                    for (int x = 0; x < items.Length;)
                        Insert(items[x++]);

                    break;
                case ElementCollectionChangeType.Remove:
                    for (int i = startIndex, x = 0; x < items.Length;)
                        Remove(i++, items[x++]);

                    break;
            }
        }

        /// <summary>
        /// Inserts the specified toolbar item to the specified position on the toolbar. This item must already be added to the collection.
        /// </summary>
        /// <param name="item">The item to insert as an instance of <see cref="BetterToolbarItem"/>.</param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private protected void Insert(BetterToolbarItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (IsHandleCreated)
            {
                NativeMethods.TBBUTTON structure = item.ComputeTbButton();
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_INSERTBUTTON, item.UniqueIdentifier, ref structure);

                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_AUTOSIZE, 0, 0);
                UpdateItemDimensions();
            }
        }

        /// <summary>
        /// Removes the specified toolbar item from the specified position on the toolbar. This item must already be removed from the collection.
        /// </summary>
        /// <param name="index">The index to remove the item from.</param>
        /// <param name="item">The item to remove as an instance of <see cref="BetterToolbarItem"/>.</param>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private protected void Remove(int index, BetterToolbarItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_DELETEBUTTON, index, 0);
        }

        /// <summary>
        /// This method is raised when one ore more items are changed.
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="items">One or more items that were changed as instances of <see cref="BetterToolbarItem"/>.</param>
        internal void PerformItemsChanged(CollectionElementItemChangedFlags flags, params BetterToolbarItem[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_AUTOSIZE, 0, 0);
            if (!AutoSizeItems)
            {
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETBUTTONSIZE, 0, NativeMethods.Util.MAKELPARAM(0, ItemHeight));
            }
            UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_AUTOSIZE, 0, 0);

            if ((flags & CollectionElementItemChangedFlags.RecreateHandle) != 0)
                RecreateHandle();
        }
    }
}