using System;
using System.Globalization;

namespace BetterControls
{
    /// <summary>
    /// Helper class containing string utilities.
    /// </summary>
    internal class StringUtilities
    {
        /// <summary>
        /// Gets the mnemonic, if any, from the specified string.
        /// </summary>
        /// <param name="text">The string from which to get the mnemonic, if any.</param>
        /// <param name="upperCase">A <see cref="bool"/> value indicating whether or not to convert the mnemonic to upper case.</param>
        /// <returns>The string mnemonic as a <see cref="char"/> value.</returns>
        internal static char GetMnemonic(string text, bool upperCase)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == '&')
                {
                    if (text[i + 1] == '&')
                    {
                        i++;

                        continue;
                    }
                    if (upperCase)
                    {
                        return char.ToUpper(text[i + 1], CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        return char.ToLower(text[i + 1], CultureInfo.CurrentCulture);
                    }
                }
            }

            return default;
        }
    }
}