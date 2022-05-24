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

using BetterControls.Drawing;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Used to provide a mechanism for a menu button to support using both image indexes and image keys.
    /// </summary>
    public class BetterMenuButtonImageIndexer : ImageIndexer
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButtonImageIndexer"/>.
        /// </summary>
        /// <param name="ownerMenuButton">The parent toolbar item as an instance of <see cref="BetterMenuButton"/>.</param>
        public BetterMenuButtonImageIndexer(BetterMenuButton ownerMenuButton)
        {
            _ownerMenuButton = ownerMenuButton ?? throw new ArgumentNullException(nameof(ownerMenuButton));
        }

        private BetterMenuButton _ownerMenuButton;

        /// <summary>
        /// Gets the owner menu item as an instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BetterMenuButton OwnerMenuButton => _ownerMenuButton;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override ImageList ImageList
        {
            get
            {
                if (OwnerMenuButton != null)
                    return OwnerMenuButton.MenuRoot.ImageList;

                return null;
            }
        }
    }
}