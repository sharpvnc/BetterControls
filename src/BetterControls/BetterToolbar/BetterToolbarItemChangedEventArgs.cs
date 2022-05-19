using System;

namespace BetterControls
{
    /// <summary>
    /// Event arguments for when a toolbar item is changed.
    /// </summary>
    public class BetterToolbarItemChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarItemChangedEventArgs"/>.
        /// </summary>
        /// <param name="changeType">The way the item was changed.</param>
        /// <param name="items">The item that was changed as an instance of <see cref="BetterToolbarItem"/>.</param>
        public BetterToolbarItemChangedEventArgs(BetterToolbarItemChangeType changeType, BetterToolbarItem item)
        {
            ChangeType = changeType;
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        /// <summary>
        /// Gets the way the item was changed
        /// </summary>
        public BetterToolbarItemChangeType ChangeType { get; }

        /// <summary>
        /// Gets the item that was changed as an instance of <see cref="BetterToolbarItem"/>.
        /// </summary>
        public BetterToolbarItem Item { get; }
    }
}