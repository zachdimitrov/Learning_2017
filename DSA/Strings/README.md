# Strings searching

## Rabin-Karp

- create hash
```c#
B = 29         // просто число
M = 1000000007 // просто число
abcd => (a*B^3 + b*B^2 + c*B + d) % M
```

## KMP
- create table for prefixes that equal suficxes in each next char

```
 x a x a x a x
-1 0 0 1 2 3 3 5
```

