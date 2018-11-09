using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RangeLookupTable
{
	public class RangeLookupTable<T, U> where T : IComparable
	{
		public SortedList<Range<T>, U> Table { get; }
		public int LookupIterations = 0;

		public RangeLookupTable() => Table = new SortedList<Range<T>, U>();


		public int Count => Table.Count;

		/// <summary>
		/// Adds a new entry to the table
		/// </summary>
		/// <param name="lower">The range lower value</param>
		/// <param name="upper">The range upper value</param>
		/// <param name="value">The actual value</param>
		public void Add(T lower, T upper, U value) => Table.Add(new Range<T>(lower, upper), value);


		/// <summary>
		/// Recursive function that performs a binary search
		/// </summary>
		/// <param name="lookupValue">The value to look up</param>
		/// <param name="i">The current index</param>
		/// <param name="lIndex">The lowerbound index</param>
		/// <param name="uIndex">The upperbound index</param>
		/// <returns></returns>
		public U GetValue(T lookupValue, int i = 0, int lIndex = 0, int uIndex = 0)
		{
			LookupIterations = (i == lIndex && uIndex == i) ? 1 : LookupIterations + 1;

			// If the number of iterations is greater than the elements, the item is not in the table
			// i.e Given the ranges [0,3], [5,8], lookup the item 4
			if (Table.Count == 0 || LookupIterations > Table.Count) return default(U);
			var lowerIndex = lIndex;
			var upperIndex = uIndex == 0 ? Table.Count - 1 : uIndex;
			var index = i == 0 ? upperIndex / 2 : i;

			if (index >= Table.Count || index < 0) return default(U);

			var element = Table.ElementAt(index);
			if (element.Key.IsInRange(lookupValue))
			{
				return element.Value;
			}
			if (element.Key.LowerBound.CompareTo(lookupValue) > 0)
			{
				if (upperIndex == index)
				{
					index -= 1;
				}
				else
				{
					upperIndex = index;
					index -= (upperIndex - lowerIndex) / 2;
				}
			}
			else
			{
				if (lowerIndex == index)
				{
					index += 1;
				}
				else
				{
					lowerIndex = index;
					index += (upperIndex - lowerIndex) / 2;
				}

			}

			return GetValue(lookupValue, index, lowerIndex, upperIndex);
		}



		/// <summary>
		/// Outputs the table in a human-friendly way
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			var result = new StringBuilder();
			foreach (var item in Table)
			{
				result.AppendLine($"{item.Key}: {item.Value}");
			}
			return result.ToString();
		}
	}
}
