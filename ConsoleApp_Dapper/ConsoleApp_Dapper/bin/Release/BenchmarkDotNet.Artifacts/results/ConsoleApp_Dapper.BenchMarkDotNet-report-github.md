``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4075.0), X86 LegacyJIT  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4075.0), X86 LegacyJIT


```
|                    Method |     Mean |   Error |   StdDev |   Median |
|-------------------------- |---------:|--------:|---------:|---------:|
|     ExecuteSqlUsingDapper | 192.1 us | 3.81 us | 10.22 us | 193.2 us |
| ExecuteSqlUsingSqlCommand | 200.4 us | 3.97 us | 10.87 us | 196.6 us |
