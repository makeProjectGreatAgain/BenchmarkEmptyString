___
Here is benchmark results for `str == ""` vs `str.Length == 0`

``` ini
  .NET Core SDK=3.1.300
  [Host]     : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT
  DefaultJob : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT
```
|                          Method |            Mean |         Error |        StdDev |
|-------------------------------- |----------------:|--------------:|--------------:|
| Test_1_000_000_EqualityOperator | 15,394,460.9 ns | 302,780.33 ns | 488,933.80 ns |
|     Test_1_000_000_StringLength | 10,515,186.1 ns | 123,536.86 ns | 103,158.88 ns |
|     Test_1_000_EqualityOperator |      6,535.9 ns |      84.80 ns |      75.18 ns |
|         Test_1_000_StringLength |      3,056.8 ns |      33.96 ns |      30.11 ns |
|       Test_100_EqualityOperator |        672.1 ns |       7.37 ns |       5.75 ns |
|           Test_100_StringLength |        327.1 ns |       3.92 ns |       3.67 ns |

[Benchmark.cs](https://github.com/makeProjectGreatAgain/BenchmarkEmptyString/blob/master/TestComparingWithEmptyString/Benchmark.cs)

___
Replace `str == ""` and `str == string.Empty` 
with `str.Length == 0`

+it will increase perfomance a little bit
-perhaps it is less readable

Also, You can add
```
# CA1820: Test for empty strings using string length
dotnet_diagnostic.CA1820.severity = error
```
to avoid using `str == ""` in the future
