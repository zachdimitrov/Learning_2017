# Data Structures
## Linear Structures
### Lists
#### static list
```c#
List<int> // default structure in C#
- doubles Count each time we add element that exceeds capacity
- list[index] - access
- Insert(index, T) - inserts to specific position
- Remove(T) - removes first found element
- RemoveAt(index) - removes element at index
- Clear() - removes all
- Contains(T) - checks if element is in list
- IndexOf() - finds the index of selected value
- Reverse() - reverses the order
- Sort() - sorts elements
- ToArray() - converts list ot array
- TrimExcess() - sets capacity to count

```
#### single linked list
- has head and tail - head points to second, tail points to null

#### double linked list
```c#
// same as this
LinkedList<int> list = new LinkedList<int>;
// our implementation
class Node<T> 
{
    public Node(T value)
    {
        this.Value = value;
    }
    public T Value { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Prev { get; set; }
}

class DoubleLinkedList<T>
{
    private Node<T> start;
    private Node<T> end;
    public void AddStart(T value)
    {
        // implement Add to start
    }
    public void AddEnd(T value)
    {
        // implement Add to end
    }
}
```
- intersect lists - only common elements
- union lists - all elements from both lists
- sort lists
```c#
list.Sort();
list.Sort((d1, d2) => d1.Year.CompareTo(d2.Year));
list.OrderBy(date => date.Month);

```
### Stacks - only top element is usable
```c#
Stack<int> // default structure in C#
// Push - inserts at top
// Pop - removes from top
```
### Queues - only bottom element is usable
```c# 
Queue<int> // default structure in C#
// Enqueue - adds to head
// Dequeue - removest at head
```
#### List Interfaces
  - IEnumerable, IEnumerable<T> - using forEach
  - ICollection, ICollection<T> - using count
  - IList, IList<T> - inherits top 2 interfaces

## Tree-Like Structures
### Binary
### Ordered search trees
### Balansed
### B-trees
## Dictionaries
### Contain pairs (key, value)
### Hash tables
## Sets and Bags
### Set 
- collection of unique elements
### Bag 
- non-uniqie elements
## Ordered sets, Bags
## Priority queues / heaps
## Special thee, interval tree, index tree, trie
## Graphs
### Directed / undirected
### Weighted / un-weighted
### Connected / non-connected