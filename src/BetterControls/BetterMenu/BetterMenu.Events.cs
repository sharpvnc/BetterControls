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

namespace BetterControls
{
    /// <summary>
    /// Wrapper of the Windows Menu classes.
    /// </summary>
    partial class BetterMenu
    {
        /// <summary>
        /// This method is raised when <see cref="AutoSizeItems"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnAutoSizeItemsChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            AutoSizeItemsChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="CustomStatusWidth"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnCustomStatusWidthChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            CustomStatusWidthChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This method is raised when <see cref="DefaultButton"/> has been changed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnDefaultButtonChanged(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            DefaultButtonChanged?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised <see cref="AutoSizeItems"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> AutoSizeItemsChanged;

        /// <summary>
        /// This event is raised <see cref="CustomStatusWidth"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> CustomStatusWidthChanged;

        /// <summary>
        /// This event is raised <see cref="DefaultButton"/> has been changed.
        /// </summary>
        public event EventHandler<EventArgs> DefaultButtonChanged;
    }
}