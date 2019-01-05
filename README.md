## Synopsis
A small static utility class for getting the available physical and logical CPU cores on the system (C#).

## Usage
```csharp
using DrShushen.Utils;

...

int physicalCoreCount = CpuUtils.PhysicalCoreCount;  // Get physical CPU core count.
int logicalCoreCount = CpuUtils.LogicalCoreCount;  // Get logical CPU core count.
```