## Data Structures
#### Linear Structures
- Lists
  - static list
```c#
List<int> // default structure in C#
```
  - single linked list
  - double linked list
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
- Stacks - only top element is usable
```c#
Stack<int> // default structure in C#
// Push - inserts at top
// Pop - removes from top
```
- Queues - only bottom element is usable
```c# 
Queue<int> // default structure in C#
// Enqueue - adds to head
// Dequeue - removest at head
```
- List Interfaces
  - IEnumerable, IEnumerable<T> - using forEach
  - ICollection, ICollection<T> - using count
  - IList, IList<T> - inherits top 2 interfaces

#### Tree-Like Structures
- Binary
- Ordered search trees
- Balansed
- B-trees
#### Dictionaries
- Contain pairs (key, value)
- Hash tables
#### Sets and Bags
- Set - collection of unique elements
- Bag - non-uniqie elements
#### Ordered sets, Bags
#### Priority queues / heaps
#### Special thee, interval tree, index tree, trie
#### Graphs
- Directed / undirected
- Weighted / un-weighted
- Connected / non-connected

##### represent graphs
- list of neighbours
```c#
public class Graph
{
    LinkedList<int>[] childNodes;
    public Graph(LinkedList<int>[] nodes)
    {
        this.childNodes = nodes;
    }
}
```
for each node save connected nodes in a list (linked list, hashset)  

`1 -> {2, 3, 5}`  
`2 -> {1, 4, 5}`  
`3 -> {1, 4, 5, 6}`  

- matrix of nodes

- list of edges

##### searching alghoritms

```c#
BFS(node)
{
queue <- node
visited[node] = true
while queue not empty
    v <- queue
    print v
    for each child c of v
        if not visited[c]
        queue <- c
        visited[c] = true
}
```

```c#
DFS(node)
{
stack <- node
visited[node] = true
while stack not empty
    v <- stack
    print v
    for each child c of v
        if not visited[c]
        stack <- c
        visited[c] = true
}
```
##### dijkstra 
```c#
all nodes Dist = infinity
current node = 0
Q -> all nodes from graph ordered by distance
while Q is not empty
    a = dequeue the smallest element (first in priority queue)
        if distance of a == infinity - break
        foreach neighbour v of a
            pot = distance of a + distance of (a-v)
            if pot < distance of v
                distance of v = pot
                reorder Q;
```

##### topological sort
- weighted graphs
- no cycles

```
// source removal
create empty list
find node that has no edges to it
add it to list
delete all edges from it
repeat

if graph has edges  -> graph has cycle
else return list
```