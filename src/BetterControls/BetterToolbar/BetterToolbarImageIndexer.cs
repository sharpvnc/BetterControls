using BetterControls.Drawing;
using System;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Used to provide a mechanism for a toolbar to support using both image indexes and image keys.
    /// </summary>
    public class BetterToolbarImageIndexer : ImageIndexer
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarImageIndexer"/>.
        /// </summary>
        /// <param name="parent">The parent toolbar item as an instance of <see cref="BetterToolbarItem"/>.</param>
        public BetterToolbarImageIndexer(BetterToolbarItem parent)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>
        /// Gets the parent toolbar item as an instance of <see cref="BetterToolbarItem"/>.
        /// </summary>
        public BetterToolbarItem Parent { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override ImageList ImageList
        {
            get
            {
                //if (Parent != null && Parent.Parent != null)
                //    return Parent.Parent.ImageList;

                return null;
            }
        }
    }
}