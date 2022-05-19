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
using BetterControls.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item that is a button.
    /// </summary>
    [Designer("BetterToolbarButtonDesigner")]
    public abstract partial class BetterToolbarButton : BetterToolbarItem
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        public BetterToolbarButton()
        {
            _imageIndexer = new BetterToolbarImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public BetterToolbarButton(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));

            _imageIndexer = new BetterToolbarImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public BetterToolbarButton(string text, string description)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Description = description ?? throw new ArgumentNullException(nameof(description));

            _imageIndexer = new BetterToolbarImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarButton(string text, int imageIndex)
        {
            _imageIndexer = new BetterToolbarImageIndexer(this);

            Text = text ?? throw new ArgumentNullException(nameof(text));
            ImageIndex = imageIndex;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarButton(string text, string description, int imageIndex)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImageIndex = imageIndex;

            _imageIndexer = new BetterToolbarImageIndexer(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButton"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarButton(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        {
            _imageIndexer = new BetterToolbarImageIndexer(this);
        }

        private string _description = string.Empty;
        private bool _enabled = true;
        private BetterToolbarImageIndexer _imageIndexer;
        private bool _pressed = false;
        private bool _showImage = true;
        private string _text = string.Empty;
        private string _toolTipText = string.Empty;

        private string _previousText = string.Empty;
        private IntPtr _stringIndex;

        /// <summary>
        /// Gets or sets the description of the button.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The text of the toolbar item.")]
        [DefaultValue("")]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Description
        {
            get => _description;
            set
            {
                if (Description != value)
                {
                    _description = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the button is enabled.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the button is enabled.")]
        [DefaultValue(true)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual bool Enabled
        {
            get => _enabled;
            set
            {
                if (Enabled != value)
                {
                    _enabled = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
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

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets the image indexer used to provide a mechanism for a toolbar to support using both image indexes and image keys.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private protected BetterToolbarImageIndexer ImageIndexer => _imageIndexer;

        /// <summary>
        /// Gets or sets the key of the image from the toolbar image list to be shown in the toolbar item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The key of the image from the toolbar image list to be shown in the toolbar item.")]
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

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the button is pressed.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the button is pressed.")]
        [DefaultValue(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual bool Pressed
        {
            get => _pressed;
            set
            {
                if (Pressed != value)
                {
                    _pressed = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the image should be shown on this item.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the image should be shown on this item.")]
        [DefaultValue(true)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual bool ShowImage
        {
            get => _showImage;
            set
            {
                if (ShowImage != value)
                {
                    _showImage = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text of the button.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The text of the button.")]
        [DefaultValue("")]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string Text
        {
            get
            {
                if (_text is null)
                {
                    if (Name != null)
                        return Name;
                }
                else
                {
                    return _text;
                }

                return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = null;
                }

                if ((value is null && Text != null) || (value != null && (Text is null || !Text.Equals(value))))
                {
                    _text = value;

                    if (IsOwnerHandleCreated)
                        _stringIndex = OwnerToolbar.AddString(Text);

                    // If the text contains a mnemonic, then it's best to create the toolbar handle.
                    if (AccessibilityHelper.ContainsMnemonic(Text))
                    {
                        PerformItemChanged(CollectionElementItemChangedFlags.RecreateHandle);
                    }
                    else
                    {
                        PerformItemChanged(CollectionElementItemChangedFlags.None);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the tool tip text of the button.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The tool tip text of the button.")]
        [DefaultValue("")]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual string ToolTipText
        {
            get => _toolTipText;
            set
            {
                if (ToolTipText != value)
                {
                    _toolTipText = value;
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        protected override int ComputeAutoSizeWidth()
        {
            int width = 0;

            using (Graphics graphics = OwnerToolbar.CreateGraphics())
            {
                //if (!Parent.AutoSizeItems && !Parent.ButtonSize.IsEmpty)
                //{
                //    width = Parent.ButtonSize.Width;
                //}
                //else
                {
                    string text = string.Empty;

                    if (!string.IsNullOrEmpty(Text))
                        text = Text;

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '&')
                        {
                            if (text.Length > i + 1)
                                if (!(text[i + 1] == '&'))
                                    text = text.Remove(i--, 1);
                                else
                                    text = text.Remove(i--, 1);
                        }
                    }

                    Size textSize = Size.Ceiling(graphics.MeasureString(text, OwnerToolbar.Font));

                    if (OwnerToolbar.TextAlign == BetterToolbarTextAlign.Right)
                    {
                        if (textSize.Width == 0)
                        {
                            if (ShowImage)
                            {
                                width = OwnerToolbar.ImageSize.Width + SystemInformation.Border3DSize.Width * 4 - 1;
                            }
                            else
                            {
                                width = SystemInformation.Border3DSize.Width * 4;
                            }
                        }
                        else
                        {
                            if (ShowImage)
                            {
                                width = OwnerToolbar.ImageSize.Width + textSize.Width + SystemInformation.Border3DSize.Width * 4 + 1;
                            }
                            else
                            {
                                width = textSize.Width + SystemInformation.Border3DSize.Width + 1;
                            }
                        }
                    }
                    else
                    {
                        if (textSize.Width == 0)
                        {
                            if (ShowImage)
                            {
                                width = OwnerToolbar.ImageSize.Width + SystemInformation.Border3DSize.Width * 4 - 1;
                            }
                            else
                            {
                                width = SystemInformation.Border3DSize.Width * 4;
                            }
                        }
                        else
                        {
                            if (ShowImage)
                            {
                                width = Math.Max(OwnerToolbar.ImageSize.Width, textSize.Width) + SystemInformation.Border3DSize.Width * 4 + 10;
                            }
                            else
                            {
                                width = textSize.Width + SystemInformation.Border3DSize.Width + 1;
                            }
                        }
                    }
                }
            }

            return width;
        }

        /// <summary>
        /// Indicates that this toolbar button will be focused.
        /// </summary>
        public virtual void Focus()
        {
            if (IsOwnerHandleCreated)
                OwnerToolbar.FocusButton(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Text))
                return nameof(BetterToolbarButton);

            return nameof(BetterToolbarButton) + ": " + Text;
        }
    }
}