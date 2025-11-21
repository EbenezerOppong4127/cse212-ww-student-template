using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // I create a brand new node ready to join the list.
        Node newNode = new(value);

        // If the list is empty, both the head and the tail welcome the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, the new node steps in front of the current head.
        else
        {
            newNode.Next = _head;  // The new node points to the former head.
            _head.Prev = newNode;  // The former head acknowledges its new predecessor.
            _head = newNode;       // The new node proudly becomes the head.
        }
    }

    /// <summary>
    /// Insert a new node at the back (the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // I create a new node who wants to join the list from the back.
        Node newNode = new(value);

        // If the list is empty, the newcomer becomes both head and tail.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, the new node attaches itself after the current tail.
        else
        {
            newNode.Prev = _tail;       // The new node recognizes the old tail as its previous.
            _tail!.Next = newNode;      // The current tail points forward to the new node.
            _tail = newNode;            // And now, the new node becomes the official tail.
        }
    }

    /// <summary>
    /// Remove the first node (the head) from the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list is empty or has only one element, both head and tail disappear.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more elements, only the head is replaced.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // The second node cuts ties with the old head.
            _head = _head.Next;      // The second node steps up as the new head.
        }
    }

    /// <summary>
    /// Remove the last node (the tail) from the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list is empty or has just one element, everything is cleared.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // Otherwise, the node before the tail becomes the new tail.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;  // The second-to-last node stops pointing to the old tail.
            _tail = _tail.Prev;       // It then takes the place of tail proudly.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value'.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // I start searching from the head, looking for the target value.
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the value is found at the tail, we simply append to the end.
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // Otherwise, we create a helper node who slips in after the target.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;         // The new node recognizes the found node as previous.
                    newNode.Next = curr.Next;    // It points to the node that used to follow.
                    curr.Next!.Prev = newNode;   // That following node accepts the new node as predecessor.
                    curr.Next = newNode;         // The original node points forward to its new neighbor.
                }

                return; // Once inserted, the mission is complete.
            }

            curr = curr.Next; // Keep moving forward in search of the value.
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // Begin the search from the very front of the list.
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it’s the first node, we let RemoveHead handle the job.
                if (curr == _head)
                {
                    RemoveHead();
                    return;
                }

                // If it’s the last node, RemoveTail takes care of it.
                if (curr == _tail)
                {
                    RemoveTail();
                    return;
                }

                // Otherwise, the node is somewhere in the middle.
                // The neighbors reconnect and skip over the removed node.
                curr.Prev!.Next = curr.Next;
                curr.Next!.Prev = curr.Prev;
                return; // Removal done.
            }

            curr = curr.Next; // Move along the list.
        }
    }

    /// <summary>
    /// Replace ALL occurrences of 'oldValue' with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // Start from the head and walk through the entire list.
        Node? curr = _head;

        while (curr is not null)
        {
            // Whenever we spot the old value, we update it.
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next; // Continue walking through the list.
        }
        // No early return — we intentionally check every node.
    }

    /// <summary>
    /// Yield all values in the linked list.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the linked list.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start proudly at the head.
        while (curr is not null)
        {
            yield return curr.Data; // Provide each value one by one.
            curr = curr.Next;       // March forward to the next node.
        }
    }

    /// <summary>
    /// Iterate backward from the tail to the head.
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Begin the journey from the tail.

        while (curr is not null)
        {
            yield return curr.Data; // Share the value of the current node.
            curr = curr.Prev;       // March backward toward the head.
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Helper for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Helper for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
