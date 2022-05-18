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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BetterControls.Collections
{
    /// <summary>
    /// Extend from this class to create an element collection of the specified type.
    /// </summary>
    /// <typeparam name="TElementType">The type that this collection should contain.</typeparam>
    public abstract partial class ElementCollection<TElementType> : ElementCollectionBase
        where TElementType : CollectionElement
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ElementCollection{TElementType}"/>.
        /// </summary>
        protected ElementCollection() { }

        /// <summary>
        /// Initialize a new instance of <see cref="ElementCollection{TElementType}"/>.
        /// </summary>
        /// <param name="ownerElement">The owner element as an instance of <see cref="IElement"/>.</param>
        protected ElementCollection(IElement ownerElement)
            : base(ownerElement)
        { }

        private List<TElementType> _collection = new List<TElementType>();

        /// <summary>
        /// Gets or sets a <typeparamref name="TElementType"/> in the collection at the specified index.
        /// </summary>
        /// <param name="index">The index to get or set a <typeparamref name="TElementType"/>.</param>
        /// <returns>The <typeparamref name="TElementType"/> at the specified index.</returns>
        public virtual TElementType this[int index]
        {
            get => Collection[index];
            set
            {
                TElementType inner = Collection[index];
                TElementType element = value;

                if (inner == element)
                {
                    return;
                }

                TElementType item1 = this[index];
                TElementType item2 = value;

                Collection[index] = element;

                PerformCollectionChanged(ElementCollectionChangeType.Remove, index, item1);
                PerformCollectionChanged(ElementCollectionChangeType.Add, index, item2);
            }
        }

        /// <summary>
        /// Gets the underlying collection of <typeparamref name="TElementType"/>.
        /// </summary>
        [Browsable(false)]
        protected virtual IList<TElementType> Collection => _collection;

        /// <summary>
        /// Gets the number of <typeparamref name="TElementType"/> in the collection.
        /// </summary>
        public virtual int Count => Collection.Count;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual bool IsReadOnly => false;

        /// <summary>
        /// Adds a new <typeparamref name="TElementType"/> to the collection.
        /// </summary>
        /// <param name="item">The item to add as an instance of <typeparamref name="TElementType"/>.</param>
        public virtual void Add(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            AddRange(item);
        }

        /// <summary>
        /// Adds one ore more new <typeparamref name="TElementType"/> to the collection.
        /// </summary>
        /// <param name="items">One ore more items to add as instances of <typeparamref name="TElementType"/>.</param>
        public virtual void AddRange(params TElementType[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            InsertRange(Count, items);
        }

        /// <summary>
        /// Clears all <typeparamref name="TElementType"/> from the collection.
        /// </summary>
        public virtual void Clear()
        {
            if (Collection.Count == 0)
            {
                return;
            }

            for (int i = 0; i < Count;)
                Remove(this[i]);
        }

        /// <summary>
        /// Determines whether a <typeparamref name="TElementType"/> exists in the collection.
        /// </summary>
        /// <param name="item">The item to determine existence as an instance of <typeparamref name="TElementType"/>.</param>
        /// <returns>A <see cref="bool"/> value indicating whether or not the <typeparamref name="TElementType"/> exists.</returns>
        public virtual bool Contains(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return Collection.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection of <typeparamref name="TElementType"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The <typeparamref name="TElementType"/> array to copy the entire collection of <typeparamref name="TElementType"/> to.</param>
        /// <param name="index">The starting index of the target array.</param>
        public virtual void CopyTo(TElementType[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Collection.CopyTo(array, index);
        }

        /// <summary>
        /// Removes the specified <typeparamref name="TElementType"/> from the collection.
        /// </summary>
        /// <param name="item">The item to remove as an instance of <typeparamref name="TElementType"/>.</param>
        /// <returns>A <see cref="bool"/> value indicating whether or not the operation was successful.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual bool Remove(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            int index = IndexOf(item);

            bool result = Collection.Remove(item);

            PerformCollectionChanged(ElementCollectionChangeType.Remove, index, new TElementType[]
            {
                item
            });

            return result;
        }

        /// <summary>
        /// Removes the <typeparamref name="TElementType"/> at the specified index from the collection.
        /// </summary>
        /// <param name="index">The index of the element from which to remove from the collection.</param>
        public virtual void RemoveAt(int index)
        {
            TElementType item = this[index];

            Collection.RemoveAt(index);

            PerformCollectionChanged(ElementCollectionChangeType.Remove, index, new TElementType[]
            {
                item
            });
        }

        /// <summary>
        /// Gets the index of the specified <typeparamref name="TElementType"/>.
        /// </summary>
        /// <param name="item">The <typeparamref name="TElementType"/> to get the index of.</param>
        /// <returns>The index of the specified <typeparamref name="TElementType"/>.</returns>
        public virtual int IndexOf(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return Collection.IndexOf(item);
        }

        /// <summary>
        /// Inserts a <typeparamref name="TElementType"/> at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert the <typeparamref name="TElementType"/>.</param>
        /// <param name="item">The item to insert as an instance of <typeparamref name="TElementType"/>.</param>
        public virtual void Insert(int index, TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            InsertRange(index, item);
        }

        /// <summary>
        /// Inserts one or more <typeparamref name="TElementType"/> at the specified index.
        /// </summary>
        /// <param name="index">The index at which to insert one or more <typeparamref name="TElementType"/>.</param>
        /// <param name="items">One ore more items to insert as instances of <typeparamref name="TElementType"/>.</param>
        public virtual void InsertRange(int index, params TElementType[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            for (int i = 0, j = index; i < items.Length; i++, j++)
            {
                TElementType item = items[i];

                Collection.Insert(j, item);
            }

            PerformCollectionChanged(ElementCollectionChangeType.Add, index, items);
        }

        /// <summary>
        /// This method is raised when the collection is changed.
        /// </summary>
        /// <param name="changeType">The way the collection was changed.</param>
        /// <param name="startIndex">The index that the items were changed at.</param>
        /// <param name="items">One or more items that were changed in the collection as instances of <typeparamref name="TElementType"/>.</param>
        private protected virtual /*TODO*/ void PerformCollectionChanged(ElementCollectionChangeType changeType, int startIndex, params TElementType[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            switch (changeType)
            {
                case ElementCollectionChangeType.Add:
                    PerformItemsAdded(startIndex, items);
                    break;
                case ElementCollectionChangeType.Remove:
                    PerformItemsRemoved(startIndex, items);
                    break;
            }

            OnCollectionChanged(new ElementCollectionChangedEventArgs<TElementType>(changeType, startIndex, items));
        }

        /// <summary>
        /// This method is raised when one or more items are added to the collection.
        /// </summary>
        /// <param name="startIndex">The index that the items were added at.</param>
        /// <param name="items">One or more items that were added to the collection as instances of <typeparamref name="TElementType"/>.</param>
        private protected virtual void PerformItemsAdded(int startIndex, params TElementType[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            // The items have been added at this point. We need to
            // the owner collection and
            // index of each collection element, from the start index to the end of the collection.
            for (int i = 0; i < Count; i++)
            {
                TElementType item = this[i];

                item.OwnerElement = OwnerElement;
                item.OwnerCollection = this;
                item.SetIndex(i);
            }
        }

        /// <summary>
        /// This method is raised when one or more items are removed from the collection.
        /// </summary>
        /// <param name="startIndex">The index that the items were removed at.</param>
        /// <param name="items">One or more items that were removed from the collection as instances of <typeparamref name="TElementType"/>.</param>
        private protected virtual void PerformItemsRemoved(int startIndex, params TElementType[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            // The items have been removed at this point. We need to adjust the owner collection and
            // index of each collection element, from the start index to the end of the collection.
            for (int i = 0; i < items.Length; i++)
            {
                TElementType item = items[i];

                item.OwnerElement = null;
                item.OwnerCollection = null;
                item.ResetIndex();
            }

            for (int i = 0; i < Count; i++)
            {
                TElementType item = this[i];

                item.SetIndex(i);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public virtual IEnumerator<TElementType> GetEnumerator() => Collection.GetEnumerator();

        /// <summary>
        /// Moves the specified <typeparamref name="TElementType"/> up by one place.
        /// </summary>
        /// <param name="item">The item to move up as an instance of <see cref="CollectionElement"/>.</param>
        public void MoveUp(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.ItemIndex == 0)
                return;

            lock (this)
            {
                int currentIndex = item.ItemIndex;

                TElementType previousElement = this[currentIndex - 1];
                this[currentIndex - 1] = item;
                this[currentIndex] = previousElement;
            }
        }

        /// <summary>
        /// Moves the specified <typeparamref name="TElementType"/> down by one place.
        /// </summary>
        /// <param name="item">The item to move down as an instance of <see cref="CollectionElement"/>.</param>
        public void MoveDown(TElementType item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.ItemIndex == Count - 1)
                return;

            lock (this)
            {
                int currentIndex = item.ItemIndex;

                TElementType nextElement = this[currentIndex + 1];
                this[currentIndex + 1] = item;
                this[currentIndex] = nextElement;
            }
        }

        #region Events

        /// <summary>
        /// This method is raised when the collection is changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="ElementCollectionChangedEventArgs{TElementType}"/>.</param>
        protected virtual void OnCollectionChanged(ElementCollectionChangedEventArgs<TElementType> e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            CollectionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised when the collection is changed.
        /// </summary>
        public event EventHandler<ElementCollectionChangedEventArgs<TElementType>> CollectionChanged;

        #endregion
    }
}