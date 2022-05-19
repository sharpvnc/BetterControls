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

using Microsoft.DotNet.DesignTools.Editors;
using System;
using WinForms.Tiles.ClientServerProtocol;

namespace BetterControls.Design
{
    /// <summary>
    /// Represents the collection editor client for a collection of toolbar items.
    /// </summary>
    internal partial class BetterToolbarItemCollectionEditor
    {
        /// <summary>
        /// Represents the factory used to create the collection editor.
        /// </summary>
        [ExportCollectionEditorFactory(CollectionEditorNames.BetterToolbarItemCollectionEditor)]
        private class Factory : CollectionEditorFactory<BetterToolbarItemCollectionEditor>
        {
            /// <summary>
            /// Initialize a new instance of <see cref="Factory"/>.
            /// </summary>
            public Factory() { }

            /// <summary>
            /// <inheritdoc/>
            /// </summary>
            /// <param name="serviceProvider"><inheritdoc/></param>
            /// <param name="collectionType"><inheritdoc/></param>
            /// <returns></returns>
            protected override BetterToolbarItemCollectionEditor CreateCollectionEditor(IServiceProvider serviceProvider, Type collectionType)
            {
                if (serviceProvider is null)
                {
                    throw new ArgumentNullException(nameof(serviceProvider));
                }

                if (collectionType is null)
                {
                    throw new ArgumentNullException(nameof(collectionType));
                }

                return new BetterToolbarItemCollectionEditor(serviceProvider, collectionType);
            }
        }
    }
}