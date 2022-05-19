/* COPYRIGHT NOTICE

MIT License

Copyright (c) 2022 SharpVNC Limited

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using System;
using System.ComponentModel;

namespace BetterControls
{
    /// <summary>
    /// Extend from this class to indicate that the collection element is a component that can be sited.
    /// </summary>
    public abstract class ComponentCollectionElement : CollectionElement, IComponent
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ComponentCollectionElement"/>.
        /// </summary>
        public ComponentCollectionElement() { }

        /// <summary>
        /// Initialize a new instance of <see cref="ComponentCollectionElement"/>.
        /// </summary>
        /// <param name="ownerElement">The owner element as an instance of <see cref="IElement"/>.</param>
        public ComponentCollectionElement(IElement ownerElement)
            : base(ownerElement)
        { }

        private string _name;
        private ISite _site;

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name))
                {
                    return _name;
                }
                else if (Site != null)
                {
                    return Site.Name;
                }

                return string.Empty;
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    _name = null;
                }
                else
                {
                    _name = value;
                }
                if (Site != null)
                {
                    Site.Name = _name;
                }
            }
        }

        /// <summary>
        /// Gets or sets the site of the control.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISite Site
        {
            get => _site; set
            {
                if (Site != value)
                {
                    _site = value;
                }
            }
        }

        /// <summary>
        /// Gets the site container associated with this component.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IContainer Container
        {
            get
            {
                if (Site != null)
                    return Site.Container;

                return null;
            }
        }

        /// <summary>
        /// Gets a <see cref="bool"/> value indicating whether or not the component is in design mode.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool DesignMode
        {
            get
            {
                if (Site != null)
                    return Site.DesignMode;

                return false;
            }
        }

        /// <summary>
        /// Gets the service for the specified type from the service provider.
        /// </summary>
        /// <param name="service">The type whose service to get from the service provider.</param>
        /// <returns>The service as an instance of <see cref="object"/>.</returns>
        protected virtual object GetService(Type service)
        {
            if (Site != null)
                return Site.GetService(service);

            return null;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all resources used by the component.
        /// </summary>
        /// <param name="disposing">A <see cref="bool"/> value indicating whether or not this method is being raised by disposing or a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if (Site != null && Site.Container != null)
                    {
                        Site.Container.Remove(this);
                    }

                    OnDispose(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// This method is raised when the component has been disposed.
        /// </summary>
        /// <param name="e">The event arguments as an instance of <see cref="EventArgs"/>.</param>
        protected virtual void OnDispose(EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Disposed?.Invoke(this, e);
        }

        /// <summary>
        /// This event is raised when the component has been disposed.
        /// </summary>
        public event EventHandler Disposed;
    }
}