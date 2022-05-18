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

namespace BetterControls.Collections
{
    /// <summary>
    /// Extend from this class to create an element collection of the specified type.
    /// </summary>
    partial class ElementCollection<TElementType> : IElementCollection, ICollection<TElementType>, IEnumerable<TElementType>, IEnumerable, ICollection, IList, IList<TElementType>
        where TElementType : CollectionElement
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="item"><inheritdoc/></param>
        void IElementCollection.Remove(CollectionElement item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Remove((TElementType)item);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        bool IList.IsFixedSize => false;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        bool IList.IsReadOnly => false;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (TElementType)value;
        }

        int IList.Add(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Add((TElementType)value);

            return Collection.Count - 1;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        void IList.Clear() => Clear();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        bool IList.Contains(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return Contains((TElementType)value);
        }

        int IList.IndexOf(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return IndexOf((TElementType)value);
        }

        void IList.Insert(int index, object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Insert(index, (TElementType)value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        void IList.Remove(object value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Remove((TElementType)value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        void IList.RemoveAt(int index) => RemoveAt(index);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        int ICollection.Count => Count;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        bool ICollection.IsSynchronized => false;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        object ICollection.SyncRoot => Collection;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="array"><inheritdoc/></param>
        /// <param name="index"><inheritdoc/></param>
        void ICollection.CopyTo(Array array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int index1 = index; index1 < Math.Min(array.Length, Collection.Count); ++index1)
            {
                array.SetValue((object)this[index1], index1);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="item"><inheritdoc/></param>
        void IElementCollection.MoveUp(CollectionElement item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MoveUp((TElementType)item);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="item"><inheritdoc/></param>
        void IElementCollection.MoveDown(CollectionElement item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MoveDown((TElementType)item);
        }
    }
}