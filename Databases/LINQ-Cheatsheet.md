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
<pre>
var col = from o in Orders
          where o.CustomerID == 84
          select o;
</pre>
    </td>
    <td> 
<pre>
var col2 = Orders.Where(o => o.CustomerID == 84);
</pre>
    </td>
</tr>
<tr>
    <td>
<strong>Return anonymos</strong>
    </td>
    <td>
<pre>
var col = from o in orders
          select new 
          { 
              OrderID = o.OrderID, 
              Cost = o.Cost 
          };
</pre>
    </td>
    <td>  
<pre>
var col2 = orders.Select(o => new 
      {
          OrderID = o.OrderID, 
          Cost = o.Cost
      }
    );
</pre>
    </td>
</tr>

