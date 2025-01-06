using System.Windows;

namespace CountEZ.Styles.Controls
{
    /// <summary>
    /// Provides the size of items displayed in an VirtualizingPanel.
    /// https://github.com/sbaeumlisberger/VirtualizingWrapPanel/blob/master/src/VirtualizingWrapPanel/IItemSizeProvider.cs
    /// </summary>
    public interface IItemSizeProvider
    {
        /// <summary>
        /// Gets the size for the specified item.
        /// </summary>
        Size GetSizeForItem(object item);
    }
}
