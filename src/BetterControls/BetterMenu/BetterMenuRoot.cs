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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a root menu.
    /// </summary>
    public abstract partial class BetterMenuRoot : BetterMenu
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuRoot"/>.
        /// </summary>
        public BetterMenuRoot() { }

        private ImageList _imageList;
        private BetterMenuHighlightBehavior _showHighlightBehavior = BetterMenuHighlightBehavior.Default;
        private Control _sourceControl;
        private BetterMenuWndProcSubclass _wndProcSubclass;

        /// <summary>
        /// Gets the image list for the menu root.
        /// </summary>
        [Category(Categories.Appearance)]
        [Description("The image list for the menu root.")]
        [DefaultValue(null)]
        [Localizable(false)]
        public virtual ImageList ImageList
        {
            get => _imageList;
            set
            {
                if (ImageList != value)
                {
                    _imageList = value;
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override BetterMenuRoot MenuRoot => this;

        /// <summary>
        /// Gets or sets a value from <see cref="BetterMenuHighlightBehavior"/> indicating the highlight behavior when this root menu is shown.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal virtual BetterMenuHighlightBehavior ShowHighlightBehavior
        {
            get => _showHighlightBehavior;
            set
            {
                if (ShowHighlightBehavior != value)
                {
                    _showHighlightBehavior = value;
                }
            }
        }

        /// <summary>
        /// Gets the control that the menu is opened against.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control SourceControl => _sourceControl;

        /// <summary>
        /// This method is raised when a direct or indirect descendant menu button is clicked.
        /// </summary>
        /// <param name="menuItem">The menu item that was clicked.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DescendantClicked(BetterMenuButton menuItem)
        {
            if (menuItem is null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }

            OnMenuItemClick(new BetterMenuButtonClickEventArgs(menuItem));
        }

        /// <summary>
        /// This method is raised when a direct or indirect descendant menu button is focused.
        /// </summary>
        /// <param name="menuItem">The menu item that was focused.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DescendantFocused(BetterMenuButton menuItem)
        {
            if (menuItem is null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }

            OnMenuItemFocused(new BetterMenuButtonFocusedEventArgs(menuItem));
        }

        /// <summary>
        /// Displays the menu at the specified position.
        /// </summary>
        /// <param name="control">The control that owns the menu.</param>
        /// <param name="position">The position relative to the screen that the menu should be shown from.</param>
        public virtual void Show(Control control, Point position)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int flags = NativeMethods.TPM_VERTICAL | NativeMethods.TPM_RIGHTBUTTON;

            Show(control, position, flags, BetterMenuHighlightBehavior.Default);
        }

        /// <summary>
        /// Displays the menu at the specified position.
        /// </summary>
        /// <param name="control">The control that owns the menu.</param>
        /// <param name="position">The position relative to the screen that the menu should be shown from.</param>
        /// <param name="alignment">The direction relative to the position that the menu should be shown from.</param>
        public virtual void Show(Control control, Point position, LeftRightAlignment alignment)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int flags = NativeMethods.TPM_VERTICAL | NativeMethods.TPM_RIGHTBUTTON;

            if (alignment == LeftRightAlignment.Left)
            {
                flags |= NativeMethods.TPM_RIGHTALIGN;
            }
            else
            {
                flags |= NativeMethods.TPM_LEFTALIGN;
            }

            Show(control, position, flags, BetterMenuHighlightBehavior.Default);
        }

        /// <summary>
        /// Displays the menu at the specified position.
        /// </summary>
        /// <param name="control">The control that owns the menu.</param>
        /// <param name="position">The position relative to the screen that the menu should be shown from.</param>
        /// <param name="highlightBehavior">Value from <see cref="BetterMenuHighlightBehavior"/> indicating the highlight behavior when this root menu is shown.</param>
        public virtual void Show(Control control, Point position, BetterMenuHighlightBehavior highlightBehavior)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int flags = NativeMethods.TPM_VERTICAL | NativeMethods.TPM_RIGHTBUTTON;

            Show(control, position, flags, highlightBehavior);
        }

        /// <summary>
        /// Displays the menu at the specified position.
        /// </summary>
        /// <param name="control">The control that owns the menu.</param>
        /// <param name="position">The position relative to the screen that the menu should be shown from.</param>
        /// <param name="alignment">The direction relative to the position that the menu should be shown from.</param>
        /// <param name="highlightBehavior">Value from <see cref="BetterMenuHighlightBehavior"/> indicating the highlight behavior when this root menu is shown.</param>
        public virtual void Show(Control control, Point position, LeftRightAlignment alignment, BetterMenuHighlightBehavior highlightBehavior)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int flags = NativeMethods.TPM_VERTICAL | NativeMethods.TPM_RIGHTBUTTON;

            if (alignment == LeftRightAlignment.Left)
            {
                flags |= NativeMethods.TPM_RIGHTALIGN;
            }
            else
            {
                flags |= NativeMethods.TPM_LEFTALIGN;
            }

            Show(control, position, flags, highlightBehavior);
        }

        /// <summary>
        /// Displays the menu at the specified position.
        /// </summary>
        /// <param name="control">The control that owns the menu.</param>
        /// <param name="position">The position relative to the screen that the menu should be shown from.</param>
        /// <param name="flags">The native flags used to control the behavior of the menu.</param>
        /// <param name="highlightBehavior">Value from <see cref="BetterMenuHighlightBehavior"/> indicating the highlight behavior when this root menu is shown.</param>
        private protected virtual void Show(Control control, Point position, int flags, BetterMenuHighlightBehavior highlightBehavior)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            _sourceControl = control;
            _wndProcSubclass = new BetterMenuWndProcSubclass(SourceControl);

            position = control.PointToScreen(position);

            ShowHighlightBehavior = highlightBehavior;
            RecreateHandle();

            OnPopup(new EventArgs());
            
            SafeNativeMethods.TrackPopupMenuEx(GetHandleRef(), flags, position.X, position.Y, new HandleRef(control, control.Handle), null);

            ShowHighlightBehavior = BetterMenuHighlightBehavior.Default;

            OnCollapse(new EventArgs());

            _wndProcSubclass.ReleaseHandle();
            _wndProcSubclass = null;
            _sourceControl = null;
        }
    }
}