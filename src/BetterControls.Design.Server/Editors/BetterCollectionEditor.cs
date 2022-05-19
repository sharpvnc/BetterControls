using Microsoft.DotNet.DesignTools.Editors;
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
        /// <param name="services">The service provider as an instance of <see cref="IServiceProvider"/>.</param>
        /// <param name="collectionType">The type that this collection editor is associated with.</param>
        public BetterCollectionEditor(IServiceProvider services, Type collectionType)
            : base(services, collectionType)
        { }
    }
}