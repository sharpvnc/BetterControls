namespace BetterControls
{
    /// <summary>
    /// Represents a toolbar separator.
    /// </summary>
    public partial class BetterToolbarSeparator : BetterToolbarItem
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarSeparator"/>.
        /// </summary>
        public BetterToolbarSeparator() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarSeparator"/>.
        /// </summary>
        /// <param name="parent">The parent toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarSeparator(BetterToolbar parent)
            : base(parent)
        { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        protected override int ComputeAutoSizeWidth()
        {
            return 8;
        }
    }
}