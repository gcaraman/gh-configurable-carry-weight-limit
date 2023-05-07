GreenHell configurable carry weight limit

Default max weight: `80`
On first launch a file named `WeightSettings.xml` will be created in `.../Green Hell/Mods`.
Update the `WeightSettings.xml` file to configure the desired weight limit.

Bellow you can find the default xml file.
You can create it beforehand and set the desired values, or you can do nothing and it will be created on first launch.

```sh
<?xml version="1.0" encoding="utf-16"?>
<CarryWeight xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <OverloadWeight>60</OverloadWeight>
  <CriticalWeight>80</CriticalWeight>
  <MaxWeight>80</MaxWeight>
</CarryWeight>
```