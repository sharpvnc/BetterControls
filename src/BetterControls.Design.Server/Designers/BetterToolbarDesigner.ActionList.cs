using Microsoft.DotNet.DesignTools.Designers.Actions;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace BetterControls.Design
{
    /// <summary>
    /// Designer for <see cref="BetterToolbar"/>.
    /// </summary>
    internal partial class BetterToolbarDesigner
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override DesignerActionListCollection ActionLists => new DesignerActionListCollection()
        {
            new ActionList(this)
        };

        /// <summary>
        /// Adds a <see cref="BetterToolbarPushButton"/> to the toolbar.
        /// </summary>
        protected void AddPushButton() => AddItem<BetterToolbarPushButton>();

        /// <summary>
        /// Adds a <see cref="BetterToolbarToggleButton"/> to the toolbar.
        /// </summary>
        protected void AddToggleButton() => AddItem<BetterToolbarToggleButton>();

        /// <summary>
        /// Adds a <see cref="BetterToolbarDropDownButton"/> to the toolbar.
        /// </summary>
        protected void AddDropDownButton() => AddItem<BetterToolbarDropDownButton>();

        /// <summary>
        /// Adds a <see cref="BetterToolbarSeparator"/> to the toolbar.
        /// </summary>
        protected void AddSeparator() => AddItem<BetterToolbarSeparator>();

        /// <summary>
        /// Adds a new <typeparamref name="TItemType"/> to the toolbar.
        /// </summary>
        /// <typeparam name="TItemType">The type of item to add extending from <see cref="BetterToolbarItem"/>.</typeparam>
        private protected void AddItem<TItemType>()
            where TItemType : BetterToolbarItem
        {
            DesignerTransaction transaction = null;

            try
            {
                transaction = DesignerHost.CreateTransaction("Inserting Item");

                TItemType button = (TItemType)DesignerHost.CreateComponent(typeof(TItemType));

                MemberDescriptor itemsMember = TypeDescriptor.GetProperties(Component!)[nameof(BetterToolbar.Items)];

                RaiseComponentChanging(itemsMember);

                PropertyDescriptor nameProperty = TypeDescriptor.GetProperties(button)["Name"];
                if (nameProperty != null && nameProperty.PropertyType == typeof(string))
                {
                    string itemText = (string)nameProperty.GetValue(button);

                    PropertyDescriptor textProperty = TypeDescriptor.GetProperties(button)["Text"];
                    if (textProperty != null)
                    {
                        textProperty.SetValue(button, itemText);
                    }
                }

                ((BetterToolbar)Component!).Items.Add(button);

                RaiseComponentChanged(itemsMember);
            }
            finally
            {
                transaction?.Commit();
            }

            Refresh();
        }

        /// <summary>
        /// Action list for <see cref="BetterToolbar"/>.
        /// </summary>
        private class ActionList : BetterControlActionList
        {
            /// <summary>
            /// Initialize a new instance of <see cref="ActionList"/>.
            /// </summary>
            /// <param name="designer">The designer that is associated with this action list.</param>
            public ActionList(BetterToolbarDesigner designer)
                : base(designer)
            { }

            /// <summary>
            /// Invokes the <see cref="BetterToolbar.Items"/> property.
            /// </summary>
            public void InvokeItemsProperty() => Designer.InvokePropertyEditor("Items");

            /// <summary>
            /// Invokes the 'Add Push Button' action list item.
            /// </summary>
            public void InvokeAddPushButton() => ((BetterToolbarDesigner)Designer).AddPushButton();

            /// <summary>
            /// Invokes the 'Add Toggle Button' action list item.
            /// </summary>
            public void InvokeAddToggleButton() => ((BetterToolbarDesigner)Designer).AddToggleButton();

            /// <summary>
            /// Invokes the 'Add Drop-down Button' action list item.
            /// </summary>
            public void InvokeAddDropDownButton() => ((BetterToolbarDesigner)Designer).AddDropDownButton();

            /// <summary>
            /// Invokes the 'Add Separator' action list item.
            /// </summary>
            public void InvokeAddSeparator() => ((BetterToolbarDesigner)Designer).AddSeparator();

            /// <summary>
            /// Invokes the 'Dock in Parent Container'/'Undock in Parent Container' action list item.
            /// </summary>
            public void InvokeDock()
            {
                using DesignerTransaction transaction = DesignerHost.CreateTransaction();

                PropertyDescriptor dockProperty = TypeDescriptor.GetProperties(Component)["Dock"];
                DockStyle dock = (DockStyle)dockProperty.GetValue(Component);
                if (dock != DockStyle.None)
                {
                    dockProperty.SetValue(Component, DockStyle.None);
                }
                else
                {
                    dockProperty.SetValue(Component, DockStyle.Top);
                }

                transaction.Commit();
            }

            /// <summary>
            /// Gets the name of the dock action.
            /// </summary>
            /// <returns>The name of the dock action.</returns>
            private string GetDockActionName()
            {
                PropertyDescriptor dockProperty = TypeDescriptor.GetProperties(Component)["Dock"];
                if (dockProperty != null && dockProperty.PropertyType == typeof(DockStyle))
                {
                    DockStyle dock = (DockStyle)dockProperty.GetValue(Component);
                    if (dock != DockStyle.None)
                    {
                        return "Undock in Parent Container";
                    }
                    else
                    {
                        return "Dock in Parent Container";
                    }
                }
                return null;
            }

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <returns><inheritdoc/></returns>
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeDock),
                    GetDockActionName(),
                    false));
                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeItemsProperty),
                    "Edit Items...",
                    true));
                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeAddPushButton),
                    "Add Push Button",
                    true));
                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeAddToggleButton),
                    "Add Toggle Button",
                    true));
                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeAddDropDownButton),
                    "Add Drop-down Button",
                    true));
                actionItems.Add(new DesignerActionMethodItem(
                    this,
                    nameof(InvokeAddSeparator),
                    "Add Separator",
                    true));

                return actionItems;
            }
        }
    }
}