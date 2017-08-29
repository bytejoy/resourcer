# resourcer

No nonsense resource extraction.

# usage

```c#
var result = Assembly.GetExecutingAssembly().ExtractResource("MyProduct.SomeAssembly.dll");
if (result.Success)
{
  Console.WriteLine($"You can find your file here: {result.Location}!");
}
else
{
  Console.WriteLine($"Extraction failed! Error: {result.Error}");
}
```
