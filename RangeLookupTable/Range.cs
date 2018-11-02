using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeLookupTable
{
	public sealed class Range<T> : IComparable<Range<T>> where T : IComparable
	{
		public T LowerBound { get; private set; }
		public T UpperBound { get; private set; }


		public Range(T lowerBound, T upperBound)
		{
			LowerBound = lowerBound;
			UpperBound = upperBound;
		}

		public int CompareTo(Range<T> other)
		{
			return LowerBound.CompareTo(other.LowerBound);
		}

		public bool IsInRange(T value)
		{
			return LowerBound.CompareTo(value) <= 0 && UpperBound.CompareTo(value) >= 0;
		}

		public override string ToString()
		{
			return $"[{LowerBound},{UpperBound}]";
		}
	}
}
