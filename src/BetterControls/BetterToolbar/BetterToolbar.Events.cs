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
using System.ComponentModel;

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Toolbar classes.
    /// </summary>
    partial class BetterToolbar
    {
        /// <summary>
        /// This method is raised before a drop-down button has been clicked with the intention of showing the drop-down menu.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="BetterToolbarMenuDroppedDownEventArgs"/></param>
        protected virtual void OnBeforeMenuDroppedDown(BetterToolbarMenuDroppedDownEventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            BeforeMenuDroppedDown?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised after a drop-down button has been clicked and has shown the drop-down menu.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="BetterToolbarMenuDroppedDownEventArgs"/></param>
        protected virtual void OnAfterMenuDroppedDown(BetterToolbarMenuDroppedDownEventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            AfterMenuDroppedDown?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Appearance"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnAppearanceChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            AppearanceChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="BorderStyle"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnBorderStyleChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            BorderStyleChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Divider"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnDividerChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            DividerChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="DropDownArrows"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnDropDownArrowsChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            DropDownArrowsChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ImageList"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageListChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageListChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ImageSize"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnImageSizeChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ImageSizeChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="ShowToolTips"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnShowToolTipsChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ShowToolTipsChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="TextAlign"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnTextAlignChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            TextAlignChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="Wrappable"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnWrappableChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            WrappableChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised before a drop-down button has been clicked with the intention of showing the drop-down menu.
        /// </summary>
        public event EventHandler<BetterToolbarMenuDroppedDownEventArgs> BeforeMenuDroppedDown;

        /// <summary>
        /// This event is raised after a drop-down button has been clicked and has shown the drop-down menu.
        /// </summary>
        public event EventHandler<BetterToolbarMenuDroppedDownEventArgs> AfterMenuDroppedDown;

        /// <summary>
        /// This event is raised <see cref="Appearance"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> AppearanceChanged;

        /// <summary>
        /// This event is raised <see cref="BorderStyle"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> BorderStyleChanged;

        /// <summary>
        /// This event is raised <see cref="Divider"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> DividerChanged;

        /// <summary>
        /// This event is raised <see cref="DropDownArrows"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> DropDownArrowsChanged;

        /// <summary>
        /// This event is raised after <see cref="ImageList"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageListChanged;

        /// <summary>
        /// This event is raised after <see cref="ImageSize"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ImageSizeChanged;

        /// <summary>
        /// This event is raised after <see cref="ShowToolTips"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ShowToolTipsChanged;

        /// <summary>
        /// This event is raised after <see cref="ShowToolTips"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> TextAlignChanged;

        /// <summary>
        /// This event is raised after <see cref="Wrappable"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> WrappableChanged;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add => base.ImeModeChanged += value;
            remove => base.ImeModeChanged -= value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add => base.ForeColorChanged += value;
            remove => base.ForeColorChanged -= value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add => base.RightToLeftChanged += value;
            remove => base.RightToLeftChanged -= value;
        }
    }
}