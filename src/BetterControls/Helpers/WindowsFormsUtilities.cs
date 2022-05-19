using System.Drawing;

namespace BetterControls
{
    /// <summary>
    /// Utility helpers for Windows Forms.
    /// </summary>
    public static class WindowsFormsUtilities
    {
        /// <summary>
        /// Gets the absolute pointer position.
        /// </summary>
        /// <returns>The absolute pointer position.</returns>
        public static Point GetPointerPosition()
        {
            NativeMethods.POINT pt = new NativeMethods.POINT();
            UnsafeNativeMethods.GetCursorPos(pt);

            return new Point(pt.x, pt.y);
        }
    }
}