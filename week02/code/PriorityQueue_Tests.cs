using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);

        // B has highest priority (1)
        Assert.AreEqual("B", priorityQueue.Dequeue());

        // A is next (2)
        Assert.AreEqual("A", priorityQueue.Dequeue());

        // C is last (3)
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 5);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 1);

        // Z first (highest priority)
        Assert.AreEqual("Z", priorityQueue.Dequeue());

        // X and Y have same priority → FIFO order
        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());

    }

    // Add more test cases as needed below.
}