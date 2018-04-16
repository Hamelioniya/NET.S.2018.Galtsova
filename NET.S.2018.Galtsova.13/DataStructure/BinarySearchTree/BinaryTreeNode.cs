namespace DataStructure
{
    /// <summary>
    /// Represents a node of the binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of the element of the node.</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="BinaryTreeNode{T}"/>.
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(T value)
        {
            Left = null;
            Right = null;
            Value = value;
        }

        /// <summary>
        /// Left child of the node.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Right child of the node.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; set; }    
    }
}
