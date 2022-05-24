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
using BetterControls.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a menu item that is a button.
    /// </summary>
    public abstract partial class BetterMenuButton : BetterMenuItem
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        public BetterMenuButton()
        {
            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        public BetterMenuButton(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        public BetterMenuButton(string text, string description)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public BetterMenuButton(string text, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            ImageIndex = imageIndex;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        public BetterMenuButton(string text, string description, int imageIndex)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;
            ImageIndex = imageIndex;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public BetterMenuButton(string text, Image image)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            Image = image;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        public BetterMenuButton(string text, string description, Image image)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;
            Image = image;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, string description, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, int imageIndex, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            ImageIndex = imageIndex;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="imageIndex">The index of the image from the parent most menu image list to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, string description, int imageIndex, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;
            ImageIndex = imageIndex;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, Image image, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            Image = image;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="text">The text of the menu item.</param>
        /// <param name="description">The description of the menu item.</param>
        /// <param name="image">The image to be shown in the menu item.</param>
        /// <param name="shortcut">The shortcut key combination associated with the menu item.</param>
        public BetterMenuButton(string text, string description, Image image, Shortcut shortcut)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (description is null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            Text = text;
            Description = description;
            Image = image;
            Shortcut = shortcut;

            _imageIndexer = new BetterMenuButtonImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuButton"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner menu as an instance of <see cref="BetterMenu"/>.</param>
        private protected BetterMenuButton(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }

        private bool _autoSize = true;
        private bool _checked = false;
        private BetterMenuButtonImageAlign _checkAlign = BetterMenuButtonImageAlign.MiddleRight;
        private BetterMenuItemCheckStyle _checkStyle = BetterMenuItemCheckStyle.Disabled;
        private int _customHeight = 0;
        private string _description = string.Empty;
        private bool _enabled = true;
        private bool _highlight = false;
        private Image _image;
        private BetterMenuButtonImageAlign _imageAlign = BetterMenuButtonImageAlign.MiddleRight;
        private BetterMenuButtonImageIndexer _imageIndexer;
        private bool _ownerDraw = false;
        private Shortcut _shortcut = Shortcut.None;
        private bool _showShortcut = true;
        private string _text = string.Empty;
        private bool _useShieldImage = false;

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the menu item should be auto-sized.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the menu item should be auto-sized.")]
        [DefaultValue(true)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual bool AutoSize
        {
            get => _autoSize;
            set
            {
                if (AutoSize != value)
                {
                    _autoSize = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);

                    OnAutoSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the menu item is checked.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating whether or not the menu item is checked.")]
        [DefaultValue(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual bool Checked
        {
            get => _checked;
            set
            {
                if (Checked != value)
                {
                    if (value is true && Items.Count != 0)
                        return;

                    _checked = value;

                    if (CheckStyle == BetterMenuItemCheckStyle.Disabled && Checked == true)
                    {
                        CheckStyle = BetterMenuItemCheckStyle.Check;
                    }
                    else if (CheckStyle != BetterMenuItemCheckStyle.Disabled && Checked == false)
                    {
                        CheckStyle = BetterMenuItemCheckStyle.Disabled;
                    }

                    OnCheckedChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value from <see cref="BetterMenuButtonImageAlign"/> indicating the alignment of the check when specified.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the alignment of the check when specified.")]
        [DefaultValue(typeof(BetterMenuButtonImageAlign), "MiddleRight")]
        [Localizable(false)]
        public virtual BetterMenuButtonImageAlign CheckAlign
        {
            get => _checkAlign;
            set
            {
                if (CheckAlign != value)
                {
                    _checkAlign = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value from <see cref="BetterMenuItemCheckStyle"/> indicating the check style of the item when checked.
        /// </summary>
        [Localizable(true)]
        [DefaultValue(typeof(BetterMenuItemCheckStyle), "Disabled")]
        [Category(Categories.Appearance)]
        [Description("Value indicating the check style of the item when checked.")]
        public virtual BetterMenuItemCheckStyle CheckStyle
        {
            get => _checkStyle;
            set
            {
                if (CheckStyle != value)
                {
                    _checkStyle = value;

                    if (CheckStyle == BetterMenuItemCheckStyle.Check || CheckStyle == BetterMenuItemCheckStyle.Radio)
                    {
                        _checked = true;
                    }
                    else
                    {
                        _checked = false;
                    }

                    OnCheckStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the item height.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the item height.")]
        [DefaultValue(0)]
        [Localizable(false)]
        public virtual int CustomHeight
        {
            get => _customHeight;
            set
            {
                if (_customHeight != value)
                {
                    if (value < 0 || value > 256)
                        throw new ArgumentOutOfRangeException(nameof(value), "ItemHeight must not be less than 0 or more than 256.");

                    _customHeight = value;

                    OnCustomHeightChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the description of the menu item.
        /// </summary>
        [Category(Categories.Data)]
        [Description("The description of the menu item.")]
        [DefaultValue("")]
        [Localizable(false)]
        public virtual string Description
        {
            get => _description;
            set
            {
                if (Description != value)
                {
                    _description = value;

                    OnDescriptionChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the menu item is enabled.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the menu item is enabled.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool Enabled
        {
            get => _enabled;
            set
            {
                if (Enabled != value)
                {
                    _enabled = value;

                    OnEnabledChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not this menu item should be highlighted when opened.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not this menu item should be highlighted when opened.")]
        [DefaultValue(false)]
        [Localizable(false)]
        public virtual bool Highlight
        {
            get => _highlight;
            set
            {
                if (Highlight != value)
                {
                    _highlight = value;

                    OnHighlightChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the image to be shown in the menu item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The image to be shown in the menu item.")]
        [DefaultValue(null)]
        [Localizable(false)]
        public virtual Image Image
        {
            get => _image;
            set
            {
                if (Image != value)
                {
                    _image = value;

                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value from <see cref="BetterMenuButtonImageAlign"/> indicating the alignment of an image when specified.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the alignment of an image when specified.")]
        [DefaultValue(typeof(BetterMenuButtonImageAlign), "MiddleRight")]
        [Localizable(false)]
        public virtual BetterMenuButtonImageAlign ImageAlign
        {
            get => _imageAlign; set
            {
                if (ImageAlign != value)
                {
                    _imageAlign = value;

                    OnImageAlignChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the image from the menu image list to be shown in the menu item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The index of the image from the menu image list to be shown in the menu item.")]
        [DefaultValue(-1)]
        [Localizable(false)]
        [Editor("ImageIndexEditor", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(NoneExcludedImageIndexConverter))]
        [RelatedImageList("OwnerToolbar.ImageList")]
        public virtual int ImageIndex
        {
            get => ImageIndexer.Index;
            set
            {
                if (ImageIndex != value)
                {
                    ImageIndexer.Index = value;

                    OnImageIndexChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the image indexer used to provide a mechanism for a toolbar to support using both image indexes and image keys.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private protected BetterMenuButtonImageIndexer ImageIndexer => _imageIndexer;

        /// <summary>
        /// Gets or sets the key of the image from the menu image list to be shown in the menu item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The key of the image from the menu image list to be shown in the menu item.")]
        [DefaultValue("")]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ImageKeyConverter))]
        [RelatedImageList("OwnerToolbar.ImageList")]
        public virtual string ImageKey
        {
            get => ImageIndexer.Key;
            set
            {
                if (ImageKey != value)
                {
                    ImageIndexer.Key = value;

                    OnImageKeyChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the mnemonic of the menu item text, if any.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public char Mnemonic => StringUtilities.GetMnemonic(Text, true);

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not owner draw is enabled for the menu item.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not owner draw is enabled for the menu item.")]
        [DefaultValue(false)]
        [Localizable(false)]
        public bool OwnerDraw
        {
            get => _ownerDraw;
            set
            {
                if (OwnerDraw != value)
                {
                    _ownerDraw = value;

                    OnOwnerDrawChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the shortcut key combination associated with the menu item.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The shortcut key combination associated with the menu item.")]
        [DefaultValue(typeof(Shortcut), "None")]
        [Localizable(false)]
        public virtual Shortcut Shortcut
        {
            get => _shortcut;
            set
            {
                if (Shortcut != value)
                {
                    _shortcut = value;

                    OnShortcutChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the shortcut is shown in the menu item.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the shortcut is shown in the menu item.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool ShowShortcut
        {
            get => _showShortcut;
            set
            {
                if (ShowShortcut != value)
                {
                    _showShortcut = value;

                    OnShowShortcutChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text of the menu item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The text of the menu item.")]
        [DefaultValue("")]
        [Localizable(false)]
        public virtual string Text
        {
            get => _text;
            set
            {
                if (Text != value)
                {
                    _text = value;

                    OnTextChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the menu item should use the system shield image. This will take precedence over any value given in <see cref="Image"/>, <see cref="ImageIndex"/> or <see cref="ImageKey"/>.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating whether or not the menu item should use the system shield image.")]
        [DefaultValue(false)]
        [Localizable(false)]
        public virtual bool UseShieldImage
        {
            get => _useShieldImage;
            set
            {
                if (UseShieldImage != value)
                {
                    _useShieldImage = value;

                    OnUseShieldImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Simulates clicking the menu item.
        /// </summary>
        public void PerformClick()
        {
            if (Enabled)
            {
                MenuRoot.DescendantClicked(this);
                OnClick(EventArgs.Empty);
            }
        }

        /// <summary>
        /// This method is raised when this item is focused.
        /// </summary>
        internal void ItemFocused()
        {
            MenuRoot.DescendantFocused(this);
            OnFocused(new EventArgs());
        }
    }
}