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
		public void IntroSort_Full01()
		{
			double[] ds = new double[0];
			this.IntroSort_Full<double>(ds, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full02()
		{
			double[] ds = new double[1];
			this.IntroSort_Full<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full03()
		{
			double[] ds = new double[1];
			this.IntroSort_Full<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full04()
		{
			double[] ds = new double[2];
			this.IntroSort_Full<double>(ds, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full05()
		{
			double[] ds = new double[3];
			this.IntroSort_Full<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full06()
		{
			double[] ds = new double[1];
			this.IntroSort_Full<double>(ds, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full07()
		{
			double[] ds = new double[2];
			this.IntroSort_Full<double>(ds, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full08()
		{
			double[] ds = new double[2];
			ds[0] = 1;
			this.IntroSort_Full<double>(ds, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full09()
		{
			double[] ds = new double[2];
			this.IntroSort_Full<double>(ds, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full10()
		{
			double[] ds = new double[62];
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full11()
		{
			this.IntroSort_Full<double>((double[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full12()
		{
			double[] ds = new double[0];
			this.IntroSort_Full<double>(ds, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full13()
		{
			double[] ds = new double[62];
			this.IntroSort_Full<double>(ds, 15, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full14()
		{
			double[] ds = new double[63];
			ds[1] = -1;
			this.IntroSort_Full<double>(ds, 0, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full15()
		{
			double[] ds = new double[3];
			ds[0] = 1;
			this.IntroSort_Full<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full16()
		{
			double[] ds = new double[3];
			ds[1] = -1;
			ds[2] = -2;
			this.IntroSort_Full<double>(ds, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full17()
		{
			double[] ds = new double[32];
			ds[0] = -1;
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full18()
		{
			double[] ds = new double[62];
			ds[32] = 1;
			this.IntroSort_Full<double>(ds, 16, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full19()
		{
			double[] ds = new double[32];
			ds[1] = 1;
			ds[2] = 1;
			ds[3] = 1;
			ds[4] = 1;
			ds[5] = 1;
			ds[6] = 1;
			ds[7] = 1;
			ds[8] = 1;
			ds[9] = 1;
			ds[10] = 1;
			ds[11] = 1;
			ds[12] = 1;
			ds[13] = 1;
			ds[14] = 1;
			ds[15] = 1;
			ds[16] = 1;
			ds[17] = 1;
			ds[18] = 1;
			ds[19] = 1;
			ds[20] = 1;
			ds[21] = 1;
			ds[22] = 1;
			ds[23] = 1;
			ds[24] = 1;
			ds[25] = 1;
			ds[26] = 1;
			ds[27] = 1;
			ds[28] = 1;
			ds[29] = 1;
			ds[30] = 1;
			ds[31] = -1;
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full20()
		{
			double[] ds = new double[32];
			ds[1] = 1;
			ds[2] = 2;
			ds[3] = 2;
			ds[4] = 2;
			ds[5] = 2;
			ds[6] = 2;
			ds[7] = 2;
			ds[8] = 2;
			ds[9] = 2;
			ds[10] = 2;
			ds[11] = 2;
			ds[12] = 2;
			ds[13] = 2;
			ds[14] = 2;
			ds[15] = 2;
			ds[16] = 3;
			ds[17] = 2;
			ds[18] = 2;
			ds[19] = 2;
			ds[20] = 2;
			ds[21] = 2;
			ds[22] = 2;
			ds[23] = 2;
			ds[24] = 2;
			ds[25] = 2;
			ds[26] = 2;
			ds[27] = 2;
			ds[28] = 2;
			ds[29] = 2;
			ds[30] = 2;
			ds[31] = -1;
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full21()
		{
			double[] ds = new double[41];
			ds[1] = 1;
			ds[2] = 2;
			ds[3] = 1;
			ds[4] = 1;
			ds[5] = 1;
			ds[6] = 1;
			ds[7] = 1;
			ds[8] = 1;
			ds[9] = 1;
			ds[10] = 1;
			ds[11] = 1;
			ds[12] = 1;
			ds[13] = 1;
			ds[14] = 1;
			ds[15] = 1;
			ds[16] = 1;
			ds[17] = 3;
			ds[18] = 1;
			ds[19] = 1;
			ds[20] = 1;
			ds[21] = 1;
			ds[22] = 1;
			ds[23] = 1;
			ds[24] = 1;
			ds[25] = 1;
			ds[26] = 1;
			ds[27] = 1;
			ds[28] = 1;
			ds[29] = 1;
			ds[30] = 1;
			ds[31] = -1;
			ds[32] = 4;
			ds[33] = 7;
			ds[34] = 1;
			ds[35] = 1;
			ds[36] = 1;
			ds[37] = 1;
			ds[38] = 1;
			ds[39] = 1;
			ds[40] = 1;
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full22()
		{
			double[] ds = new double[32];
			ds[1] = 1;
			ds[3] = 3;
			ds[4] = 2;
			ds[5] = 2;
			ds[6] = 2;
			ds[7] = 2;
			ds[8] = 2;
			ds[9] = 2;
			ds[10] = 2;
			ds[11] = 2;
			ds[12] = 2;
			ds[13] = 2;
			ds[14] = 2;
			ds[15] = 2;
			ds[16] = 2;
			ds[17] = 2;
			ds[18] = 2;
			ds[19] = 2;
			ds[20] = 2;
			ds[21] = 2;
			ds[22] = 2;
			ds[23] = 2;
			ds[24] = 2;
			ds[25] = 2;
			ds[26] = 3;
			ds[27] = 2;
			ds[28] = 2;
			ds[29] = 2;
			ds[30] = 2;
			ds[31] = -1;
			this.IntroSort_Full<double>(ds, 0, 32);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full23()
		{
			string[] ss = new string[0];
			this.IntroSort_Full<string>(ss, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full24()
		{
			string[] ss = new string[1];
			this.IntroSort_Full<string>(ss, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full25()
		{
			string[] ss = new string[1];
			this.IntroSort_Full<string>(ss, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full26()
		{
			string[] ss = new string[2];
			this.IntroSort_Full<string>(ss, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full27()
		{
			string[] ss = new string[2];
			this.IntroSort_Full<string>(ss, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full28()
		{
			string[] ss = new string[1];
			this.IntroSort_Full<string>(ss, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full29()
		{
			string[] ss = new string[2];
			this.IntroSort_Full<string>(ss, 0, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full30()
		{
			string[] ss = new string[2];
			this.IntroSort_Full<string>(ss, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full31()
		{
			string[] ss = new string[46];
			this.IntroSort_Full<string>(ss, 0, 33);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full32()
		{
			this.IntroSort_Full<string>((string[])null, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full33()
		{
			string[] ss = new string[0];
			this.IntroSort_Full<string>(ss, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full34()
		{
			string[] ss = new string[2];
			ss[0] = "";
			this.IntroSort_Full<string>(ss, 0, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full35()
		{
			string[] ss = new string[50];
			this.IntroSort_Full<string>(ss, 3, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full36()
		{
			string[] ss = new string[62];
			ss[16] = "";
			this.IntroSort_Full<string>(ss, 0, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full37()
		{
			string[] ss = new string[54];
			ss[30] = "";
			this.IntroSort_Full<string>(ss, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full38()
		{
			string[] ss = new string[62];
			ss[0] = "";
			ss[2] = "";
			ss[3] = "";
			ss[4] = "";
			ss[5] = "";
			ss[6] = "";
			ss[7] = "";
			ss[8] = "";
			ss[9] = "";
			ss[10] = "";
			ss[11] = "";
			ss[12] = "";
			ss[13] = "";
			ss[14] = "";
			ss[15] = "";
			ss[16] = "";
			ss[17] = "";
			ss[18] = "";
			ss[19] = "";
			ss[20] = "";
			ss[21] = "";
			ss[22] = "";
			ss[23] = "";
			ss[24] = "";
			ss[25] = "";
			ss[26] = "";
			ss[27] = "";
			ss[28] = "";
			ss[29] = "";
			ss[30] = "";
			ss[31] = "";
			ss[32] = "";
			ss[33] = "";
			ss[34] = "";
			ss[35] = "";
			ss[36] = "";
			ss[37] = "";
			ss[38] = "";
			ss[39] = "";
			ss[40] = "";
			ss[41] = "";
			ss[42] = "";
			ss[43] = "";
			ss[44] = "";
			ss[45] = "";
			ss[46] = "";
			ss[47] = "";
			ss[48] = "";
			ss[49] = "";
			ss[50] = "";
			ss[51] = "";
			ss[52] = "";
			ss[53] = "";
			ss[54] = "";
			ss[55] = "";
			ss[56] = "";
			ss[57] = "";
			ss[58] = "";
			ss[59] = "";
			ss[60] = "";
			ss[61] = "";
			this.IntroSort_Full<string>(ss, 0, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full39()
		{
			string[] ss = new string[32];
			ss[0] = new string('\0', 58);
			ss[1] = new string('\0', 58);
			ss[2] = new string('\0', 58);
			ss[3] = new string('\0', 58);
			ss[4] = new string('\0', 58);
			ss[5] = new string('\0', 58);
			ss[6] = new string('\0', 58);
			ss[7] = new string('\0', 58);
			ss[8] = new string('\0', 58);
			ss[9] = new string('\0', 58);
			ss[10] = new string('\0', 58);
			ss[11] = new string('\0', 58);
			ss[12] = new string('\0', 58);
			ss[13] = new string('\0', 58);
			ss[14] = new string('\0', 58);
			ss[15] = new string('\0', 58);
			ss[16] = new string('\0', 58);
			ss[17] = new string('\0', 58);
			ss[18] = new string('\0', 58);
			ss[19] = new string('\0', 58);
			ss[20] = new string('\0', 58);
			ss[21] = new string('\0', 58);
			ss[22] = new string('\0', 58);
			ss[23] = new string('\0', 58);
			ss[24] = new string('\0', 58);
			ss[25] = new string('\0', 58);
			ss[26] = new string('\0', 58);
			ss[27] = new string('\0', 58);
			ss[28] = new string('\0', 58);
			ss[29] = new string('\0', 58);
			ss[30] = new string('\0', 58);
			this.IntroSort_Full<string>(ss, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full40()
		{
			string[] ss = new string[62];
			ss[16] = "";
			this.IntroSort_Full<string>(ss, 16, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full41()
		{
			string[] ss = new string[55];
			ss[46] = "";
			ss[47] = "";
			this.IntroSort_Full<string>(ss, 0, 49);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full42()
		{
			int[] ints = new int[0];
			this.IntroSort_Full<int>(ints, 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full43()
		{
			int[] ints = new int[1];
			this.IntroSort_Full<int>(ints, 0, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full44()
		{
			int[] ints = new int[1];
			this.IntroSort_Full<int>(ints, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full45()
		{
			int[] ints = new int[2];
			this.IntroSort_Full<int>(ints, 1, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full46()
		{
			int[] ints = new int[3];
			this.IntroSort_Full<int>(ints, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full47()
		{
			int[] ints = new int[1];
			this.IntroSort_Full<int>(ints, 0, int.MinValue);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full48()
		{
			int[] ints = new int[2];
			this.IntroSort_Full<int>(ints, 0, 0);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full49()
		{
			int[] ints = new int[3];
			ints[0] = 2147467264;
			ints[1] = -2147483646;
			ints[2] = 2147467264;
			this.IntroSort_Full<int>(ints, 0, 2);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full50()
		{
			int[] ints = new int[2];
			this.IntroSort_Full<int>(ints, 1, 2);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full51()
		{
			int[] ints = new int[62];
			this.IntroSort_Full<int>(ints, 0, 32);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full52()
		{
			this.IntroSort_Full<int>((int[])((object)null), 2, 3);
		}

		[Test]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full53()
		{
			int[] ints = new int[0];
			this.IntroSort_Full<int>(ints, int.MinValue, 3);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full54()
		{
			int[] ints = new int[62];
			this.IntroSort_Full<int>(ints, 15, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full55()
		{
			int[] ints = new int[49];
			ints[1] = -1682147016;
			this.IntroSort_Full<int>(ints, 0, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full56()
		{
			int[] ints = new int[62];
			ints[1] = 1;
			ints[2] = 1;
			ints[3] = 1;
			ints[4] = 1;
			ints[5] = 1;
			ints[6] = 1;
			ints[7] = 1;
			ints[8] = 1;
			ints[9] = 1;
			ints[10] = 1;
			ints[11] = 1;
			ints[12] = 1;
			ints[13] = 1;
			ints[14] = 1;
			ints[15] = 1;
			ints[16] = 1;
			ints[17] = 1;
			ints[18] = 1;
			ints[19] = 1;
			ints[20] = 1;
			ints[21] = 1;
			ints[22] = 1;
			ints[23] = 1;
			ints[24] = 1;
			ints[25] = 1;
			ints[26] = 1;
			ints[27] = 1;
			ints[28] = 1;
			ints[29] = 1;
			ints[30] = 1;
			ints[31] = 1;
			ints[32] = 1;
			ints[33] = 1;
			ints[34] = 1;
			ints[35] = 1;
			ints[36] = 1;
			ints[37] = 1;
			ints[38] = 1;
			ints[39] = 1;
			ints[40] = 1;
			ints[41] = 1;
			ints[42] = 1;
			ints[43] = 1;
			ints[44] = 1;
			ints[45] = 1;
			ints[46] = 1;
			ints[47] = 1;
			ints[48] = 1;
			ints[49] = 1;
			ints[50] = 1;
			ints[51] = 1;
			ints[52] = 1;
			ints[53] = 1;
			ints[54] = 1;
			ints[55] = 1;
			ints[56] = 1;
			ints[57] = 1;
			ints[58] = 1;
			ints[59] = 1;
			ints[60] = 1;
			ints[61] = 1;
			this.IntroSort_Full<int>(ints, 0, 36);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full57()
		{
			int[] ints = new int[62];
			ints[0] = int.MinValue;
			ints[1] = int.MinValue;
			ints[2] = int.MinValue;
			ints[3] = int.MinValue;
			ints[4] = int.MinValue;
			ints[5] = int.MinValue;
			ints[6] = int.MaxValue;
			ints[7] = int.MinValue;
			ints[8] = int.MinValue;
			ints[9] = int.MinValue;
			ints[10] = int.MinValue;
			ints[11] = int.MinValue;
			ints[12] = int.MinValue;
			ints[13] = int.MinValue;
			ints[14] = int.MinValue;
			ints[15] = int.MinValue;
			ints[16] = int.MinValue;
			ints[17] = int.MinValue;
			ints[18] = int.MinValue;
			ints[19] = int.MinValue;
			ints[20] = int.MinValue;
			ints[21] = int.MinValue;
			ints[22] = int.MinValue;
			ints[23] = int.MinValue;
			ints[24] = int.MinValue;
			ints[25] = int.MinValue;
			ints[26] = int.MinValue;
			ints[27] = int.MinValue;
			ints[28] = int.MinValue;
			ints[29] = int.MinValue;
			ints[30] = int.MinValue;
			ints[31] = int.MinValue;
			ints[32] = int.MinValue;
			ints[33] = int.MinValue;
			ints[34] = int.MinValue;
			ints[35] = int.MinValue;
			ints[36] = int.MinValue;
			ints[37] = int.MinValue;
			ints[38] = int.MinValue;
			ints[39] = int.MinValue;
			ints[40] = int.MinValue;
			ints[41] = int.MinValue;
			ints[42] = int.MinValue;
			ints[43] = int.MinValue;
			ints[44] = int.MinValue;
			ints[45] = int.MinValue;
			ints[46] = int.MinValue;
			ints[47] = int.MinValue;
			ints[48] = int.MinValue;
			ints[49] = int.MinValue;
			ints[50] = int.MinValue;
			ints[51] = int.MinValue;
			ints[52] = int.MinValue;
			ints[53] = int.MinValue;
			ints[54] = int.MinValue;
			ints[55] = int.MinValue;
			ints[56] = int.MinValue;
			ints[57] = int.MinValue;
			ints[58] = int.MinValue;
			ints[59] = int.MinValue;
			ints[60] = int.MinValue;
			ints[61] = int.MinValue;
			this.IntroSort_Full<int>(ints, 6, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full58()
		{
			int[] ints = new int[48];
			ints[1] = 16599042;
			ints[2] = 16599042;
			ints[3] = 16599042;
			ints[4] = 16599042;
			ints[5] = 16599042;
			ints[6] = 16599042;
			ints[7] = 16599042;
			ints[8] = 16599042;
			ints[9] = 16599042;
			ints[10] = 16599042;
			ints[11] = 16599042;
			ints[12] = 16599042;
			ints[13] = 16599042;
			ints[14] = 16599042;
			ints[15] = 16599042;
			ints[16] = 16599042;
			ints[17] = 16599042;
			ints[18] = 16599042;
			ints[19] = 16599042;
			ints[20] = 16599042;
			ints[21] = 16599042;
			ints[22] = 16599042;
			ints[23] = 16599042;
			ints[25] = 16599042;
			ints[26] = 16599042;
			ints[27] = 16599042;
			ints[28] = 16599042;
			ints[29] = 16599042;
			ints[30] = 16599042;
			ints[31] = 16599042;
			ints[32] = 16599042;
			ints[33] = 16599042;
			ints[34] = 16599042;
			ints[35] = 16599042;
			ints[36] = 16599042;
			ints[37] = 16599042;
			ints[38] = 16599042;
			ints[39] = 16599042;
			ints[40] = 16599042;
			ints[41] = 16599042;
			ints[42] = 16599042;
			ints[43] = 16599042;
			ints[44] = 16599042;
			ints[45] = 16599042;
			ints[46] = 16599042;
			ints[47] = 4;
			this.IntroSort_Full<int>(ints, 0, 48);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full59()
		{
			int[] ints = new int[40];
			ints[0] = -1542126080;
			ints[1] = 402656017;
			ints[2] = int.MinValue;
			ints[3] = int.MinValue;
			ints[4] = int.MinValue;
			ints[5] = int.MinValue;
			ints[6] = int.MinValue;
			ints[7] = int.MinValue;
			ints[8] = int.MinValue;
			ints[9] = int.MinValue;
			ints[10] = int.MinValue;
			ints[11] = int.MinValue;
			ints[12] = int.MinValue;
			ints[13] = int.MinValue;
			ints[14] = int.MinValue;
			ints[15] = int.MinValue;
			ints[16] = -1542126080;
			ints[17] = int.MinValue;
			ints[18] = int.MinValue;
			ints[19] = int.MinValue;
			ints[20] = int.MinValue;
			ints[21] = int.MinValue;
			ints[22] = int.MinValue;
			ints[23] = int.MinValue;
			ints[24] = int.MinValue;
			ints[25] = int.MinValue;
			ints[26] = int.MinValue;
			ints[27] = int.MinValue;
			ints[28] = int.MinValue;
			ints[29] = int.MinValue;
			ints[30] = int.MinValue;
			ints[31] = 2490368;
			ints[32] = 1073741824;
			ints[33] = int.MinValue;
			ints[34] = int.MinValue;
			ints[35] = int.MinValue;
			ints[36] = int.MinValue;
			ints[37] = int.MinValue;
			ints[38] = int.MinValue;
			ints[39] = int.MinValue;
			this.IntroSort_Full<int>(ints, 0, 33);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full60()
		{
			int[] ints = new int[62];
			ints[0] = 8527882;
			ints[1] = 8527882;
			ints[2] = 8527882;
			ints[3] = 8527882;
			ints[4] = 8527882;
			ints[5] = 1073741824;
			ints[6] = 8527882;
			ints[7] = 8527882;
			ints[8] = 8527882;
			ints[9] = 8527882;
			ints[10] = 8527882;
			ints[11] = 8527882;
			ints[12] = 8527882;
			ints[13] = 8527882;
			ints[14] = 8527882;
			ints[15] = 8527882;
			ints[16] = 8527882;
			ints[17] = 8527882;
			ints[18] = 8527882;
			ints[19] = 8527882;
			ints[20] = 8527882;
			ints[21] = 8527882;
			ints[22] = 8527882;
			ints[23] = 8527882;
			ints[24] = 8527882;
			ints[25] = 8527882;
			ints[26] = 8527882;
			ints[27] = 8527882;
			ints[28] = 8527882;
			ints[29] = 8527882;
			ints[30] = 8527882;
			ints[31] = 8527882;
			ints[32] = 8527882;
			ints[33] = 8527882;
			ints[34] = 536870912;
			ints[35] = 134219776;
			ints[36] = 8527882;
			ints[37] = 8527882;
			ints[38] = 8527882;
			ints[39] = 8527882;
			ints[40] = 8527882;
			ints[41] = 8527882;
			ints[42] = 8527882;
			ints[43] = 8527882;
			ints[44] = 8527882;
			ints[45] = 8527882;
			ints[46] = 8527882;
			ints[47] = 8527882;
			ints[48] = 8527882;
			ints[49] = 8527882;
			ints[50] = 8527882;
			ints[51] = 8527882;
			ints[52] = 8527882;
			ints[53] = 8527882;
			ints[54] = 8527882;
			ints[55] = 8527882;
			ints[56] = 8527882;
			ints[57] = 8527882;
			ints[58] = 8527882;
			ints[59] = 8527882;
			ints[60] = 8527882;
			ints[61] = 8527882;
			this.IntroSort_Full<int>(ints, 4, 32);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Full61()
		{
			int[] ints = new int[32];
			ints[1] = 8388608;
			ints[17] = 268435456;
			ints[27] = 536870912;
			ints[29] = 134217728;
			ints[30] = 256;
			ints[31] = 1073741824;
			this.IntroSort_Full<int>(ints, 0, 32);
		}

	}
}
