using System;
using System.Windows;

namespace Sting
{
    public readonly struct ImmutableRect : IEquatable<ImmutableRect>
    {
        /// <summary>
        /// Xを保持します。
        /// </summary>
        public readonly double X;

        /// <summary>
        /// Yを保持します。
        /// </summary>
        public readonly double Y;

        /// <summary>
        /// Widthを保持します。
        /// </summary>
        public readonly double Width;

        /// <summary>
        /// Heightを保持します。
        /// </summary>
        public readonly double Height;

        public ImmutablePoint Location => new ImmutablePoint(X, Y);

        public ImmutableRect(double x, double y, double width, double height) => (X, Y, Width, Height) = (x, y, width, height);

        public static implicit operator ImmutableRect(Rect source) => new ImmutableRect(source.X, source.Y, source.Width, source.Height);

        public static implicit operator Rect(in ImmutableRect source) => new Rect(source.X, source.Y, source.Width, source.Height);

        public static bool operator ==(in ImmutableRect source1, in ImmutableRect source2) => source1.X == source2.X && source1.Y == source2.Y && source1.Width == source2.Width && source1.Height == source2.Height;

        public static bool operator !=(in ImmutableRect source1, in ImmutableRect source2) => !(source1 == source2);

        public bool Equals(ImmutableRect other) => this == other;

        public override bool Equals(object obj)
        {
            if (obj is ImmutableRect other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
    }
}