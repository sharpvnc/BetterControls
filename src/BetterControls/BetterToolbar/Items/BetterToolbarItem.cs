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
using System;
using System.ComponentModel;
using System.Drawing;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item.
    /// </summary>
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [Designer("BetterToolbarItemDesigner")]
    public abstract partial class BetterToolbarItem : BetterToolbarItemBase, ICloneable
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarItem"/>.
        /// </summary>
        private protected BetterToolbarItem() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarItem"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarItem(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        { }

        private bool _autoSize = true;
        private bool _visible = true;
        private int _width;
        private int _uniqueIdentifier = -1;

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the button should be auto-sized.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the button should be auto-sized.")]
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
                }
            }
        }

        /// <summary>
        /// Gets the displayed index of this item in the toolbar.
        /// </summary>
        [Browsable(false)]
        public virtual int DisplayedItemIndex
        {
            get
            {
                if (IsOwnerHandleCreated)
                    return ItemIndex;

                return -1;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the toolbar item is visible.
        /// </summary>
        [Category(Categories.Behavior)]
        [Localizable(true)]
        [DefaultValue(true)]
        [Description("Value indicating whether or not the toobar item is visible.")]
        public bool Visible
        {
            get => _visible;
            set
            {
                if (Visible != value)
                {
                    _visible = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets the bounds of the toolbar item.
        /// </summary>
        [Browsable(false)]
        public Rectangle Rectangle
        {
            get
            {
                if (IsOwnerHandleCreated)
                {
                    NativeMethods.RECT rc = new NativeMethods.RECT();
                    UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_GETRECT, UniqueIdentifier, ref rc);

                    return Rectangle.FromLTRB(rc.left, rc.top, rc.right, rc.bottom);
                }

                return Rectangle.Empty;
            }
        }

        /// <summary>
        /// Gets the computed width of this item.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ComputedWidth
        {
            get
            {
                if (AutoSize)
                    return ComputeAutoSizeWidth();

                return Width;
            }
        }

        /// <summary>
        /// Gets or sets the width of the toolbar item.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The width of the toolbar item.")]
        [DefaultValue(0)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual int Width
        {
            get => _width;
            set
            {
                if (Width != value)
                {
                    _width = value;

                    PerformItemChanged(CollectionElementItemChangedFlags.None);
                }
            }
        }

        /// <summary>
        /// Gets the unique identifier of this toolbar item, relative to the parent toolbar.
        /// </summary>
        [Browsable(false)]
        public int UniqueIdentifier => _uniqueIdentifier;

        /// <summary>
        /// Resets the unique identifier of this item.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void ResetUniqueIdentifier() => _uniqueIdentifier = -1;

        /// <summary>
        /// Sets the unique identifier of this item.
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier of this item.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetUniqueIdentifier(int uniqueIdentifier) => _uniqueIdentifier = uniqueIdentifier;

        /// <summary>
        /// Computes the auto-size width of the toolbar button.
        /// </summary>
        /// <returns>The computed auto-size width of the toolbar button.</returns>
        protected abstract int ComputeAutoSizeWidth();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="flags"><inheritdoc/></param>
        protected override void PerformItemChanged(CollectionElementItemChangedFlags flags)
        {
            if (IsOwnerHandleCreated)
            {
                NativeMethods.TBBUTTONINFO structure = ComputeTbButtonInfo();

                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETBUTTONINFO, DisplayedItemIndex, ref structure);

                // Reflect this change to the parent control.
                OwnerToolbar.PerformItemsChanged(flags, new BetterToolbarItem[]
                {
                    this
                });
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BetterToolbarItem item = CreateClone();

            ConfigureClone(item);

            return item;
        }

        /// <summary>
        /// Creates a new concrete type that should be cloned.
        /// </summary>
        /// <returns></returns>
        private protected abstract BetterToolbarItem CreateClone();

        /// <summary>
        /// Configures the created concrete type that should be cloned.
        /// </summary>
        /// <param name="item">The concrete type that should be cloned.</param>
        private protected virtual void ConfigureClone(BetterToolbarItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.AutoSize = AutoSize;
            item.Visible = Visible;
            item.Width = Width;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString() => nameof(BetterToolbarItem);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="disposing"><inheritdoc/></param>
        protected override void Dispose(bool disposing)
        {
            // Disposed items cannot exist in a collection.
            Remove();

            // If in design mode, also remove this item from the site as well.
            if (Site != null && Site.Container != null)
                Site.Container.Remove(this);

            base.Dispose(disposing);
        }
    }
}