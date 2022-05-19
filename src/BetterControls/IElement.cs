namespace BetterControls
{
    /// <summary>
    /// Implement this interface to create an element.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Gets or sets the object that contains data about the element.
        /// </summary>
        object Tag { get; set; }
    }
}