namespace BetterControls
{
    /// <summary>
    /// Represents a toolbar button.
    /// </summary>
    public class BetterToolbarPushButton : BetterToolbarClickableButton
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        public BetterToolbarPushButton() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public BetterToolbarPushButton(string text)
            : base(text)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public BetterToolbarPushButton(string text, string description)
            : base(text, description)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarPushButton(string text, int imageIndex)
            : base(text, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarPushButton(string text, string description, int imageIndex)
            : base(text, description, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarPushButton"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarPushButton(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        private protected override BetterToolbarItem CreateClone() => new BetterToolbarPushButton();
    }
}