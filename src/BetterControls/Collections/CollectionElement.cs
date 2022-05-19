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

namespace BetterControls
{
    /// <summary>
    /// Extend from this class to create an element that can be included in an <see cref="ElementCollection{TElementType}"/>
    /// </summary>
    public abstract class CollectionElement : Element
    {
        /// <summary>
        /// Initialize a new instance of <see cref="CollectionElement"/>.
        /// </summary>
        public CollectionElement() { }

        /// <summary>
        /// Initialize a new instance of <see cref="CollectionElement"/>.
        /// </summary>
        /// <param name="ownerElement">The owner element as an instance of <see cref="IElement"/>.</param>
        public CollectionElement(IElement ownerElement)
        {
            OwnerElement = ownerElement ?? throw new ArgumentNullException(nameof(ownerElement));
        }

        private int _itemIndex = -1;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Browsable(false)]
        public virtual int ItemIndex => _itemIndex;

        /// <summary>
        /// Gets the owner element as an instance of <see cref="IElement"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal IElement OwnerElement { get; internal set; }

        /// <summary>
        /// Gets the collection that owns this element as an instance of <see cref="IElementCollection"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IElementCollection OwnerCollection { get; internal set; }

        /// <summary>
        /// Removes this item from its parent collection.
        /// </summary>
        public virtual void Remove()
        {
            if (OwnerCollection != null && OwnerCollection is IElementCollection elementCollection)
                elementCollection.Remove(this);
        }

        /// <summary>
        /// Resets the index of this item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual void ResetIndex() => _itemIndex = -1;

        /// <summary>
        /// Sets the index of this item.
        /// </summary>
        /// <param name="index">The index of this item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual void SetIndex(int index) => _itemIndex = index;

        /// <summary>
        /// Moves this item up by one place in its parent collection.
        /// </summary>
        public virtual void MoveUp()
        {
            if (OwnerCollection != null)
                OwnerCollection.MoveUp(this);
        }

        /// <summary>
        /// Moves this item down by one place in its parent collection.
        /// </summary>
        public virtual void MoveDown()
        {
            if (OwnerCollection != null)
                OwnerCollection.MoveDown(this);
        }

        /// <summary>
        /// This method is raised when this item is changed, such that additional processing is required for the change, or the change needs to be reflected to the parent control.
        /// </summary>
        /// <param name="flags">Zero of more values from <see cref="CollectionElementItemChangedFlags"/> indicating any additional flags for the change.</param>
        protected virtual void PerformItemChanged(CollectionElementItemChangedFlags flags)
        {

        }
    }

    [Flags]
    public enum CollectionElementItemChangedFlags
    {
        None = 0,
        RecreateHandle = 1
    }
}