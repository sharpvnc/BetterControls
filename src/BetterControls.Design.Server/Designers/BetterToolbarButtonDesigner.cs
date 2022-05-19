using System.Collections;
using System.ComponentModel;

namespace BetterControls.Design
{
    /// <summary>
    /// Designer for <see cref="BetterToolbarButton"/>.
    /// </summary>
    internal class BetterToolbarButtonDesigner : BetterToolbarItemDesigner
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterToolbarButtonDesigner"/>.
        /// </summary>
        public BetterToolbarButtonDesigner() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="defaultValues"><inheritdoc/></param>
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            PropertyDescriptor nameProperty = TypeDescriptor.GetProperties(Component)["Name"];
            if (nameProperty != null && nameProperty.PropertyType == typeof(string))
            {
                string itemText = (string)nameProperty.GetValue(Component);

                PropertyDescriptor textProperty = TypeDescriptor.GetProperties(Component)["Text"];
                if (textProperty != null)
                {
                    textProperty.SetValue(Component, itemText);
                }
            }
        }
    }
}