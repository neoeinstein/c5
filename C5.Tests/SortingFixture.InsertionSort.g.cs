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
		public void InsertionSort01()
		{
			double[] ds = new double[0];
			this.InsertionSort<double>(ds, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort02()
		{
			double[] ds = new double[1];
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort03()
		{
			double[] ds = new double[1];
			this.InsertionSort<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort04()
		{
			double[] ds = new double[2];
			this.InsertionSort<double>(ds, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort05()
		{
			double[] ds = new double[3];
			this.InsertionSort<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort06()
		{
			double[] ds = new double[1];
			this.InsertionSort<double>(ds, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort07()
		{
			double[] ds = new double[2];
			this.InsertionSort<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort08()
		{
			double[] ds = new double[2];
			ds[0] = 1;
			this.InsertionSort<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort09()
		{
			double[] ds = new double[2];
			this.InsertionSort<double>(ds, 1, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort10()
		{
			this.InsertionSort<double>((double[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort11()
		{
			double[] ds = new double[0];
			this.InsertionSort<double>(ds, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort12()
		{
			double[] ds = new double[3];
			ds[0] = -1;
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort13()
		{
			double[] ds = new double[6];
			ds[0] = -1;
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort14()
		{
			double[] ds = new double[3];
			ds[0] = -1;
			ds[2] = -1;
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort15()
		{
			double[] ds = new double[6];
			ds[0] = -1;
			ds[2] = -1;
			ds[3] = -1;
			ds[4] = -1;
			ds[5] = -1;
			this.InsertionSort<double>(ds, 0, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort16()
		{
			double[] ds = new double[3];
			ds[0] = -1;
			ds[2] = -2;
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort17()
		{
			double[] ds = new double[6];
			ds[0] = -1;
			ds[1] = -1;
			ds[3] = -1;
			ds[4] = -2;
			ds[5] = -1;
			this.InsertionSort<double>(ds, 1, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort18()
		{
			double[] ds = new double[6];
			ds[0] = -1;
			ds[1] = -1;
			ds[2] = -1;
			ds[4] = -1;
			ds[5] = -2;
			this.InsertionSort<double>(ds, 2, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort19()
		{
			double[] ds = new double[3];
			ds[1] = -1;
			ds[2] = -2;
			this.InsertionSort<double>(ds, 0, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort20()
		{
			string[] ss = new string[0];
			this.InsertionSort<string>(ss, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort21()
		{
			string[] ss = new string[1];
			this.InsertionSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort22()
		{
			string[] ss = new string[1];
			this.InsertionSort<string>(ss, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort23()
		{
			string[] ss = new string[2];
			this.InsertionSort<string>(ss, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort24()
		{
			string[] ss = new string[2];
			this.InsertionSort<string>(ss, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort25()
		{
			string[] ss = new string[1];
			this.InsertionSort<string>(ss, 0, int.MinValue);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort26()
		{
			string[] ss = new string[2];
			this.InsertionSort<string>(ss, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort27()
		{
			string[] ss = new string[2];
			this.InsertionSort<string>(ss, 0, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort28()
		{
			this.InsertionSort<string>((string[])null, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort29()
		{
			string[] ss = new string[0];
			this.InsertionSort<string>(ss, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort30()
		{
			string[] ss = new string[3];
			ss[1] = "";
			this.InsertionSort<string>(ss, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort31()
		{
			string[] ss = new string[3];
			ss[0] = "\0\0";
			this.InsertionSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort32()
		{
			string[] ss = new string[4];
			ss[2] = "\0\0\0\0\0\0";
			this.InsertionSort<string>(ss, 2, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort33()
		{
			string[] ss = new string[3];
			ss[1] = "";
			ss[2] = "";
			this.InsertionSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort34()
		{
			string[] ss = new string[7];
			ss[1] = "\0\0\0\0\0\0";
			this.InsertionSort<string>(ss, 1, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort35()
		{
			string[] ss = new string[7];
			ss[1] = "";
			this.InsertionSort<string>(ss, 0, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort36()
		{
			string[] ss = new string[3];
			ss[0] = "";
			ss[1] = "";
			this.InsertionSort<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort37()
		{
			string[] ss = new string[7];
			ss[0] = "\0\0\0\0\0\0";
			ss[1] = "\0\0\0\0\0\0";
			ss[4] = "\0\0\0\0\0\0";
			ss[5] = "\0\0\0\0\0\0";
			ss[6] = "\0\0\0\0\0\0";
			this.InsertionSort<string>(ss, 0, 6);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort38()
		{
			int[] ints = new int[0];
			this.InsertionSort<int>(ints, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort39()
		{
			int[] ints = new int[1];
			this.InsertionSort<int>(ints, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort40()
		{
			int[] ints = new int[1];
			this.InsertionSort<int>(ints, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort41()
		{
			int[] ints = new int[2];
			this.InsertionSort<int>(ints, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort42()
		{
			int[] ints = new int[3];
			this.InsertionSort<int>(ints, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort43()
		{
			int[] ints = new int[1];
			this.InsertionSort<int>(ints, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort44()
		{
			int[] ints = new int[3];
			ints[0] = 2147467264;
			ints[1] = -2147483646;
			ints[2] = 2147467264;
			this.InsertionSort<int>(ints, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort45()
		{
			int[] ints = new int[2];
			this.InsertionSort<int>(ints, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort46()
		{
			int[] ints = new int[2];
			this.InsertionSort<int>(ints, 0, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort47()
		{
			this.InsertionSort<int>((int[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort48()
		{
			int[] ints = new int[0];
			this.InsertionSort<int>(ints, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort49()
		{
			int[] ints = new int[3];
			ints[0] = 2046;
			ints[1] = 2048;
			ints[2] = 2048;
			this.InsertionSort<int>(ints, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort50()
		{
			int[] ints = new int[3];
			this.InsertionSort<int>(ints, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort51()
		{
			int[] ints = new int[6];
			ints[0] = 32768;
			ints[1] = 32768;
			ints[2] = 32766;
			ints[3] = 32768;
			ints[4] = 32769;
			ints[5] = 32768;
			this.InsertionSort<int>(ints, 2, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort52()
		{
			int[] ints = new int[3];
			ints[1] = 1140852739;
			ints[2] = -2096099061;
			this.InsertionSort<int>(ints, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort53()
		{
			int[] ints = new int[7];
			ints[0] = 2147450752;
			ints[1] = 2147467137;
			ints[2] = -2147483583;
			ints[3] = -2147467265;
			ints[4] = 2147467137;
			ints[5] = 2147467137;
			ints[6] = 2147467137;
			this.InsertionSort<int>(ints, 0, 4);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void InsertionSort54()
		{
			int[] ints = new int[3];
			ints[0] = 2147483632;
			ints[1] = 8;
			ints[2] = -2147483639;
			this.InsertionSort<int>(ints, 0, 3);
		}

	}
}
