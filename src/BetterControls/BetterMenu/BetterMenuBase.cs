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

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Menu classes.
    /// </summary>
    public abstract class BetterMenuBase : HandledComponentCollectionElement
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuBase"/>.
        /// </summary>
        private protected BetterMenuBase() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuBase"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner menu as an instance of <see cref="BetterMenu"/>.</param>
        private protected BetterMenuBase(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }

        /// <summary>
        /// Gets the owner menu as an instance of <see cref="BetterMenu"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BetterMenu OwnerMenu
        {
            get
            {
                if (OwnerElement != null)
                    return (BetterMenu)OwnerElement;

                return null;
            }
        }

        /// <summary>
        /// Gets a <see cref="HandleRef"/> for the current component.
        /// </summary>
        /// <returns>An instance of <see cref="HandleRef"/>.</returns>
        protected internal virtual HandleRef GetHandleRef()
        {
            if (!IsHandleCreated)
                return default;

            return new HandleRef(this, Handle);
        }
    }
}