using Microsoft.DotNet.DesignTools.TypeRouting;
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
            => new[]
            {
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(BetterToolbarDesigner),
                    typeof(BetterToolbarDesigner)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(BetterToolbarItemDesigner),
                    typeof(BetterToolbarItemDesigner)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(BetterToolbarButtonDesigner),
                    typeof(BetterToolbarButtonDesigner)),
                new TypeRoutingDefinition(
                    TypeRoutingKinds.Designer,
                    nameof(BetterMenuBarDesigner),
                    typeof(BetterMenuBarDesigner))
            };
    }
}