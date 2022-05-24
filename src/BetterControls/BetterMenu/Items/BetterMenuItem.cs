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

using BetterControls.ComponentModel;
using System.ComponentModel;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a menu item.
    /// </summary>
    public abstract partial class BetterMenuItem : BetterMenu
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuItem"/>.
        /// </summary>
        private protected BetterMenuItem() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuItem"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner menu as an instance of <see cref="BetterMenu"/>.</param>
        private protected BetterMenuItem(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }

        private bool _visible = true;

        /// <summary>
        /// Gets the displayed index of this item in the menu.
        /// </summary>
        [Browsable(false)]
        public virtual int DisplayedItemIndex => ItemIndex;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BetterMenuItemCollection Items => base.Items;

        /// <summary>
        /// Gets the collection of menu items for this menu.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The collection of menu items for this menu.")]
        [DefaultValue(null)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BetterMenuItemCollection SubItems => Items;

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the menu item is visible.
        /// </summary>
        [Category(Categories.Behavior)]
        [Localizable(true)]
        [DefaultValue(true)]
        [Description("Value indicating whether or not the menu item is visible.")]
        public bool Visible
        {
            get => _visible;
            set
            {
                if (Visible != value)
                {
                    _visible = value;
                }
            }
        }
    }
}