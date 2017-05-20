## LINQ Cheat Sheet

#### Filtering
```c#
var col = from o in Orders
          where o.CustomerID == 84
          select o;
```
```c#
var col2 = Orders.Where(o => o.CustomerID == 84);
```

#### Return Anonymos Type
```c#
var col = from o in orders
          select new 
          { 
              OrderID = o.OrderID, 
              Cost = o.Cost 
          };
```
```c#
var col2 = orders.Select(o => new 
      {
          OrderID = o.OrderID, 
          Cost = o.Cost
      }
    );
```

#### Ordering
- example 1
```c#
var col = from o in orders
          orderby o.Cost ascending
          select o;
```
```c#
var col2 = orders.OrderBy(o => o.Cost);
```
- example 2
```c#
var col3 = from o in orders
           orderby o.Cost descending
           select o;
```
```c#
var col4 = orders.OrderByDescending(o => o.Cost);
```
- example 3
```c#
var col9 = from o in orders
  orderby o.CustomerID, o.Cost descending
           select o;
```
```c#
var col6 = orders.OrderBy(o => o.CustomerID).
          ThenByDescending(o => o.Cost);
```
- return same result as above
```c#
var col5 = from o in orders
           orderby o.Cost descending
           orderby o.CustomerID
           select o;
```

#### Joining
```c#
var col = from c in customers
          join o in orders on 
          c.CustomerID equals o.CustomerID
          select new 
          {
              c.CustomerID, 
              c.Name, 
              o.OrderID, 
              o.Cost
          };	
```
```c#
var col2 = customers.Join(orders, 
    c => c.CustomerID,o => o.CustomerID, 
    (c, o) => new 
        { 
            c.CustomerID, 
            c.Name, 
            o.OrderID, 
            o.Cost 
        }
    );
```

#### Grouping
```c#
var OrderCounts = from o in orders
        group o by o.CustomerID into g
        select new
        {
            CustomerID = g.Key,
            TotalOrders = g.Count()
        };	
```
```c#
var OrderCounts1 = orders.GroupBy(
         o => o.CustomerID).
         Select(g => new 
         { 
             CustomerID = g.Key, 
             TotalOrders = g.Count() 
         });
```
#### Paging (using Skip & Take)
- select top 3
```c#
var col = (from o in orders
           where o.CustomerID == 84
           select o).Take(3);
```
```c#
var col2 = orders.Where(
           o => o.CustomerID == 84
           ).Take(3);
```

- skip first 2 and return the 2 after
```c@
var col3 = (from o in orders
           where o.CustomerID == 84
           orderby o.Cost
           select o).Skip(2).Take(2);
```
```C#
var col3 = (from o in orders
            where o.CustomerID == 84
            orderby o.Cost
            select o).Skip(2).Take(2);
```
