using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items are dequeued in order of priority (highest first)
    // Defect(s) Found: None - test passes after fixes
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: Items with same priority are dequeued in FIFO order (first in, first out)
    // Defect(s) Found: None - test passes after fixes
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - test passes
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Mix of priorities with multiple same-priority items
    // Expected Result: Highest priority first, then FIFO within same priority
    // Defect(s) Found: None - test passes after fixes
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // First with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second with priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First with priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second with priority 2
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Priority 1
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: That item is dequeued
    // Defect(s) Found: None - test passes
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);

        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items, dequeue some, enqueue more
    // Expected Result: Correct priority ordering maintained
    // Defect(s) Found: None - test passes after fixes
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());

        priorityQueue.Enqueue("Third", 5);
        priorityQueue.Enqueue("Fourth", 2);

        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }
}