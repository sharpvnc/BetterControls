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
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Toolbar classes.
    /// </summary>
    [ComVisible(true)]
    [DefaultProperty("Items")]
    [Designer("BetterToolbarDesigner")]
    [ToolboxBitmap(typeof(BetterToolbar), "BetterToolbarIcon.bmp")]
    public partial class BetterToolbar : BetterToolbarBase, ISupportInitialize
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbar"/>.
        /// </summary>
        public BetterToolbar()
        {
            SetStyle(ControlStyles.FixedHeight, AutoSize);
            SetStyle(ControlStyles.FixedWidth, false);

            TabStop = false;

            _items = new BetterToolbarItemCollection(this);
        }

        private BetterToolbarAppearance _appearance = BetterToolbarAppearance.Flat;
        private bool _autoSize = true;
        private bool _autoSizeItems = true;
        private BorderStyle _borderStyle = BorderStyle.None;
        private bool _divider = true;
        private bool _dropDownArrows = false;
        private BetterToolbarButton _hotButton;
        private ImageList _imageList;
        private Size _imageSize;
        private int _itemHeight;
        private BetterToolbarItemCollection _items;
        private ImageList _menuImageList;
        private bool _showToolTips = true;
        internal bool _stateDisposing = false;
        private BetterToolbarTextAlign _textAlign;
        private bool _wrappable = true;

        private int _requestedSize;
        private int _maximumWidth = -1;
        private float _currentScaleDX = 1.0F;
        private float _currentScaleDY = 1.0F;

        /// <summary>
        /// Gets or sets a value from <see cref="BetterToolbarAppearance"/> indicating the toolbar appearance.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the toolbar appearance.")]
        [DefaultValue(BetterToolbarAppearance.Flat)]
        [Localizable(false)]
        public virtual BetterToolbarAppearance Appearance
        {
            get => _appearance;
            set
            {
                if (Appearance != value)
                {
                    _appearance = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnAppearanceChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether the toolbar should automatically adjust its with and height based on the buttons.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether the toolbar should automatically adjust its with and height based on the buttons.")]
        [DefaultValue(true)]
        [Localizable(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override bool AutoSize
        {
            get => _autoSize;
            set
            {
                if (AutoSize != value)
                {
                    _autoSize = value;

                    if (Dock == DockStyle.Left || Dock == DockStyle.Right)
                    {
                        SetStyle(ControlStyles.FixedWidth, AutoSize);
                        SetStyle(ControlStyles.FixedHeight, false);
                    }
                    else
                    {
                        SetStyle(ControlStyles.FixedHeight, AutoSize);
                        SetStyle(ControlStyles.FixedWidth, false);
                    }

                    AdjustSize(Dock);
                    OnAutoSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the height of items should be automatically computed.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the height of items should be automatically computed.")]
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

                    if (IsHandleCreated)
                        RecreateHandle();
                }
            }
        }

        /// <summary>
        /// Gets the preferred size of the toolbar.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Size AutoSizeSize
        {
            get
            {
                if (_maximumWidth == -1)
                    _maximumWidth = Items.Select((item) => item.ComputedWidth).Sum();

                int width = _maximumWidth;

                if (BorderStyle != BorderStyle.None)
                    width += SystemInformation.BorderSize.Height * 4 + 3;

                int height = Items.Where((item) => item.Visible).Select((item) => item.Rectangle.Height).FirstOrDefault();

                if (IsHandleCreated && Wrappable)
                    height *= Rows;

                if (height == 0)
                    height = 1;

                if (BorderStyle == BorderStyle.FixedSingle)
                    height += SystemInformation.BorderSize.Height;

                if (BorderStyle == BorderStyle.Fixed3D)
                    height += SystemInformation.Border3DSize.Height;

                if (Divider)
                    height += 2;

                return new Size(width, height);
            }
        }

        /// <summary>
        /// Gets or sets a value from <see cref="System.Windows.Forms.BorderStyle"/> indicating the border style of the toolbar.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the border style of the toolbar.")]
        [DefaultValue(BorderStyle.None)]
        [Localizable(false)]
        public virtual BorderStyle BorderStyle
        {
            get => _borderStyle;
            set
            {
                if (BorderStyle != value)
                {
                    _borderStyle = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override ImeMode DefaultImeMode => ImeMode.Disable;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override Size DefaultSize => new Size(100, 22);

        /// <summary>
        /// Gets a value indicating whether the base <see cref="Control"/> class is in the process of disposing.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Disposing => _stateDisposing | base.Disposing;

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the toolbar divider should be visible.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating whether or not the toolbar divider should be visible.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool Divider
        {
            get => _divider;
            set
            {
                if (Divider != value)
                {
                    _divider = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnDividerChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override DockStyle Dock
        {
            get => base.Dock;
            set
            {
                if (Dock != value)
                {
                    if (value == DockStyle.Left || value == DockStyle.Right)
                    {
                        SetStyle(ControlStyles.FixedWidth, AutoSize);
                        SetStyle(ControlStyles.FixedHeight, false);
                    }
                    else
                    {
                        SetStyle(ControlStyles.FixedHeight, AutoSize);
                        SetStyle(ControlStyles.FixedWidth, false);
                    }

                    AdjustSize(value);

                    base.Dock = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not drop-down toolbar buttons should have drop down arrows.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating whether or not drop-down buttons should have drop down arrows.")]
        [DefaultValue(false)]
        [Localizable(false)]
        public virtual bool DropDownArrows
        {
            get => _dropDownArrows;
            set
            {
                if (DropDownArrows != value)
                {
                    _dropDownArrows = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnDropDownArrowsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the current hot button in the toolbar; that is - the button that is currently highlighted by the mouse or keyboard.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BetterToolbarButton HotButton => _hotButton;

        /// <summary>
        /// Gets or sets the image list used to provide a collection of images available to toolbar items.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The image list used to provide a collection of images available to toolbar items.")]
        [DefaultValue(null)]
        [Localizable(false)]
        public virtual ImageList ImageList
        {
            get => _imageList;
            set
            {
                if (ImageList != value)
                {
                    DetachImageListHandlers();

                    _imageList = value;

                    AttachImageListHandlers();

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnImageListChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of images in the image list, if any, associated with the toolbar.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The size of images in the image list, if any, associated with the toolbar.")]
        [DefaultValue(typeof(Size), "0, 0")]
        [Localizable(false)]
        public virtual Size ImageSize
        {
            get
            {
                if (ImageList is null)
                    return _imageSize;

                return ImageList.ImageSize;
            }
            set
            {
                if (ImageList is null && ImageSize != value)
                {
                    _imageSize = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnImageSizeChanged(EventArgs.Empty);
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
        public virtual int ItemHeight
        {
            get => _itemHeight;
            set
            {
                if (ItemHeight != value)
                {
                    if (value < 0 || value > 256)
                        throw new ArgumentOutOfRangeException(nameof(value), "ItemHeight must not be less than 0 or more than 256.");

                    _itemHeight = value;

                    if (IsHandleCreated && !AutoSizeItems)
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, 0, NativeMethods.Util.MAKELPARAM(0, ItemHeight));

                    AdjustSize(Dock);
                }
            }
        }

        /// <summary>
        /// Gets the collection of toolbar items for this toolbar.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The collection of toolbar items for this toolbar.")]
        [DefaultValue(null)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual BetterToolbarItemCollection Items => _items;

        /// <summary>
        /// Gets or sets the image list used to provide a collection of images available to drop-down menus.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("The image list used to provide a collection of images available to toolbar items.")]
        [DefaultValue(null)]
        [Localizable(false)]
        public virtual ImageList MenuImageList
        {
            get => _menuImageList;
            set
            {
                if (ImageList != value)
                {
                    DetachImageListHandlers();

                    _menuImageList = value;

                    AttachImageListHandlers();

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnImageListChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get => base.Padding;
            set { }
        }

        /// <summary>
        /// Gets the number of rows in the toolbar.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Rows => unchecked((int)(long)UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_GETROWS, 0, 0));

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not tool tips should be shown.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not tool tips should be shown.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool ShowToolTips
        {
            get => _showToolTips;
            set
            {
                if (ShowToolTips != value)
                {
                    _showToolTips = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnShowToolTipsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value from <see cref="BetterToolbarTextAlign"/> indicating the alignment of text on buttons.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("Value indicating the alignment of text on buttons.")]
        [DefaultValue(BetterToolbarTextAlign.Underneath)]
        [Localizable(false)]
        public virtual BetterToolbarTextAlign TextAlign
        {
            get => _textAlign;
            set
            {
                if (TextAlign != value)
                {
                    _textAlign = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    AdjustSize(Dock);

                    OnTextAlignChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="bool"/> value indicating whether or not the toolbar buttons should wrap to the next line if there is insufficient space.
        /// </summary>
        [Category(Categories.Behavior)]
        [Description("Value indicating whether or not the toolbar buttons should wrap to the next line if there is insufficient space.")]
        [DefaultValue(true)]
        [Localizable(false)]
        public virtual bool Wrappable
        {
            get => _wrappable;
            set
            {
                if (Wrappable != value)
                {
                    _wrappable = value;

                    if (IsHandleCreated)
                        RecreateHandle();

                    OnWrappableChanged(EventArgs.Empty);
                }
            }
        }








        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;

                parameters.ClassName = NativeMethods.WC_TOOLBAR;
                parameters.Style |= NativeMethods.CCS_NOPARENTALIGN | NativeMethods.CCS_NORESIZE;

                if (!Divider)
                    parameters.Style |= NativeMethods.CCS_NODIVIDER;

                if (Wrappable)
                    parameters.Style |= NativeMethods.TBSTYLE_WRAPPABLE;

                if (ShowToolTips && !DesignMode)
                    parameters.Style |= NativeMethods.TBSTYLE_TOOLTIPS;

                parameters.ExStyle &= ~NativeMethods.WS_EX_CLIENTEDGE;
                parameters.Style &= ~NativeMethods.WS_BORDER;

                if (BorderStyle == BorderStyle.Fixed3D)
                    parameters.ExStyle |= NativeMethods.WS_EX_CLIENTEDGE;
                else if (BorderStyle == BorderStyle.FixedSingle)
                    parameters.Style |= NativeMethods.WS_BORDER;

                if (Appearance == BetterToolbarAppearance.Flat)
                    parameters.Style |= NativeMethods.TBSTYLE_FLAT;

                if (TextAlign == BetterToolbarTextAlign.Right)
                    parameters.Style |= NativeMethods.TBSTYLE_LIST;

                return parameters;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private protected override void InitializeCommonControls()
        {
            if (RecreatingHandle)
                return;

            IntPtr userCookie = UnsafeNativeMethods.ThemingScope.Activate();

            try
            {
                NativeMethods.INITCOMMONCONTROLSEX initializeCommonControls = new NativeMethods.INITCOMMONCONTROLSEX();
                initializeCommonControls.dwICC = NativeMethods.ICC_BAR_CLASSES;

                SafeNativeMethods.InitCommonControlsEx(initializeCommonControls);
            }
            finally
            {
                UnsafeNativeMethods.ThemingScope.Deactivate(userCookie);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="e"><inheritdoc/></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Setup the toolbar based on the state of properties. These properties may have been set before
            // a handle was created, so setting them would have had no effect on the toolbar.
            UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_BUTTONSTRUCTSIZE, Marshal.SizeOf(typeof(NativeMethods.TBBUTTON)), 0);

            // The default is no drop-down arrows, so this is only necessary if drop-down arrows are enabled.
            if (DropDownArrows)
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETEXTENDEDSTYLE, 0, NativeMethods.TBSTYLE_EX_DRAWDDARROWS);

            if (ImageList != null)
            {
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETIMAGELIST, 0, ImageList.Handle);
            }
            else
            {
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETIMAGELIST, 0, IntPtr.Zero);
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.WM_USER + 32, 0, NativeMethods.Util.MAKELONG(ImageSize.Width, ImageSize.Height));
            }

            InitializeItems();

            // Force a repaint, as occasionally the ToolBar border does not paint properly
            // (comctl ToolBar is flaky)
            //
            BeginUpdate();
            UpdateItemDimensions();
            EndUpdate();
        }


        /// <summary>
        /// Initializes items on the toolbar.
        /// </summary>
        private void InitializeItems()
        {
            BeginUpdate();

            int structureSize = Marshal.SizeOf<NativeMethods.TBBUTTON>();
            IntPtr items = Marshal.AllocHGlobal(checked(structureSize * Items.Count));

            foreach (BetterToolbarItem item in Items)
            {
                NativeMethods.TBBUTTON structure = item.ComputeTbButton();

                Marshal.StructureToPtr(structure, (IntPtr)checked((long)items + (structureSize * item.DisplayedItemIndex)), true);
            }

            UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_ADDBUTTONS, Items.Count, items);
            UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_AUTOSIZE, 0, 0);
            UpdateItemDimensions();
            AdjustSize(Dock);

            Marshal.FreeHGlobal(items);

            EndUpdate();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="disposing"><inheritdoc/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    _stateDisposing = true;

                    if (ImageList != null)
                        ImageList = null;

                    for (int i = 0; i < Items.Count;)
                        Items[i].Dispose();
                }
                finally
                {
                    _stateDisposing = false;
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Sends the WM_CANCELMODE message to the toolbar.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private protected void PerformCancelMode()
        {
            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.WM_CANCELMODE, 0, 0);
        }

        /// <summary>
        /// Closes any open drop-down menus.
        /// </summary>
        public void CloseDropDownMenus() => PerformCancelMode();

        /// <summary>
        /// Focuses the specified toolbar button.
        /// </summary>
        /// <param name="button">The toolbar button to focus as an instance of <see cref="BetterToolbarButton"/>.</param>
        public void FocusButton(BetterToolbarButton button)
        {
            if (IsHandleCreated)
            {
                if (button is null)
                {
                    UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETHOTITEM, -1, 0);
                }
                else
                {
                    UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_SETHOTITEM, button.DisplayedItemIndex, 0);
                }
            }
        }

        /// <summary>
        /// Clears the focus on any toolbar buttons.
        /// </summary>
        public void ClearButtonFocus() => FocusButton(null);

        /// <summary>
        /// Attaches the necessary image list handlers.
        /// </summary>
        private void AttachImageListHandlers()
        {
            if (ImageList != null)
            {
                ImageList.RecreateHandle += ImageListRecreateHandle;
                ImageList.Disposed += DetachImageListHandle;
            }
            if (MenuImageList != null)
            {
                MenuImageList.RecreateHandle += ImageListRecreateHandle;
                MenuImageList.Disposed += DetachImageListHandle;
            }
        }

        /// <summary>
        /// Detaches the necessary image list handlers.
        /// </summary>
        private void DetachImageListHandlers()
        {
            if (ImageList != null)
            {
                ImageList.RecreateHandle -= ImageListRecreateHandle;
                ImageList.Disposed -= DetachImageListHandle;
            }
            if (MenuImageList != null)
            {
                MenuImageList.RecreateHandle -= ImageListRecreateHandle;
                MenuImageList.Disposed -= DetachImageListHandle;
            }
        }

        /// <summary>
        /// Gets the tool tip text for the specified toolbar button.
        /// </summary>
        /// <param name="button">The button to get tool tip text for as an instance of <see cref="BetterToolbarButton"/>.</param>
        protected virtual string GetToolTipText(BetterToolbarButton button)
        {
            if (button is null)
            {
                throw new ArgumentNullException(nameof(button));
            }

            return button.ToolTipText;
        }

        /// <summary>
        /// Adjusts the size of the control to ensure auto-sizing works correctly.
        /// </summary>
        /// <param name="dock">The <see cref="DockStyle"/> to base the sizing from.</param>
        private void AdjustSize(DockStyle dock)
        {
            int saveSize = _requestedSize;

            try
            {
                if (dock == DockStyle.Left || dock == DockStyle.Right)
                    if (AutoSize)
                        Width = AutoSizeSize.Width;
                    else
                        Width = saveSize;
                else
                {
                    if (AutoSize)
                        Height = AutoSizeSize.Height;
                    else
                        Height = saveSize;
                }
            }
            finally
            {
                _requestedSize = saveSize;
            }
        }

        /// <summary>
        /// Gets a drop-down menu item by its index.
        /// </summary>
        /// <param name="handle">The handle of the menu.</param>
        /// <param name="index">The index of the item in the menu to get.</param>
        /// <returns>The menu item as an instance of <see cref="BetterMenuItem"/>.</returns>
        private BetterMenuItem GetMenuItemByIndex(IntPtr handle, int index)
        {
            int identifier = UnsafeNativeMethods.GetMenuItemID(new HandleRef(null, handle), index);

            if (identifier == -1)
            {
                // This menu item has sub-items. We have to recurse through the menu tree until we find an
                // item that does not have any sub-items, and then iterate back up its menu tree based on its
                // stored parent information.
                IntPtr childHandle = UnsafeNativeMethods.GetSubMenu(new HandleRef(null, handle), index);
                int childMenuCount = UnsafeNativeMethods.GetMenuItemCount(new HandleRef(null, childHandle));

                for (int i = 0; i < childMenuCount;)
                {
                    BetterMenuItem item = GetMenuItemByIndex(childHandle, i++);

                    if (item != null && item.OwnerElement != null && item.OwnerElement is BetterMenuItem parentItem)
                        return parentItem;
                }
            }
            else
            {
                // This menu item does not have any sub-items.
                GlobalCommand globalCommand = GlobalCommand.GetCommandExecutor(identifier);

                if (globalCommand != null && globalCommand.CommandExecutor is BetterMenuReference menuReference && menuReference.Menu is BetterMenuItem item)
                    return item;
            }

            return null;
        }

        /// <summary>
        /// Adds the specified <see cref="string"/> to the toolbar resource.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to add to the toolbar resource.</param>
        /// <returns>The native pointer to the string added.</returns>
        protected internal IntPtr AddString(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Length > 0)
                return UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_ADDSTRING, 0, text + '\0'.ToString());

            return (IntPtr)(-1);
        }

        /// <summary>
        /// Gets the item, if any, at the specified coordinates.
        /// </summary>
        /// <param name="coordinates">The coordinates to get the item at.</param>
        /// <returns>An instance of <see cref="BetterToolbarItem"/>.</returns>
        public virtual BetterToolbarItem GetItemAt(Point coordinates)
        {
            foreach (BetterToolbarItem item in Items)
            {
                if (item.Rectangle.Contains(PointToClient(coordinates)))
                    return item;
            }

            return null;
        }

        /// <summary>
        /// This method is raised when a menu item item of any drop-down button is highlighted either by mouse or keyboard.
        /// </summary>
        /// <param name="item">The item that was selected as an instance of <see cref="BetterMenuButton"/>.</param>
        private protected virtual void PerformDropDownItemSelect(BetterMenuButton item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.ItemFocused();
        }

        /// <summary>
        /// This method is raised when a message has been received that a drop-down button has been clicked.
        /// </summary>
        /// <param name="item">The drop-down button that was clicked as an instance of <see cref="BetterToolbarDropDownButton"/>.</param>
        /// <param name="focusMenu">A <see cref="bool"/> value indicating whether or not the drop-down menu should be focused.</param>
        private protected virtual void PerformDropDown(BetterToolbarDropDownButton item, bool focusMenu)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.DropDownMenu != null)
            {
                OnBeforeMenuDroppedDown(new BetterToolbarMenuDroppedDownEventArgs(item));

                if (focusMenu)
                {
                    UnsafeNativeMethods.Keybd_event(NativeMethods.VK_DOWN, 0, 0, 0);
                    UnsafeNativeMethods.Keybd_event(NativeMethods.VK_DOWN, 0, NativeMethods.KEYEVENTF_KEYUP, 0);
                }

                item.DropDownMenu.Show(this, new Point(item.Rectangle.Left, item.Rectangle.Bottom));

                OnAfterMenuDroppedDown(new BetterToolbarMenuDroppedDownEventArgs(item));
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="e"><inheritdoc/></param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            if (IsHandleCreated)
            {
                //if (!buttonSize.IsEmpty)
                //{
                //    SendToolbarButtonSizeMessage();
                //}
                //else
                {
                    AdjustSize(Dock);
                    UpdateItemDimensions();
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dx"><inheritdoc/></param>
        /// <param name="dy"><inheritdoc/></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ScaleCore(float dx, float dy)
        {
            _currentScaleDX = dx;
            _currentScaleDY = dy;
            base.ScaleCore(dx, dy);

            if (IsHandleCreated)
                RecreateHandle();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="factor"><inheritdoc/></param>
        /// <param name="specified"><inheritdoc/></param>
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            _currentScaleDX = factor.Width;
            _currentScaleDY = factor.Height;

            base.ScaleControl(factor, specified);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="x"><inheritdoc/></param>
        /// <param name="y"><inheritdoc/></param>
        /// <param name="width"><inheritdoc/></param>
        /// <param name="height"><inheritdoc/></param>
        /// <param name="specified"><inheritdoc/></param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            int originalHeight = height;
            int originalWidth = width;

            base.SetBoundsCore(x, y, width, height, specified);

            Rectangle bounds = Bounds;
            if (Dock == DockStyle.Left || Dock == DockStyle.Right)
            {
                if ((specified & BoundsSpecified.Width) != BoundsSpecified.None)
                    _requestedSize = width;
                if (AutoSize)
                    width = AutoSizeSize.Width;

                if (width != originalWidth && Dock == DockStyle.Right)
                {
                    int deltaWidth = originalWidth - width;
                    x += deltaWidth;
                }
            }
            else
            {
                if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
                    _requestedSize = height;
                if (AutoSize)
                    height = AutoSizeSize.Height;

                if (height != originalHeight && Dock == DockStyle.Bottom)
                {
                    int deltaHeight = originalHeight - height;
                    y += deltaHeight;
                }

            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        void ISupportInitialize.BeginInit() => BeginUpdate();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        void ISupportInitialize.EndInit() => EndUpdate();

        /// <summary>
        /// Ensures that the dimensions for each item in the toolbar are correct.
        /// </summary>
        public void UpdateItemDimensions()
        {
            foreach (BetterToolbarItem item in Items)
            {
                NativeMethods.TBBUTTONINFO structure = item.ComputeTbButtonInfo();

                if (structure.cx > _maximumWidth)
                    _maximumWidth = structure.cx;

                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONINFO, item.UniqueIdentifier, ref structure);
            }

            if (!AutoSizeItems)
            {
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, 0, NativeMethods.Util.MAKELPARAM(0, ItemHeight));
            }

            try
            {
                Size size = Size;
                Size = new Size(size.Width + 1, size.Height);
                Size = size;
            }
            finally
            {
                EndUpdate();
            }

            if (!AutoSizeItems)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, 0, NativeMethods.Util.MAKELPARAM(0, ItemHeight));

            AdjustSize(Dock);
        }

        


        /// <summary>
        /// This event handler is raised when the handle associated with image list associated with this toolbar is recreated.
        /// </summary>
        private void ImageListRecreateHandle(object sender, EventArgs e)
        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (IsHandleCreated)
                RecreateHandle();
        }

        /// <summary>
        /// This event handler is raised when the handle associated with image list associated with this toolbar is desroyed.
        /// </summary>
        private void DetachImageListHandle(object sender, EventArgs e)
        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageList = null;
        }
    }
}