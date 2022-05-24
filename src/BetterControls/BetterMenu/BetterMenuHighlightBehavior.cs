namespace BetterControls
{
    /// <summary>
    /// Highlight behavior for when a menu is shown.
    /// </summary>
    public enum BetterMenuHighlightBehavior
    {
        /// <summary>
        /// Doesn't change the highlight behavior. Menu items with <see cref="BetterMenuButton.Highlight"/> set to <see langword="true"/> will continue to highlight.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Highlights the first item in addition to any other items configured to highlight. Menu items with <see cref="BetterMenuButton.Highlight"/> set to <see langword="true"/> will continue to highlight.
        /// </summary>
        HighlightFirstItem = 1,
        /// <summary>
        /// Highlights the first item only. Menu items with <see cref="BetterMenuButton.Highlight"/> set to <see langword="true"/> will not continue to highlight.
        /// </summary>
        HighlightFirstItemExclusive = 2
    }
}