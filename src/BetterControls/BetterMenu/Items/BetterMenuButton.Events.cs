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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a menu item that is a button.
    /// </summary>
    partial class BetterMenuButton
    {
        /// <summary>
        /// This method is raised when <see cref="AutoSize"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnAutoSizeChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            AutoSizeChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Checked"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            CheckedChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="CheckStyle"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnCheckStyleChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            CheckStyleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when the menu item is clicked.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnClick(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Click?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="CustomHeight"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnCustomHeightChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            CustomHeightChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Description"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnDescriptionChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            DescriptionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Enabled"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            EnabledChanged?.Invoke(this, e);
        }

        /// <summary>
        /// this method is raised when the menu item is focused.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnFocused(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Focused?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Highlight"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnHighlightChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            HighlightChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Image"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ImageAlign"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageAlignChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageAlignChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ImageIndex"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageIndexChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageIndexChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ImageKey"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageKeyChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageKeyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="OwnerDraw"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnOwnerDrawChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            OwnerDrawChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when the status part of this item is painted.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="BetterMenuItemPaintStatusEventArgs"/>.</param>
        protected virtual void OnPaintStatus(BetterMenuItemPaintStatusEventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (OwnerMenu is null)
                return;

            Image image = Image;

            if (image is null && MenuRoot.ImageList != null && ImageIndexer.ComputedIndex != -1)
                image = MenuRoot.ImageList.Images[ImageIndexer.ComputedIndex];

            if (UseShieldImage)
                image = IconUtilities.GetShieldImage();

            if (image != null)
            {
                int croppedWidth = image.Width;
                int croppedHeight = image.Height;

                if (croppedWidth > e.Bounds.Width)
                    croppedWidth = e.Bounds.Width;
                if (croppedHeight > e.Bounds.Height)
                    croppedHeight = e.Bounds.Height;

                Bitmap croppedImage = new Bitmap(croppedWidth, croppedHeight);

                using (Graphics graphics = Graphics.FromImage(croppedImage))
                    graphics.DrawImage(image, -0, -0);

                int x = 0;
                int y = 0;

                switch (ImageAlign)
                {
                    case BetterMenuButtonImageAlign.TopMiddle:
                        x = (e.Bounds.Width - croppedWidth) / 2;
                        break;
                    case BetterMenuButtonImageAlign.TopRight:
                        x = e.Bounds.Width - croppedWidth;
                        break;
                    case BetterMenuButtonImageAlign.MiddleLeft:
                        y = (e.Bounds.Height - croppedHeight) / 2;
                        break;
                    case BetterMenuButtonImageAlign.MiddleMiddle:
                        x = (e.Bounds.Width - croppedWidth) / 2;
                        y = (e.Bounds.Height - croppedHeight) / 2;
                        break;
                    case BetterMenuButtonImageAlign.MiddleRight:
                        x = e.Bounds.Width - croppedWidth;
                        y = (e.Bounds.Height - croppedHeight) / 2;
                        break;
                    case BetterMenuButtonImageAlign.BottomLeft:
                        y = e.Bounds.Height - croppedHeight;
                        break;
                    case BetterMenuButtonImageAlign.BottomMiddle:
                        x = (e.Bounds.Width - croppedWidth) / 2;
                        y = e.Bounds.Height - croppedHeight;
                        break;
                    case BetterMenuButtonImageAlign.BottomRight:
                        x = e.Bounds.Width - croppedWidth;
                        y = e.Bounds.Height - croppedHeight;
                        break;
                }

                e.Graphics.DrawImage(croppedImage, x, y, croppedWidth, croppedHeight);
            }

            OnPaintCheck(e);

            PaintStatus?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when the check image of this item is painted.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="BetterMenuItemPaintStatusEventArgs"/>.</param>
        protected virtual void OnPaintCheck(BetterMenuItemPaintStatusEventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (CheckStyle == BetterMenuItemCheckStyle.Disabled)
                return;

            Bitmap checkBitmap = (Bitmap)Helper.VisualStyleRendererToImage(null, new Rectangle(0, 0, 16, 16), CheckStyle == BetterMenuItemCheckStyle.Check);

            int x = 0;
            int y = 0;

            switch (CheckAlign)
            {
                case BetterMenuButtonImageAlign.TopMiddle:
                    x = (e.Bounds.Width - checkBitmap.Width) / 2;
                    break;
                case BetterMenuButtonImageAlign.TopRight:
                    x = e.Bounds.Width - checkBitmap.Width;
                    break;
                case BetterMenuButtonImageAlign.MiddleLeft:
                    y = (e.Bounds.Height - checkBitmap.Height) / 2;
                    break;
                case BetterMenuButtonImageAlign.MiddleMiddle:
                    x = (e.Bounds.Width - checkBitmap.Width) / 2;
                    y = (e.Bounds.Height - checkBitmap.Height) / 2;
                    break;
                case BetterMenuButtonImageAlign.MiddleRight:
                    x = e.Bounds.Width - checkBitmap.Width;
                    y = (e.Bounds.Height - checkBitmap.Height) / 2;
                    break;
                case BetterMenuButtonImageAlign.BottomLeft:
                    y = e.Bounds.Height - checkBitmap.Height;
                    break;
                case BetterMenuButtonImageAlign.BottomMiddle:
                    x = (e.Bounds.Width - checkBitmap.Width) / 2;
                    y = e.Bounds.Height - checkBitmap.Height;
                    break;
                case BetterMenuButtonImageAlign.BottomRight:
                    x = e.Bounds.Width - checkBitmap.Width;
                    y = e.Bounds.Height - checkBitmap.Height;
                    break;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(checkBitmap, x, y, checkBitmap.Width, checkBitmap.Height);

            PaintCheck?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Shortcut"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnShortcutChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ShortcutChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ShowShortcut"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnShowShortcutChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ShowShortcutChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Text"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnTextChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            TextChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="UseShieldImage"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnUseShieldImageChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            UseShieldImageChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised when <see cref="AutoSize"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> AutoSizeChanged;

        /// <summary>
        /// This event is raised when <see cref="Checked"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> CheckedChanged;

        /// <summary>
        /// This event is raised when <see cref="CheckStyle"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> CheckStyleChanged;

        /// <summary>
        /// This event is raised when the menu item is clicked.
        /// </summary>
        public event EventHandler<EventArgs> Click;

        /// <summary>
        /// This event is raised when <see cref="CustomHeight"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> CustomHeightChanged;

        /// <summary>
        /// This event is raised when <see cref="Description"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> DescriptionChanged;

        /// <summary>
        /// This event is raised when <see cref="Enabled"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> EnabledChanged;

        /// <summary>
        /// This event is raised when the menu item is focused.
        /// </summary>
        public event EventHandler<EventArgs> Focused;

        /// <summary>
        /// This event is raised when <see cref="Highlight"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> HighlightChanged;

        /// <summary>
        /// This event is raised when <see cref="Image"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageChanged;

        /// <summary>
        /// This event is raised when <see cref="ImageAlign"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageAlignChanged;

        /// <summary>
        /// This event is raised when <see cref="ImageIndex"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageIndexChanged;

        /// <summary>
        /// This event is raised when <see cref="ImageKey"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageKeyChanged;

        /// <summary>
        /// This event is raised when <see cref="OwnerDraw"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> OwnerDrawChanged;

        /// <summary>
        /// This event is raised when the status part of this item is painted.
        /// </summary>
        public event EventHandler<BetterMenuItemPaintStatusEventArgs> PaintStatus;

        /// <summary>
        /// This event is raised when the status part of this item is painted.
        /// </summary>
        public event EventHandler<BetterMenuItemPaintStatusEventArgs> PaintCheck;

        /// <summary>
        /// This event is raised when <see cref="Shortcut"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ShortcutChanged;

        /// <summary>
        /// This event is raised when <see cref="ShowShortcut"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ShowShortcutChanged;

        /// <summary>
        /// This event is raised when <see cref="Text"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> TextChanged;

        /// <summary>
        /// This event is raised when <see cref="UseShieldImage"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> UseShieldImageChanged;
    }
}