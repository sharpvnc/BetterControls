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

using BetterControls.VisualStyles;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a menu item that is a button.
    /// </summary>
    partial class BetterMenuButton
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        internal override NativeMethods.MENUITEMINFO_T ComputeMenuItemInfoT()
        {
            NativeMethods.MENUITEMINFO_T structure = base.ComputeMenuItemInfoT();

            if (!Enabled)
                structure.fState |= NativeMethods.MFS_DISABLED;
            if (Checked)
                structure.fState |= NativeMethods.MFS_CHECKED;
            if (CheckStyle == BetterMenuItemCheckStyle.Radio)
                structure.fType |= NativeMethods.MFT_RADIOCHECK;
            if (OwnerDraw)
                structure.fType |= NativeMethods.MFT_OWNERDRAW;

            if (OwnerMenu == MenuRoot && MenuRoot.ShowHighlightBehavior == BetterMenuHighlightBehavior.HighlightFirstItem && DisplayedItemIndex == 0)
            {
                structure.fState |= NativeMethods.MFS_HILITE;
            }
            else if (OwnerMenu == MenuRoot && MenuRoot.ShowHighlightBehavior == BetterMenuHighlightBehavior.HighlightFirstItemExclusive)
            {
                if (DisplayedItemIndex == 0)
                    structure.fState |= NativeMethods.MFS_HILITE;
            }
            else if (Highlight)
            {
                structure.fState |= NativeMethods.MFS_HILITE;
            }

            structure.fMask |= NativeMethods.MIIM_BITMAP | NativeMethods.MIIM_STRING;

            // The image in the native structure is also used as a mechanism to set the height of each item
            // and the width of the status area.
            using (Bitmap bitmap = CreateStatusImage())
                structure.hbmpItem = bitmap.GetHbitmap(Color.FromArgb(0, 0, 0, 0));

            string text = Text;

            if (string.IsNullOrEmpty(text))
                text = " ";

            structure.dwTypeData = text;

            // Setup the text for the menu item. If a shortkey key is specified and showing shortcuts is enabled, then the shortcut
            // string literal is appended to the end of the text. Item text should not be empty, so this is checked.
            if (ShowShortcut && Shortcut != Shortcut.None && Items.IsEmpty)
                structure.dwTypeData += "\t" + TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString((Keys)(int)Shortcut);

            return structure;
        }



        /// <summary>
        /// Creates the status image for this item.
        /// </summary>
        /// <returns>The created image as an instance of <see cref="Bitmap"/>.</returns>
        private protected virtual Bitmap CreateStatusImage()
        {
            if (OwnerMenu is null)
                return null;

            int statusColumnWidth = 16;
            int itemHeight = 16;

            if (!OwnerMenu.AutoSizeItems && OwnerMenu.CustomStatusWidth != 0)
                statusColumnWidth = OwnerMenu.CustomStatusWidth;

            if (!AutoSize && CustomHeight != 0)
                itemHeight = CustomHeight;

            int computedWidth = statusColumnWidth;

            if (!Application.RenderWithVisualStyles)
                computedWidth += 5;

            Bitmap bitmap = new Bitmap(computedWidth, itemHeight, PixelFormat.Format32bppPArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
                OnPaintStatus(new BetterMenuItemPaintStatusEventArgs(graphics, new Rectangle(0, 0, statusColumnWidth, itemHeight)));

            bitmap.MakeTransparent();

            return bitmap;
        }




        public class Helper
        {
            #region Win32 Native APIs
            internal class NativeMethods
            {
                // CreateDIBSection funcation iUsage value
                internal const int DIB_RGB_COLORS = 0x00;
                internal const int DIB_PAL_COLORS = 0x01;
                internal const int DIB_PAL_INDICES = 0x02;

                [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
                internal static extern bool DeleteObject(IntPtr hObject);

                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                internal static extern int InvalidateRect(IntPtr hwnd, IntPtr rect, int bErase);

                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                internal static extern IntPtr GetDC(IntPtr hwnd);

                [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
                internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

                [DllImport("user32.dll", CharSet = CharSet.Unicode)]
                internal static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

                [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
                internal static extern int DeleteDC(IntPtr hdc);

                [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
                internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

                [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
                internal static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO bmi, uint iUsage,
                    out IntPtr bits, IntPtr hSection, uint dwOffset);

                [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RtlMoveMemory")]
                internal static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

                [StructLayout(LayoutKind.Sequential)]
                internal struct BITMAPINFO
                {
                    public Int32 biSize;
                    public Int32 biWidth;
                    public Int32 biHeight;
                    public Int16 biPlanes;
                    public Int16 biBitCount;
                    public Int32 biCompression;
                    public Int32 biSizeImage;
                    public Int32 biXPelsPerMeter;
                    public Int32 biYPelsPerMeter;
                    public Int32 biClrUsed;
                    public Int32 biClrImportant;
                }
            }
            #endregion

            public static Image VisualStyleRendererToImage(VisualStyleRenderer renderer, Rectangle bounds, bool check)
            {
                if (ToolStripManager.VisualStylesEnabled)
                {
                    using (Bitmap bit = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
                    {
                        NativeMethods.BITMAPINFO bmi = new NativeMethods.BITMAPINFO();

                        bmi.biWidth = bit.Width;
                        bmi.biHeight = -bit.Height;
                        bmi.biPlanes = 1;
                        bmi.biBitCount = 32;
                        bmi.biXPelsPerMeter = (int)bit.HorizontalResolution;
                        bmi.biYPelsPerMeter = (int)bit.VerticalResolution;
                        bmi.biSize = Marshal.SizeOf(typeof(NativeMethods.BITMAPINFO));

                        IntPtr bits;
                        IntPtr bmp = NativeMethods.CreateDIBSection(IntPtr.Zero, ref bmi,
                            NativeMethods.DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);

                        IntPtr dc = NativeMethods.GetDC(IntPtr.Zero);
                        IntPtr hdc = NativeMethods.CreateCompatibleDC(dc);
                        NativeMethods.SelectObject(hdc, bmp);

                        using (Graphics g = Graphics.FromHdc(hdc))
                        {
                            if (check)
                            {
                                MenuItemCheckRenderer.DrawCheck(g, new Point(0, 0), true);
                            }
                            else
                            {
                                MenuItemRadioRenderer.DrawRadio(g, new Point(0, 0), true);
                            }
                        }

                        Bitmap image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb);

                        using (Bitmap tempImage = new Bitmap(bounds.Width, bounds.Height, bounds.Width * 4,
                            PixelFormat.Format32bppPArgb, bits))
                        {
                            BitmapData tempBitmapData = tempImage.LockBits(bounds, ImageLockMode.ReadOnly,
                                PixelFormat.Format32bppPArgb);
                            BitmapData bitmapData = image.LockBits(bounds, ImageLockMode.WriteOnly,
                                PixelFormat.Format32bppPArgb);

                            NativeMethods.CopyMemory(bitmapData.Scan0, tempBitmapData.Scan0,
                                (uint)tempBitmapData.Stride * (uint)tempBitmapData.Height);

                            tempImage.UnlockBits(tempBitmapData);
                            image.UnlockBits(bitmapData);
                        }

                        NativeMethods.DeleteObject(bmp);
                        NativeMethods.DeleteDC(hdc);
                        NativeMethods.ReleaseDC(IntPtr.Zero, dc);

                        return image;
                    }
                }
                else
                {
                    return new Bitmap(bounds.Width, bounds.Height);
                }
            }
        }
    }
}