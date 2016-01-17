# KeepPractising
Some random codes for practise

## Design
Every type of problem has been sub-categorised. Each sub-category contains its own *TestSuite* class which contains methods to test the solution class of the problem. The main execution relies heavily on reflection to find all the testable methods in the *TestSuite* class.

### Sorting
*Sorting* namespace contains some of the sorting techniques implemented as extension methods.

### LinkedLists
**MyLinkedLists** inside the *LinkedLists* namespace creates a generic class that creates a LinkedList on a given object. It contains a nested class - **MyNode** to create nodes for the linked list.
One can add a node to **MyLinkedList** either at the beginning or at the end.

A key thing to mark here is that as **MyNode** is a nested class, **MyLinkedList** won't have any access to the private objects of MyNode. So, MyNode implements an internal interface - **INodeAction** so that MyLinkedList can still access the private methods of the MyNode class. The main reason to implement the linked lists this way is because *stacks* and *queues*, which are implemented using linked lists, hold their validity of *FIFO* and *LIFO* operations and are not susceptible to data updates via simple object manipulation.

All other classes in this namespace solve a linked list related problem.

### Stacks
**MyStack** inside *Stacks* namespace creates a generic stack for any given object by using MyLinkedList class.

All other classes in this namespace solve a stack related problem.

### Queues
**MyQueue** inside *Queues* namespace creates a generic queue for any given object by using MyLinkedList class.

All other classes in this namespace solve a queue related problem.

### Strings
*Strings* namespace contains some problems based on string manipulation.

### Trees
*Trees* namespace contains some tree based problems. The class **MyTree** contains a generic tree structure implementation which is used throughout the project to create a tree. 

Binary Trees have a dedicated implementation to denote left and right child in the class **MyBinaryTree**. 

A separate binary search tree, **MyBinarySearchTree**, has also been implemented which does not inherit **MyBinaryTree** so that it maintains its BST nature. If inherited from **MyBinaryTree**, the tree's node can easily be manipulated, thus invalidating the BST. Similar to the implementation of **MyNode** in linked lists, **MyBinarySearchTreeNode** also implements a nested interface so that the parent BST class can update the node values but any other classes cannot.

### Graphs
*Graphs* namespace contains solutions to problems which involve graphs.

### Threading
*Threading* namespace contains some threading related problem like job scheduling and others.

### InterestingProblems
*InterestingProblems* namespace contains problems which could not be categorised specifically in any of the above types of problem. The documentation of each solution class generally describes the problem and gives a gist of solution approach being used.
