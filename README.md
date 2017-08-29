# resourcer

No nonsense resource extraction.

# install

```
Install-Package Resourcer
```

# usage

### extract resource into memory

```c#
var logo = Assembly.GetExecutingAssembly().GetResource<Image>("MyProduct.Logo.png");
```

### extract resource to disk

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
