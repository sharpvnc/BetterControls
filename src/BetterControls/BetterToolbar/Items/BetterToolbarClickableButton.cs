using System;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create a toolbar item that is a clickable button.
    /// </summary>
    public abstract partial class BetterToolbarClickableButton : BetterToolbarButton
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        public BetterToolbarClickableButton() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        public BetterToolbarClickableButton(string text)
            : base(text)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        public BetterToolbarClickableButton(string text, string description)
            : base(text, description)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarClickableButton(string text, int imageIndex)
            : base(text, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        /// <param name="text">The text of the button.</param>
        /// <param name="description">The description of the button.</param>
        /// <param name="imageIndex">The index of the image from the toolbar image list to be shown in the button.</param>
        public BetterToolbarClickableButton(string text, string description, int imageIndex)
            : base(text, description, imageIndex)
        { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarClickableButton"/>.
        /// </summary>
        /// <param name="ownerToolbar">The owner toolbar as an instance of <see cref="BetterToolbar"/>.</param>
        private protected BetterToolbarClickableButton(BetterToolbar ownerToolbar)
            : base(ownerToolbar)
        { }

        /// <summary>
        /// Simulates clicking the toolbar button.
        /// </summary>
        public void PerformClick()
        {
            if (Enabled)
            {
                // Get whether the button is pressed. This should be done directly by the relevant
                // API call, and can then be used to update the internal pressed state as necessary.
                if (IsOwnerHandleCreated)
                {
                    bool pressed = Convert.ToBoolean((int)UnsafeNativeMethods.SendMessage(GetHandleRef(), NativeMethods.TB_ISBUTTONPRESSED, UniqueIdentifier, 0));

                    Pressed = pressed;
                }

                OnClick(EventArgs.Empty);
            }
        }
    }
}