using System.Windows;
using Sting.Collection;
using BenchmarkDotNet.Attributes;

namespace Sting.Benchmark
{
    public class RefereneArrayBenchmark
    {
        private Rect[] _rects = new Rect[100];

        [Benchmark]
        public void UpdateRectRefArray()
        {
            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx] = new Rect(idx, idx, idx, idx);
            }

            foreach (ref var rect in _rects.AsRef())
            {
                rect.Offset(100, 100);
            }
        }

        [Benchmark]
        public void UpdateRectArray()
        {
            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx] = new Rect(idx, idx, idx, idx);
            }

            for (int idx = 0; idx < _rects.Length; idx++)
            {
                _rects[idx].Offset(100, 100);
            }
        }
    }
}