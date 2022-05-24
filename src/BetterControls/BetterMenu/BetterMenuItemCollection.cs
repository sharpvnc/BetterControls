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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Represents a collection of <see cref="BetterMenuItem"/>.
    /// </summary>
    [Editor("BetterMenuItemCollectionEditor", typeof(UITypeEditor))]
    public class BetterMenuItemCollection : ElementCollection<BetterMenuItem>, IEnumerable
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuItemCollection"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner component as an instance of <see cref="BetterMenu"/>.</param>
        internal BetterMenuItemCollection(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }

        /// <summary>
        /// Gets the owner menu as an instance of <see cref="BetterMenu"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected BetterMenu OwnerMenu
        {
            get
            {
                if (OwnerElement != null)
                    return (BetterMenu)OwnerElement;

                return null;
            }
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        public void Add(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        public void Add(string text, string description)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public void Add(string text, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                ImageIndex = imageIndex
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public void Add(string text, string description, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description,
                ImageIndex = imageIndex
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public void Add(string text, Image image)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Image = image
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public void Add(string text, string description, Image image)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description,
                Image = image
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Shortcut = shortcut
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, string description, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description,
                Shortcut = shortcut
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, int imageIndex, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                ImageIndex = imageIndex,
                Shortcut = shortcut
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, string description, int imageIndex, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description,
                ImageIndex = imageIndex,
                Shortcut = shortcut
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, Image image, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Image = image,
                Shortcut = shortcut
            });
        }

        /// <summary>
        /// Adds a new instance of <see cref="BetterMenuPushButton"/> to the collection.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public void Add(string text, string description, Image image, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Add(new BetterMenuPushButton()
            {
                Text = text,
                Description = description,
                Image = image,
                Shortcut = shortcut
            });
        }





        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="item"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public override bool Remove(BetterMenuItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.MenuReference.Dispose();
            BetterMenu.MenuReferences.Remove(item);

            return base.Remove(item);
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