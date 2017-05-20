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
<div  class="highlight highlight-source-cs">
<pre>
var col = from o in Orders
          where o.CustomerID == 84
          select o;
</pre>
</div>
    </td>
    <td>
<div  class="highlight highlight-source-cs">  
<pre>
var col2 = Orders.Where(o => o.CustomerID == 84);
</pre>
</div>
    </td>
</tr>
<tr>
    <td>
<strong>Return anonymos</strong>
    </td>
    <td>
<div  class="highlight highlight-source-cs">
<pre>
var col = from o in orders
          select new 
          { 
              OrderID = o.OrderID, 
              Cost = o.Cost 
          };
</pre>
</div>
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

