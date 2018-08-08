namespace Sting.Collection
{
    public readonly struct ReferenceArray<T>
    {
        private readonly T[] _array;

        public ReferenceArray(T[] array) => _array = array;

        public ReferenceArrayEnumerator<T> GetEnumerator() => new ReferenceArrayEnumerator<T>(_array);

        public struct ReferenceArrayEnumerator<T>
        {
            private int _index;
            private readonly T[] _array;

            public ReferenceArrayEnumerator(T[] array) => (_index, _array) = (-1, array);

            public ref T Current => ref _array[_index];

            public bool MoveNext() => ++_index < _array.Length;
        }
    }

    public static class ReferenceArrayExtensions
    {
        public static ReferenceArray<T> AsRef<T>(this T[] array) => new ReferenceArray<T>(array);
    }
}