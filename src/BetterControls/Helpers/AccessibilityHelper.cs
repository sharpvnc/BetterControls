using System;
using System.Runtime.InteropServices;

namespace BetterControls.Helpers
{
    internal static class AccessibilityHelper
    {
        /// <summary>
        /// Determines whether or not a <see cref="string"/> contains a mnemonic.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to determine whether or not contains a mnemonic.</param>
        /// <returns><A <see cref="bool"/> value indicating whether or not a <see cref="string"/> contains a mnemonic.</returns>
        internal static bool ContainsMnemonic(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            int textLength = text.Length;
            int firstAmpersand = text.IndexOf('&', 0);
            if (firstAmpersand >= 0 && firstAmpersand <= textLength - 2)
            {
                return text.IndexOf('&', firstAmpersand + 1) == -1;
            }

            return false;
        }

        /// <summary>
        /// Shows keyboard accelerators for the specified handle.
        /// </summary>
        /// <param name="handle">The handle to show keyboard accelerators for.</param>
        internal static void ShowKeyboardAccelerators(HandleRef handle)
        {
            UnsafeNativeMethods.SendMessage(handle, NativeMethods.WM_UPDATEUISTATE, (IntPtr)(NativeMethods.UIS_CLEAR | (NativeMethods.UISF_HIDEACCEL << 16)), IntPtr.Zero);
        }

        /// <summary>
        /// Hides keyboard accelerators for the specified handle.
        /// </summary>
        /// <param name="handle">The handle to hide keyboard accelerators for.</param>
        internal static void HideKeyboardAccelerators(HandleRef handle)
        {
            UnsafeNativeMethods.SendMessage(handle, NativeMethods.WM_UPDATEUISTATE, (IntPtr)(NativeMethods.UIS_SET | (NativeMethods.UISF_HIDEACCEL << 16)), IntPtr.Zero);
        }
    }
}