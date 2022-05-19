using System;
using WinForms.Tiles.ClientServerProtocol;

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
        /// <param name="collectionType">The type that this collection editor is associated with.</param>
        public BetterToolbarItemCollectionEditor(Type collectionType)
            : base(collectionType)
        { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override string Name => CollectionEditorNames.BetterToolbarItemCollectionEditor;
    }
}