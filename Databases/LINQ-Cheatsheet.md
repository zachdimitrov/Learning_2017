## Filtering

<table>
<tr>
    <th>operation</th>
    <th>query</th>
    <th>lambda</th>
</tr>
<tr>
    <td>
<strong>Filterng</strong>
    </td>
    <td>
```c#
var col = from o in Orders
          where o.CustomerID == 84
          select o;
```
    </td>
    <td>
```c#
var col2 = Orders.Where(o => o.CustomerID == 84);
```
    </td>
</tr>
<tr>
    <td>
<strong>Return anonymos</strong>
    </td>
    <td>
```c#
var col = from o in orders
          select new 
          { 
              OrderID = o.OrderID, 
              Cost = o.Cost 
          };
```
    </td>
    <td>  
<div  class="highlight highlight-source-cs">
<pre>
var col2 = orders.Select(o => new 
      {
          OrderID = o.OrderID, 
          Cost = o.Cost
      }
    );
</pre>
</div>
    </td>
</tr>

