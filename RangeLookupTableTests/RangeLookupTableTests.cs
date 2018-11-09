using Microsoft.VisualStudio.TestTools.UnitTesting;
using RangeLookupTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeLookupTable.Tests
{
	[TestClass()]
	public class RangeLookupTableTests
	{
		[TestMethod()]
		public void RangeLookupTableTest()
		{
			var table = new RangeLookupTable<int, string>();
			Assert.IsInstanceOfType(table, typeof(RangeLookupTable<int, string>));
		}

		[TestMethod()]
		public void AddTest()
		{
			var table = new RangeLookupTable<int, string>();
			table.Add(0, 4, "FAIL");
			Assert.IsTrue(table.Count == 1);
		}

		[TestMethod()]
		public void GetValueTest()
		{
			var table = new RangeLookupTable<int, string>();
			table.Add(0, 4, "FAIL");
			Assert.IsTrue(table.GetValue(0) == "FAIL");
			Assert.IsTrue(table.GetValue(1) == "FAIL");
			Assert.IsTrue(table.GetValue(2) == "FAIL");
			Assert.IsTrue(table.GetValue(3) == "FAIL");
			Assert.IsTrue(table.GetValue(4) == "FAIL");

			Assert.IsTrue(table.GetValue(5) == default(string));
			Assert.IsTrue(table.GetValue(-1) == default(string));

			table.Add(6, 8, "PASS");
			Assert.IsTrue(table.GetValue(6) == "PASS");
			Assert.IsTrue(table.GetValue(7) == "PASS");
			Assert.IsTrue(table.GetValue(8) == "PASS");

			Assert.IsTrue(table.GetValue(5) == default(string));
		}
	}
}