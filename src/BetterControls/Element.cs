using BetterControls.ComponentModel;
using System;
using System.ComponentModel;

namespace BetterControls
{
    /// <summary>
    /// Extend this class to create an element.
    /// </summary>
    [Serializable]
    public abstract class Element : IElement
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Element"/>.
        /// </summary>
        protected Element() { }

        private object _tag;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Category(Categories.Data)]
        [Description("The object that contains data about the element.")]
        [DefaultValue(null)]
        [Localizable(false)]
        [Bindable(true)]
        [TypeConverter(typeof(StringConverter))]
        public object Tag
        {
            get => _tag;
            set => _tag = value;
        }
    }
}