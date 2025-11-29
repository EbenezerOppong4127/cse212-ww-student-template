public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Check if value already exists - if so, do nothing (no duplicates)
        if (value == Data)
        {
            return; // Value already exists, don't insert
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Search for value in the tree recursively

        // Base case: found the value
        if (value == Data)
        {
            return true;
        }

        // If value is less, search in left subtree
        if (value < Data)
        {
            // If left child exists, recursively search it
            if (Left is not null)
                return Left.Contains(value);
            else
                return false; // No left child, value not found
        }
        else // value > Data
        {
            // If right child exists, recursively search it
            if (Right is not null)
                return Right.Contains(value);
            else
                return false; // No right child, value not found
        }
    }

    public int GetHeight()
    {
        // Problem 4: Calculate height of tree/subtree

        // Calculate height of left subtree
        int leftHeight = 0;
        if (Left is not null)
            leftHeight = Left.GetHeight();

        // Calculate height of right subtree
        int rightHeight = 0;
        if (Right is not null)
            rightHeight = Right.GetHeight();

        // Height is 1 (current node) + maximum of left or right height
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}