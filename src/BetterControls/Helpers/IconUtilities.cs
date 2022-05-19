using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Helper class for icon utilities.
    /// </summary>
    internal static class IconUtilities
    {
        private static Bitmap _shieldImage;

        /// <summary>
        /// Adds the system shield icon to a <see cref="Button"/>.
        /// </summary>
        /// <param name="button">The button to add the system shield icon to.</param>
        internal static void AddShield(this Button button)
        {
            button.FlatStyle = FlatStyle.System;

            UnsafeNativeMethods.SendMessage(new HandleRef(button, button.Handle), NativeMethods.BCM_SETSHIELD, 0, 1);
        }

        /// <summary>
        /// Gets the system shield icon as an instance of <see cref="Bitmap"/>.
        /// </summary>
        /// <returns>The system shield icon as an instance of <see cref="Bitmap"/>.</returns>
        public static Bitmap GetShieldImage()
        {
            if (_shieldImage != null)
            {
                return _shieldImage;
            }

            const int buttonWidth = 50;
            const int buttonHeight = 50;
            const int buttonMargin = 4;

            Button button = new Button()
            {
                Text = " ",
                Size = new Size(buttonWidth, buttonHeight)
            };

            // Set the shield icon on the button, and it'll be extracted from there.
            button.AddShield();

            // Create a ne bitmap that the button is drawn to.
            Bitmap buttonBitmap = new Bitmap(buttonWidth, buttonHeight);

            button.Refresh();
            button.DrawToBitmap(buttonBitmap, new Rectangle(new Point(0, 0), new Size(buttonWidth, buttonHeight)));

            int min_x = buttonWidth, max_x = 0, min_y = buttonHeight, max_y = 0;

            for (int y = buttonMargin; y < buttonHeight - buttonMargin; y++)
            {
                Color targetColor = buttonBitmap.GetPixel(buttonMargin, y);

                for (int x = buttonMargin; x < buttonWidth - buttonMargin; x++)
                {
                    if (buttonBitmap.GetPixel(x, y).Equals(targetColor))
                    {
                        buttonBitmap.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        if (min_y > y) min_y = y;
                        if (min_x > x) min_x = x;
                        if (max_y < y) max_y = y;
                        if (max_x < x) max_x = x;
                    }
                }
            }

            // Clip out the shield part.
            int shield_wid = max_x - min_x + 1;
            int shield_hgt = max_y - min_y + 1;

            _shieldImage = new Bitmap(shield_wid, shield_hgt);

            using (Graphics shield_gr = Graphics.FromImage(_shieldImage))
            {
                shield_gr.DrawImage(buttonBitmap, 0, 0, new Rectangle(min_x, min_y, shield_wid, shield_hgt), GraphicsUnit.Pixel);
            }

            return _shieldImage;
        }
    }
}