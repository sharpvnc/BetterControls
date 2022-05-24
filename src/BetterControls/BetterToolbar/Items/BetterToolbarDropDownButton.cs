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
    /// Represents a toolbar drop-down button.
    /// </summary>
    public partial class BetterToolbarDropDownButton : BetterToolbarButton
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        public BetterToolbarDropDownButton()
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public BetterToolbarDropDownButton(string text)
            : base(text)
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public BetterToolbarDropDownButton(string text, string description)
            : base(text, description)
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarDropDownButton(string text, int imageIndex)
            : base(text, imageIndex)
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarDropDownButton(string text, string description, int imageIndex)
            : base(text, description, imageIndex)
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownButton"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarDropDownButton(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        {
            _dropDownMenu = new BetterToolbarDropDownMenu(this);
        }

        private BetterToolbarDropDownMenu _dropDownMenu;

        /// <summary>
        /// Gets or sets the drop-down menu for this toolbar button.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The drop down menu for this toolbar button.")]
        [DefaultValue(null)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BetterToolbarDropDownMenu DropDownMenu => _dropDownMenu;

        /// <summary>
        /// Gets or sets the collection of sub-items for the drop-down button.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The collection of sub-items for the drop-down button.")]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual BetterMenuItemCollection SubItems => DropDownMenu.Items;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        protected override int ComputeAutoSizeWidth()
        {
            int width = base.ComputeAutoSizeWidth();

            width += 12; // Accounts for the drop-down arrow

            return width;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        private protected override BetterToolbarItem CreateClone() => new BetterToolbarDropDownButton();
    }
}