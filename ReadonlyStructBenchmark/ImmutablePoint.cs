using System;
using System.Windows;

namespace Sting
{
    public readonly struct ImmutablePoint : IEquatable<ImmutablePoint>
    {
        public static ImmutablePoint Empty = new ImmutablePoint(double.NaN, double.NaN);

        /// <summary>
        /// The x
        /// </summary>
        public readonly double X;

        public readonly double Y;

        public ImmutablePoint(double x, double y) => (X, Y) = (x, y);

        public bool Equals(ImmutablePoint other) => X == other.X && Y == other.Y;

        public bool IsEmpty() => Empty == this;

        public override bool Equals(object obj)
        {
            if (obj is ImmutablePoint other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        public static implicit operator Point(in ImmutablePoint source) => new Point(source.X, source.Y);

        public static implicit operator ImmutablePoint(Point source) => new ImmutablePoint(source.X, source.Y);

        public static bool operator ==(in ImmutablePoint source1, in ImmutablePoint source2) => source1.X == source2.X && source1.Y == source2.Y;

        public static bool operator !=(in ImmutablePoint source1, in ImmutablePoint source2) => !(source1 == source2);
    }
}