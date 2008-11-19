// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
using System;
using MbUnit.Framework;
using Microsoft.Pex.Framework.Generated;

namespace C5.Tests
{
	public partial class SortingFixture
	{
		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort01()
		{
			double[] ds = new double[0];
			this.HeapSort<double>(ds, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort02()
		{
			double[] ds = new double[1];
			this.HeapSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort03()
		{
			double[] ds = new double[1];
			this.HeapSort<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort04()
		{
			double[] ds = new double[2];
			this.HeapSort<double>(ds, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort05()
		{
			double[] ds = new double[3];
			this.HeapSort<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort06()
		{
			double[] ds = new double[2];
			this.HeapSort<double>(ds, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort07()
		{
			double[] ds = new double[3];
			ds[1] = -1;
			this.HeapSort<double>(ds, 0, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort08()
		{
			this.HeapSort<double>((double[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort09()
		{
			double[] ds = new double[0];
			this.HeapSort<double>(ds, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort10()
		{
			double[] ds = new double[3];
			ds[1] = 1;
			this.HeapSort<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort11()
		{
			double[] ds = new double[1];
			this.HeapSort<double>(ds, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort12()
		{
			double[] ds = new double[2];
			this.HeapSort<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort13()
		{
			double[] ds = new double[3];
			this.HeapSort<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort14()
		{
			double[] ds = new double[3];
			this.HeapSort<double>(ds, 2, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort15()
		{
			double[] ds = new double[7];
			ds[3] = -1;
			this.HeapSort<double>(ds, 2, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort16()
		{
			double[] ds = new double[5];
			ds[0] = 2;
			ds[2] = 3;
			ds[3] = 1;
			ds[4] = 1;
			this.HeapSort<double>(ds, 0, 4);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort17()
		{
			string[] ss = new string[0];
			this.HeapSort<string>(ss, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort18()
		{
			string[] ss = new string[1];
			this.HeapSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort19()
		{
			string[] ss = new string[1];
			this.HeapSort<string>(ss, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort20()
		{
			string[] ss = new string[2];
			this.HeapSort<string>(ss, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort21()
		{
			string[] ss = new string[2];
			this.HeapSort<string>(ss, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort22()
		{
			this.HeapSort<string>((string[])null, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort23()
		{
			string[] ss = new string[0];
			this.HeapSort<string>(ss, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort24()
		{
			string[] ss = new string[2];
			this.HeapSort<string>(ss, 0, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort25()
		{
			string[] ss = new string[1];
			this.HeapSort<string>(ss, 0, int.MinValue);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort26()
		{
			string[] ss = new string[2];
			this.HeapSort<string>(ss, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort27()
		{
			string[] ss = new string[3];
			ss[1] = "";
			this.HeapSort<string>(ss, 0, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort28()
		{
			string[] ss = new string[3];
			ss[0] = "";
			this.HeapSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort29()
		{
			string[] ss = new string[7];
			ss[5] = "\0\0\0\0\0\0";
			this.HeapSort<string>(ss, 2, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort30()
		{
			string[] ss = new string[3];
			this.HeapSort<string>(ss, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort31()
		{
			string[] ss = new string[7];
			ss[5] = "\0\0";
			this.HeapSort<string>(ss, 0, 6);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort32()
		{
			string[] ss = new string[15];
			ss[14] = "\0\0";
			this.HeapSort<string>(ss, 1, 14);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort33()
		{
			int[] ints = new int[0];
			this.HeapSort<int>(ints, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort34()
		{
			int[] ints = new int[1];
			this.HeapSort<int>(ints, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort35()
		{
			int[] ints = new int[1];
			this.HeapSort<int>(ints, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort36()
		{
			int[] ints = new int[2];
			this.HeapSort<int>(ints, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort37()
		{
			int[] ints = new int[3];
			this.HeapSort<int>(ints, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort38()
		{
			int[] ints = new int[2];
			this.HeapSort<int>(ints, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort39()
		{
			int[] ints = new int[2];
			this.HeapSort<int>(ints, 0, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort40()
		{
			this.HeapSort<int>((int[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort41()
		{
			int[] ints = new int[0];
			this.HeapSort<int>(ints, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort42()
		{
			int[] ints = new int[3];
			ints[0] = -1147467184;
			ints[1] = 1080348933;
			ints[2] = -1147467184;
			this.HeapSort<int>(ints, 0, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort43()
		{
			int[] ints = new int[1];
			this.HeapSort<int>(ints, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort44()
		{
			int[] ints = new int[7];
			ints[0] = 2097160;
			ints[1] = 2097160;
			ints[2] = 2097160;
			ints[3] = 2097160;
			ints[4] = 2097160;
			ints[5] = 2097160;
			ints[6] = -65038426;
			this.HeapSort<int>(ints, 1, 6);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort45()
		{
			int[] ints = new int[7];
			ints[0] = 8388620;
			ints[1] = 8388620;
			ints[2] = 8388620;
			ints[3] = 8388866;
			ints[4] = 8388620;
			ints[5] = 8388620;
			ints[6] = -675561490;
			this.HeapSort<int>(ints, 1, 6);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort46()
		{
			int[] ints = new int[6];
			ints[0] = int.MinValue;
			ints[1] = int.MinValue;
			ints[2] = 33;
			ints[3] = int.MinValue;
			ints[4] = int.MaxValue;
			ints[5] = 2;
			this.HeapSort<int>(ints, 0, 6);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort47()
		{
			int[] ints = new int[3];
			this.HeapSort<int>(ints, 2, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void HeapSort48()
		{
			int[] ints = new int[7];
			this.HeapSort<int>(ints, 3, 0);
		}

	}
}
