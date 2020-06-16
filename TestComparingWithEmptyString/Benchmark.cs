using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestComparingWithEmptyString
{
    [MarkdownExporterAttribute.GitHub]
    public class Benchmark
    {
        List<string> OneMillionList;//=> GetTestData(1_000_000);
        List<string> OneThousandList;// => GetTestData(1_000);
        List<string> OneHundredList;// => GetTestData(100);

        public Benchmark()
        {
            OneMillionList = GetTestData(1_000_000);
            OneThousandList = GetTestData(1_000);
            OneHundredList = GetTestData(100);
        }

        [Benchmark]
        public void Test_1_000_000_EqualityOperator() => OneMillionList.ForEach(s => CompareWithEmptyStringViaEqualityOperator(s));

        [Benchmark]
        public void Test_1_000_000_StringLength() => OneMillionList.ForEach(s => CompareWithEmptyStringViaStringLength(s));

        [Benchmark]
        public void Test_1_000_EqualityOperator() => OneThousandList.ForEach(s => CompareWithEmptyStringViaEqualityOperator(s));

        [Benchmark]
        public void Test_1_000_StringLength() => OneThousandList.ForEach(s => CompareWithEmptyStringViaStringLength(s));

        [Benchmark]
        public void Test_100_EqualityOperator() => OneHundredList.ForEach(s => CompareWithEmptyStringViaEqualityOperator(s));

        [Benchmark]
        public void Test_100_StringLength() => OneHundredList.ForEach(s => CompareWithEmptyStringViaStringLength(s));

        public static List<string> GetTestData(int amountOfRecords)
        {
            List<string> randomString = new List<string>();

            for (var i = 0; i < amountOfRecords; i++)
                randomString.Add(GetRandomString(random.Next(100)));
            return randomString;
        }

        private bool CompareWithEmptyStringViaEqualityOperator(string s) => s == "";
        private bool CompareWithEmptyStringViaStringLength(string s) => s.Length == 0;

        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
