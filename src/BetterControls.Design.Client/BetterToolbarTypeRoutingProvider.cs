using BetterControls.Design.Protocol;
using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;

namespace BetterControls.Design
{
    /// <summary>
    /// Represents the toolbar type routing provider.
    /// </summary>
    [ExportTypeRoutingDefinitionProvider]
    internal class BetterToolbarTypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarTypeRoutingProvider"/>.
        /// </summary>
        public BetterToolbarTypeRoutingProvider() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
        {
            return new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.BetterToolbarItemCollectionEditor),
                    typeof(BetterToolbarItemCollectionEditor)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.BetterMenuBarItemCollectionEditor),
                    typeof(BetterMenuBarItemCollectionEditor)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.BetterMenuItemCollectionEditor),
                    typeof(BetterMenuItemCollectionEditor)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Editor,
                    nameof(EditorNames.ImageIndexEditor),
                    typeof(ImageIndexEditor)),
            };
        }
    }
}