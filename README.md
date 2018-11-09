# RangeLookupTable

Imagine you need to look up a value from a range i.e getting the council tax band for a given property value


| Range of values                   | Band  |
|-----------------------------------|-------|
| Over £27,000 and up to £35,000    | A     |
| Over £35,000 and up to £45,000    | B     |
| Over £45,000 and up to £58,000    | C     |
| Over £58,000 and up to £80,000    | D     |
| Over £80,000 and up to £106,000   | E     |
| Over £106,000 and up to £212,000  | F     |


With RangeLookupTable it's as easy as this:

1. Populate the table:

```C#
var table = new RangeLookupTable<decimal, string>();
table.Add(27000m, 35000m, "A");
table.Add(35000.1m, 45000m, "B");
table.Add(45000.1m, 58000m, "C");
table.Add(58000.1m, 80000m, "D");
table.Add(80000.1m, 106000m, "E");
table.Add(106000.1m, 212000m, "F");
```

2. Retrieve the value:
```C#
var band = table.GetValue(50000m);
// The variable "band" will hold the string "C"
```
