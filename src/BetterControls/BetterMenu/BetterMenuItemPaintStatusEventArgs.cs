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

namespace BetterControls
{
    /// <summary>
    /// Event arguments for when the status part of each menu item is painted.
    /// </summary>
    public class BetterMenuItemPaintStatusEventArgs
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterMenuItemPaintStatusEventArgs"/>.
        /// </summary>
        /// <param name="graphics">The graphics associated with this paint operation.</param>
        /// <param name="bounds">The outer bounds of this paint operation.</param>
        internal BetterMenuItemPaintStatusEventArgs(Graphics graphics, Rectangle bounds)
        {
            Graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
            Bounds = bounds;
        }

        /// <summary>
        /// Gets the device context associated with this paint operation.
        /// </summary>
        public IDeviceContext DeviceContext => Graphics;

        /// <summary>
        /// Gets the graphics associated with this paint operation.
        /// </summary>
        public Graphics Graphics { get; }

        /// <summary>
        /// Gets the outer bounds of this paint operation.
        /// </summary>
        public Rectangle Bounds { get; }
    }
}