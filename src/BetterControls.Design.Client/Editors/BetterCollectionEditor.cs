using Microsoft.DotNet.DesignTools.Client.Editors;
using System;

namespace BetterControls.Design
{
    /// <summary>
    /// Extend this class to create a collection editor.
    /// </summary>
    public abstract class BetterCollectionEditor : CollectionEditor
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterCollectionEditor"/>.
        /// </summary>
        /// <param name="collectionType">The type that this collection editor is associated with.</param>
        public BetterCollectionEditor(Type collectionType)
            : base(collectionType)
        { }
    }
}