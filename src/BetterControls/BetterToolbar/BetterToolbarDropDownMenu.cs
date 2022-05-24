using System.ComponentModel;
using System.Windows.Forms;

namespace BetterControls
{
    /// <summary>
    /// Menu specifically designed for use with drop-down toolbar buttons.
    /// </summary>
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class BetterToolbarDropDownMenu : BetterMenuRoot
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownMenu"/>.
        /// </summary>
        public BetterToolbarDropDownMenu() { }

        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDropDownMenu"/>.
        /// </summary>
        /// <param name="item">The drop-down button that is associated with this drop-down menu.</param>
        public BetterToolbarDropDownMenu(BetterToolbarDropDownButton item)
        {
            ParentControl = item;
        }

        public object ParentControl { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageList ImageList
        {
            get
            {
                if (ParentControl is BetterToolbarDropDownButton item && item.OwnerElement is BetterToolbar toolbar)
                    return toolbar.MenuImageList;

                return null;
            }
            set { }
        }

        public void Recreate() => RecreateHandle();
    }
}