using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace TestComparingWithEmptyString
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>(DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator));
        }
    }
}
