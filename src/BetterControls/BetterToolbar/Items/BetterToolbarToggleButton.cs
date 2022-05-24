namespace BetterControls
{
    /// <summary>
    /// Represents a toolbar item that is a toggle button.
    /// </summary>
    public partial class BetterToolbarToggleButton : BetterToolbarClickableButton
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        public BetterToolbarToggleButton() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public BetterToolbarToggleButton(string text)
            : base(text)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public BetterToolbarToggleButton(string text, string description)
            : base(text, description)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarToggleButton(string text, int imageIndex)
            : base(text, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarToggleButton(string text, string description, int imageIndex)
            : base(text, description, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarToggleButton"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarToggleButton(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        private protected override BetterToolbarItem CreateClone() => new BetterToolbarToggleButton();
    }
}