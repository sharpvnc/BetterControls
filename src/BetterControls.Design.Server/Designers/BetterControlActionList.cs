using Microsoft.DotNet.DesignTools.Designers;
using Microsoft.DotNet.DesignTools.Designers.Actions;
using System;
using System.ComponentModel.Design;

namespace BetterControls.Design
{
    /// <summary>
    /// Extend from this class to indicate that the implementing class is an action list.
    /// </summary>
    internal class BetterControlActionList : DesignerActionList
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterControlActionList"/>.
        /// </summary>
        /// <param name="designer">The designer that is associated with this action list.</param>
        internal BetterControlActionList(Microsoft.DotNet.DesignTools.Designers.ControlDesigner designer)
            : base(designer.Component)
        {
            Designer = designer ?? throw new ArgumentNullException(nameof(designer));
        }

        #region Private Member Fields

        private IDesignerHost _designerHost;

        #endregion

        /// <summary>
        /// Gets the designer that is associated with this action list.
        /// </summary>
        protected Microsoft.DotNet.DesignTools.Designers.ControlDesigner Designer { get; }

        /// <summary>
        /// Gets the designer host associated with this component.
        /// </summary>
        protected IDesignerHost DesignerHost
        {
            get
            {
                if(_designerHost is null)
                    _designerHost = GetService<IDesignerHost>();

                return _designerHost;
            }
        }
    }
}