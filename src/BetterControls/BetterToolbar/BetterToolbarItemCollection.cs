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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace BetterControls
{
    /// <summary>
    /// Represents a collection of <see cref="BetterToolbarItem"/>.
    /// </summary>
    [Editor("BetterToolbarItemCollectionEditor", typeof(UITypeEditor))]
    public class BetterToolbarItemCollection : ElementCollection<BetterToolbarItem>, IEnumerable
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarItemCollection"/>.
        /// </summary>
        /// <param name="ownerToolbar">The parent toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        internal BetterToolbarItemCollection(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        {
            _uniqueIdentifierItems = new Dictionary<int, BetterToolbarItem>();
        }

        private Dictionary<int, BetterToolbarItem> _uniqueIdentifierItems;

        /// <summary>
        /// Gets the owner toolbar as an instance of <see cref="BetterToolbar"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected BetterToolbar OwnerToolbar
        {
            get
            {
                if (OwnerElement != null)
                    return (BetterToolbar)OwnerElement;

                return null;
            }
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterToolbarPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public virtual void Add(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterToolbarPushButton()
            {
                Text = text
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterToolbarPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public virtual void Add(string text, string description)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterToolbarPushButton()
            {
                Text = text,
                Description = description
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterToolbarPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public virtual void Add(string text, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterToolbarPushButton()
            {
                Text = text,
                ImageIndex = imageIndex
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterToolbarPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public virtual void Add(string text, string description, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterToolbarPushButton()
            {
                Text = text,
                Description = description,
                ImageIndex = imageIndex
            });
        }

        /// <summary>
        /// Gets a <see cref="BetterToolbarItem"/> from the collection by its identifier.
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier of the item to get.</param>
        /// <returns>The <see cref="BetterToolbarItem"/> with the specified unique identifier.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BetterToolbarItem GetItemByUniqueIdentifier(int uniqueIdentifier)
        {
            if (_uniqueIdentifierItems.ContainsKey(uniqueIdentifier))
                return _uniqueIdentifierItems[uniqueIdentifier];

            return null;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="startIndex"><inheritdoc/></param>
        /// <param name="items"><inheritdoc/></param>
        private protected override void PerformItemsAdded(int startIndex, params BetterToolbarItem[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            base.PerformItemsAdded(startIndex, items);

            for (int i = 0, j = Count - 1; i < items.Length; i++, j++)
            {
                BetterToolbarItem item = items[i];

                item.SetUniqueIdentifier(item.ItemIndex);

                _uniqueIdentifierItems.Add(item.UniqueIdentifier, item);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="startIndex"><inheritdoc/></param>
        /// <param name="items"><inheritdoc/></param>
        private protected override void PerformItemsRemoved(int startIndex, params BetterToolbarItem[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            base.PerformItemsRemoved(startIndex, items);

            for (int i = 0; i < items.Length; i++)
            {
                BetterToolbarItem item = items[i];

                _uniqueIdentifierItems.Remove(item.UniqueIdentifier);

                item.ResetUniqueIdentifier();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="e"><inheritdoc/></param>
        protected override void OnCollectionChanged(ElementCollectionChangedEventArgs<BetterToolbarItem> e)
        {
            OwnerToolbar?.PerformItemsCollectionChanged(e.ChangeType, e.StartIndex, e.Items);

            base.OnCollectionChanged(e);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}