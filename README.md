# KeepPractising
Some random codes for practise

## Design
Every type of problem has been sub-categorised. Each sub-category contains its own *TestSuite* class which contains methods to test the solution class of the problem. The main execution relies heavily on reflection to find all the testable methods in the *TestSuite* class.

### LinkedLists
**MyLinkedLists** inside the *LinkedLists* namespace creates a generic class that creates a LinkedList on a given object. It contains a nested class - **MyNode** to create nodes for the linked list.
One can add a node to **MyLinkedList** either at the beginning or at the end.

A key thing to mark here is that as **MyNode** is a nested class, **MyLinkedList** won't have any access to the private objects of MyNode. So, MyNode implements an internal interface - **INodeAction** so that MyLinkedList can still access the private methods of the MyNode class.

All other classes in this namespace solve a linked list related problem.

### Stacks
**MyStack** inside *Stacks* namespace creates a generic stack for any given object by using MyLinkedList class.

All other classes in this namespace solve a stack related problem.

### MyQueue
**MyQueue** inside *Queues* namespace creates a generic queue for any given object by using MyLinkedList class.

All other classes in this namespace solve a queue related problem.

### Threading
*Threading* namespace contains some threading related problem like job scheduling and others.
