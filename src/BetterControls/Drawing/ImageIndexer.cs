using System.Windows.Forms;

namespace BetterControls.Drawing
{
    /// <summary>
    /// Used to provide a mechanism for a control to support using both image indexes and image keys.
    /// </summary>
    public class ImageIndexer
    {
        private ImageList _imageList;
        private int _index = -1;
        private string _key = string.Empty;
        private bool _useIndex = false;

        /// <summary>
        /// Gets the image list associated with this image indexer.
        /// </summary>
        protected virtual ImageList ImageList => _imageList;

        /// <summary>
        /// Gets or sets the index of the image from the associated image list. The image indexer is configured to use this index as an image source.
        /// </summary>
        public virtual int Index
        {
            get => _index;
            set
            {
                if (Index != value)
                {
                    _index = value;
                }

                _useIndex = true;
            }
        }

        /// <summary>
        /// Gets or sets the key of the image from the associated image list. The image indexer is configured to use this key as an image source.
        /// </summary>
        public virtual string Key
        {
            get => _key;
            set
            {
                if (Key != value)
                {
                    if (value is null)
                        _key = string.Empty;
                    else
                        _key = value;
                }

                _useIndex = false;
            }
        }

        /// <summary>
        /// Gets the computed image index, based on whether the image indexer is configured to use the index or key as an image source.
        /// </summary>
        public virtual int ComputedIndex
        {
            get
            {
                if (_useIndex)
                {
                    return Index;
                }
                else if (ImageList != null)
                {
                    return ImageList.Images.IndexOfKey(Key);
                }

                return -1;
            }
        }
    }
}