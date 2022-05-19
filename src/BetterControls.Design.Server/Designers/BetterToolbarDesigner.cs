using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BetterControls.Design
{
    /// <summary>
    /// Designer for <see cref="BetterToolbar"/>.
    /// </summary>
    internal partial class BetterToolbarDesigner : BetterControlDesigner
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarDesigner"/>.
        /// </summary>
        public BetterToolbarDesigner() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;

                PropertyDescriptor dockProperty = TypeDescriptor.GetProperties(Component)["Dock"];
                PropertyDescriptor autoSizeProperty = TypeDescriptor.GetProperties(Component)["AutoSize"];
                if (dockProperty != null && autoSizeProperty != null)
                {
                    DockStyle dock = (DockStyle)dockProperty.GetValue(Component);
                    bool autoSize = (bool)autoSizeProperty.GetValue(Component);
                    if (autoSize)
                    {
                        selectionRules &= ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable);
                        if (dock != DockStyle.None)
                            selectionRules &= ~SelectionRules.AllSizeable;
                    }
                }

                return selectionRules;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="defaultValues"><inheritdoc/></param>
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            PropertyDescriptor dockProperty = TypeDescriptor.GetProperties(Component)["Dock"];
            if (dockProperty != null && dockProperty.PropertyType == typeof(DockStyle))
            {
                dockProperty.SetValue(Component, DockStyle.Top);
            }
        }

        protected override void OnMouseDragEnd(bool cancel, Keys modifierKeys)
        {
            base.OnMouseDragEnd(cancel, modifierKeys);
        }



        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override IReadOnlyCollection<IComponent> AssociatedComponents
        {
            get
            {
                if (Control is BetterToolbar toolbar)
                {
                    List<IComponent> items = new List<IComponent>();

                    foreach (BetterToolbarItem item in toolbar.Items)
                    {
                        items.Add(item);

                        if (item is BetterToolbarDropDownButton button)
                        {
                            if (button.DropDownMenu != null)
                            {
                                foreach (BetterMenuItem menuItem in button.DropDownMenu.Items)
                                {
                                    items.Add(menuItem);
                                }
                            }
                        }
                    }

                    return items.AsReadOnly();
                }

                return base.AssociatedComponents;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ((BetterToolbar)Component).UpdateItemDimensions();
        }



        protected void Refresh()
        {
            DesignerActionUIService das = GetService<DesignerActionUIService>();
            das?.Refresh(Component!);
        }
    }
}
