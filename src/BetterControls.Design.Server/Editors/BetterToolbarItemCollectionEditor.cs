using System;

namespace BetterControls.Design
{
    /// <summary>
    /// Represents the collection editor client for a collection of toolbar items.
    /// </summary>
    internal partial class BetterToolbarItemCollectionEditor : BetterCollectionEditor
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarItemCollectionEditor"/>.
        /// </summary>
        /// <param name="services">The service provider as an instance of <see cref="IServiceProvider"/>.</param>
        /// <param name="collectionType">The type that this collection editor is associated with.</param>
        public BetterToolbarItemCollectionEditor(IServiceProvider services, Type collectionType)
            : base(services, collectionType)
        { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        protected override Type[] CreateNewItemTypes()
        {
            return new Type[]
            {
                typeof(BetterToolbarPushButton),
                typeof(BetterToolbarToggleButton),
                typeof(BetterToolbarDropDownButton),
                typeof(BetterToolbarSeparator)
            };
        }
    }
}