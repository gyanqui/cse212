using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Items are stored in insertion order.
    // Defect(s) Found:
    // None identified by inspection. Enqueue adds items to the back.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual(
            "[Bob (Pri:2), Tim (Pri:5), Sue (Pri:3)]",
            priorityQueue.ToString()
        );
    }

    [TestMethod]
    // Scenario: The last item has the highest priority.
    // Expected Result: Sue is returned.
    // Defect(s) Found:
    // Inspection found that the original loop skipped the last item.
    // The original code would return Tim instead of Sue.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 10);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Two items share the highest priority.
    // Expected Result: Bob, Tim, then Sue, preserving FIFO for ties.
    // Defect(s) Found:
    // Inspection found that >= selected the later item on a tie.
    // The original code would return Tim instead of Bob.
    public void TestPriorityQueue_EqualPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 1);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue every item, then try to dequeue again.
    // Expected Result: Tim, Sue, Bob, then InvalidOperationException
    // with the message "The queue is empty."
    // Defect(s) Found:
    // Inspection found that the original code never removed items.
    // It would return Tim repeatedly.
    public void TestPriorityQueue_RemovesItems()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 10);
        priorityQueue.Enqueue("Sue", 5);

        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Dequeue from a newly created empty queue.
    // Expected Result: InvalidOperationException with the exact
    // message "The queue is empty."
    // Defect(s) Found:
    // None identified by inspection. The exception and message are correct.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}