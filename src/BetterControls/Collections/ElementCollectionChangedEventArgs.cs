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

namespace BetterControls.Collections
{
    /// <summary>
    /// Event arguments for when an element collection is changed.
    /// </summary>
    /// <typeparam name="TElementType">The type that this collection should contain.</typeparam>
    public class ElementCollectionChangedEventArgs<TElementType> : EventArgs
        where TElementType : CollectionElement
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ElementCollectionChangedEventArgs{TElementType}"/>.
        /// </summary>
        /// <param name="changeType">The way the collection was changed.</param>
        /// <param name="startIndex">The index that the items were changed at.</param>
        /// <param name="items">One or more that were changed in the collection as instances of <typeparamref name="TElementType"/>.</param>
        public ElementCollectionChangedEventArgs(ElementCollectionChangeType changeType, int startIndex, params TElementType[] items)
        {
            ChangeType = changeType;
            StartIndex = startIndex;
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Gets the way the collection was changed.
        /// </summary>
        public ElementCollectionChangeType ChangeType { get; }

        /// <summary>
        /// Gets the index that the items were changed at.
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        /// Gets one or more that were changed in the collection as instances of <typeparamref name="TElementType"/>.
        /// </summary>
        public TElementType[] Items { get; }
    }
}