using Microsoft.DotNet.DesignTools.Designers;
using System.ComponentModel.Design;

namespace BetterControls.Design
{
    /// <summary>
    /// Extend this class to create a component designer.
    /// </summary>
    public abstract class BetterComponentDesigner : ComponentDesigner
    {
        /// <summary>
        /// Initialize a new instance of <see cref="BetterComponentDesigner"/>.
        /// </summary>
        public BetterComponentDesigner() { }

        #region Private Member Fields

        private IDesignerHost _designerHost;

        #endregion

        /// <summary>
        /// Gets the designer host associated with this component.
        /// </summary>
        protected IDesignerHost DesignerHost
        {
            get
            {
                if (_designerHost is null)
                    _designerHost = GetService<IDesignerHost>();

                return _designerHost;
            }
        }
    }
}