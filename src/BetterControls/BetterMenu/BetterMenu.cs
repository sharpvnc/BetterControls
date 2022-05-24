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
using System.Runtime.InteropServices;

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Menu classes.
    /// </summary>
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [Designer("BetterMenuDesigner")]
    public abstract partial class BetterMenu : BetterMenuBase
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenu"/>.
        /// </summary>
        private protected BetterMenu()
        {
            MenuReferences.Add(this, MenuReference);

            _items = new BetterMenuItemCollection(this);
            _menuReference = new BetterMenuReference(this);
        }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenu"/>.
        /// </summary>
        /// <param name="ownerMenu">The owner menu as an instance of <see cref="BetterMenu"/>.</param>
        private protected BetterMenu(BetterMenu ownerMenu)
            : base(ownerMenu)
        { }

        private bool _autoSizeItems = true;
        private int _customStatusWidth;
        private BetterMenuButton _defaultButton;
        private BetterMenuItemCollection _items;
        private BetterMenuReference _menuReference;

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the width of the status column of items should be automatically computed.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the width of the status column of items should be automatically computed.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool AutoSizeItems
        {
            get => _autoSizeItems;
            set
            {
                if (AutoSizeItems != value)
                {
                    _autoSizeItems = value;

                    OnAutoSizeItemsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the status column of items. This value will be ignored unless <see cref="AutoSizeItems"/> is set to <see langword="false"/>.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The width of the status column of items.")]
        [DefaultValue(0)]
        [Localizable(false)]
        public virtual int CustomStatusWidth
        {
            get => _customStatusWidth;
            set
            {
                if (CustomStatusWidth != value)
                {
                    _customStatusWidth = value;

                    OnCustomStatusWidthChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the default button in the menu items of this menu item. This item will usually appear as bold.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BetterMenuButton DefaultButton
        {
            get => _defaultButton;
            set
            {
                if (DefaultButton != value)
                {
                    _defaultButton = value;

                    if (DefaultButton != null)
                    {
                        UnsafeNativeMethods.SetMenuDefaultItem(GetHandleRef(), DefaultButton.UniqueIdentifier, false);
                    }
                    else
                    {
                        UnsafeNativeMethods.SetMenuDefaultItem(GetHandleRef(), -1, false);
                    }

                    OnDefaultButtonChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the focused push button in the menu items of this menu item.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BetterMenuButton FocusedPushbutton => _focusedButton;

        /// <summary>
        /// Gets the collection of menu items for this menu.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The collection of menu items for this menu.")]
        [DefaultValue(null)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual BetterMenuItemCollection Items => _items;

        /// <summary>
        /// Gets the menu reference for this menu as an instance of <see cref="BetterMenuReference"/>.
        /// </summary>
        internal BetterMenuReference MenuReference => _menuReference;

        /// <summary>
        /// Gets the root menu as an instance of <see cref="BetterMenuRoot"/>.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BetterMenuRoot MenuRoot
        {
            get
            {
                if (OwnerMenu != null)
                    return OwnerMenu.MenuRoot;

                return null;
            }
        }

        /// <summary>
        /// Gets the unique identifier of this menu item, relative to the the entire process scope.
        /// </summary>
        [Browsable(false)]
        public int UniqueIdentifier
        {
            get
            {
                if (MenuReference != null)
                    return MenuReference.UniqueIdentifier;

                return -1;
            }
        }















        #region Private Member Fields

        public IntPtr _handle;
        internal BetterMenuButton _focusedButton;

        #endregion

        #region Properties

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override IntPtr Handle
        {
            get
            {
                IntPtr handle = base.Handle;



                return _handle;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool IsHandleCreated => _handle != IntPtr.Zero;

        /// <summary>
        /// Gets an exhaustive collection of menu items directly or indirectly under the root menu.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        static internal BetterMenuReferenceCollection MenuReferences { get; } = new BetterMenuReferenceCollection();

        #endregion

        #region Miscellaneous

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="disposing"><inheritdoc/></param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void Dispose(bool disposing)
        {
            if (disposing && Items != null)
            {
                int index = Items.Count - 1;

                while (index >= 0)
                {
                    BetterMenu menu = Items[index--];

                    if (menu.Site != null && menu.Site.Container != null)
                    {
                        menu.Site.Container.Remove(menu);
                    }

                    //menu.OwnerControl2 = null;
                    menu.Dispose();
                }

                _items = null;
            }
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.DestroyMenu(new HandleRef(this, Handle));

                _handle = IntPtr.Zero;
            }

            base.Dispose(disposing);
        }







        #endregion
    }
}