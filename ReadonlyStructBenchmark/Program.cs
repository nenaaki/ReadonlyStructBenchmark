using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Sting.Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("0:Rect 1:Array A:All");

            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    BenchmarkRunner.Run<ImmutableRectBenchmark>();
                    break;

                case '1':
                    BenchmarkRunner.Run<RefereneArrayBenchmark>();
                    break;

                case 'A':
                    BenchmarkRunner.Run<ImmutableRectBenchmark>();
                    BenchmarkRunner.Run<RefereneArrayBenchmark>();
                    break;
            }
        }
    }
}