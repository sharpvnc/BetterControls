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

using System.Drawing;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Represents a menu push button.
    /// </summary>
    public class BetterMenuPushButton : BetterMenuButton
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        public BetterMenuPushButton() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        public BetterMenuPushButton(string text)
            : base(text)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        public BetterMenuPushButton(string text, string description)
            : base(text, description)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public BetterMenuPushButton(string text, int imageIndex)
            : base(text, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public BetterMenuPushButton(string text, string description, int imageIndex)
            : base(text, description, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public BetterMenuPushButton(string text, Image image)
            : base(text, image)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public BetterMenuPushButton(string text, string description, Image image)
            : base(text, description, image)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, Shortcut shortcut)
            : base(text, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, string description, Shortcut shortcut)
            : base(text, description, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, int imageIndex, Shortcut shortcut)
            : base(text, imageIndex, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, string description, int imageIndex, Shortcut shortcut)
            : base(text, description, imageIndex, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, Image image, Shortcut shortcut)
            : base(text, image, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuPushButton(string text, string description, Image image, Shortcut shortcut)
            : base(text, description, image, shortcut)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuPushButton"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner menu as an instance of <see cref="BetterMenu"/>.</param>
        private protected BetterMenuPushButton(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }
    }
}