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
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short01()
		{
			this.IntroSort_Short<double>((double[])((object)null));
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short02()
		{
			double[] ds = new double[0];
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short03()
		{
			double[] ds = new double[2];
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short04()
		{
			double[] ds = new double[2];
			ds[0] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short05()
		{
			double[] ds = new double[62];
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short06()
		{
			double[] ds = new double[2];
			ds[1] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short07()
		{
			double[] ds = new double[36];
			ds[35] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short08()
		{
			double[] ds = new double[32];
			ds[0] = 1;
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
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short09()
		{
			double[] ds = new double[32];
			ds[0] = 1;
			ds[1] = -1;
			ds[2] = -1;
			ds[3] = -1;
			ds[4] = -1;
			ds[5] = -1;
			ds[6] = -1;
			ds[7] = -1;
			ds[8] = -1;
			ds[9] = -1;
			ds[10] = -1;
			ds[11] = -1;
			ds[12] = -1;
			ds[13] = -1;
			ds[14] = -1;
			ds[15] = -1;
			ds[17] = -1;
			ds[18] = -1;
			ds[19] = -1;
			ds[20] = -1;
			ds[21] = -1;
			ds[22] = -1;
			ds[23] = -1;
			ds[24] = -1;
			ds[25] = -1;
			ds[26] = -1;
			ds[27] = -1;
			ds[28] = -1;
			ds[29] = -1;
			ds[30] = -1;
			ds[31] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short10()
		{
			double[] ds = new double[46];
			ds[0] = 1;
			ds[1] = -1;
			ds[2] = -1;
			ds[3] = -1;
			ds[4] = -1;
			ds[5] = -1;
			ds[6] = -1;
			ds[7] = -1;
			ds[8] = -1;
			ds[9] = -1;
			ds[10] = -1;
			ds[11] = -1;
			ds[12] = -1;
			ds[13] = -1;
			ds[14] = -1;
			ds[15] = -1;
			ds[17] = -1;
			ds[18] = -1;
			ds[19] = -1;
			ds[20] = -1;
			ds[21] = -1;
			ds[22] = -1;
			ds[24] = -1;
			ds[25] = -1;
			ds[26] = -1;
			ds[27] = -1;
			ds[28] = -1;
			ds[29] = -1;
			ds[30] = -1;
			ds[31] = -1;
			ds[32] = -1;
			ds[33] = -1;
			ds[34] = -1;
			ds[35] = -1;
			ds[36] = -1;
			ds[37] = -1;
			ds[38] = -1;
			ds[39] = -1;
			ds[40] = -1;
			ds[41] = -1;
			ds[42] = -1;
			ds[43] = -1;
			ds[45] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short11()
		{
			double[] ds = new double[3];
			ds[0] = 1;
			ds[2] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short12()
		{
			double[] ds = new double[62];
			ds[31] = -2;
			ds[61] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short13()
		{
			double[] ds = new double[7];
			ds[0] = 1;
			ds[2] = -1;
			ds[3] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short14()
		{
			double[] ds = new double[62];
			ds[31] = -1;
			ds[61] = 1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short15()
		{
			double[] ds = new double[48];
			ds[0] = 1;
			ds[1] = 2;
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
			ds[25] = 1;
			ds[26] = 1;
			ds[27] = 1;
			ds[28] = 1;
			ds[29] = 1;
			ds[30] = 1;
			ds[31] = 1;
			ds[32] = 1;
			ds[33] = 1;
			ds[34] = 1;
			ds[35] = 1;
			ds[36] = 1;
			ds[37] = 1;
			ds[38] = 1;
			ds[39] = 1;
			ds[40] = 1;
			ds[41] = 1;
			ds[42] = 1;
			ds[43] = 1;
			ds[44] = 1;
			ds[45] = -1;
			ds[46] = 1;
			ds[47] = -2;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short16()
		{
			double[] ds = new double[36];
			ds[18] = 1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short17()
		{
			double[] ds = new double[62];
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
			ds[31] = 1;
			ds[32] = 1;
			ds[33] = 1;
			ds[34] = 1;
			ds[35] = 1;
			ds[36] = 1;
			ds[37] = 1;
			ds[38] = 1;
			ds[39] = 1;
			ds[40] = 1;
			ds[41] = 1;
			ds[42] = 1;
			ds[43] = 1;
			ds[44] = 1;
			ds[45] = 1;
			ds[46] = 1;
			ds[47] = 1;
			ds[48] = 1;
			ds[49] = 1;
			ds[50] = 1;
			ds[51] = 1;
			ds[52] = 1;
			ds[53] = 1;
			ds[54] = 1;
			ds[55] = 1;
			ds[56] = 1;
			ds[57] = 1;
			ds[58] = 1;
			ds[59] = 1;
			ds[60] = 1;
			ds[61] = -1;
			this.IntroSort_Short<double>(ds);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short18()
		{
			string[] ss = new string[0];
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short19()
		{
			string[] ss = new string[2];
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short20()
		{
			string[] ss = new string[2];
			ss[1] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short21()
		{
			this.IntroSort_Short<string>((string[])null);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short22()
		{
			string[] ss = new string[2];
			ss[0] = "";
			ss[1] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short23()
		{
			string[] ss = new string[62];
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short24()
		{
			string[] ss = new string[32];
			ss[1] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short25()
		{
			string[] ss = new string[32];
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
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short26()
		{
			string[] ss = new string[48];
			ss[24] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short27()
		{
			string[] ss = new string[62];
			ss[1] = "";
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
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short28()
		{
			string[] ss = new string[32];
			ss[30] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short29()
		{
			string[] ss = new string[7];
			ss[1] = "";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short30()
		{
			string[] ss = new string[6];
			ss[1] = "\0\0\0\0\0\0";
			ss[3] = "\0\0\0\0\0\0";
			this.IntroSort_Short<string>(ss);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short31()
		{
			this.IntroSort_Short<int>((int[])((object)null));
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short32()
		{
			int[] ints = new int[0];
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short33()
		{
			int[] ints = new int[2];
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short34()
		{
			int[] ints = new int[2];
			ints[0] = -2147483590;
			ints[1] = 2147483450;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short35()
		{
			int[] ints = new int[62];
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short36()
		{
			int[] ints = new int[2];
			ints[0] = 8192;
			ints[1] = 8126;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short37()
		{
			int[] ints = new int[3];
			ints[0] = 8192;
			ints[1] = 8126;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short38()
		{
			int[] ints = new int[3];
			ints[0] = -2147483590;
			ints[1] = 2147483450;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short39()
		{
			int[] ints = new int[62];
			ints[0] = 17472;
			ints[1] = 17472;
			ints[2] = 17472;
			ints[3] = 17472;
			ints[4] = 17472;
			ints[5] = 17472;
			ints[6] = 17472;
			ints[7] = 17472;
			ints[8] = 17472;
			ints[9] = 17472;
			ints[10] = 17472;
			ints[11] = 17472;
			ints[12] = 17472;
			ints[13] = 17472;
			ints[14] = 17472;
			ints[15] = 17472;
			ints[16] = 17472;
			ints[17] = 17472;
			ints[18] = 17472;
			ints[19] = 17472;
			ints[20] = 17472;
			ints[21] = 17472;
			ints[22] = 17472;
			ints[23] = 17472;
			ints[24] = 17472;
			ints[25] = 17472;
			ints[26] = 17472;
			ints[27] = 17472;
			ints[28] = 17472;
			ints[29] = 17472;
			ints[30] = 17472;
			ints[31] = -41960666;
			ints[32] = 17472;
			ints[33] = 17472;
			ints[34] = 17472;
			ints[35] = 17472;
			ints[36] = 17472;
			ints[37] = 17472;
			ints[38] = 17472;
			ints[39] = 17472;
			ints[40] = 17472;
			ints[41] = 17472;
			ints[42] = 17472;
			ints[43] = 17472;
			ints[44] = 17472;
			ints[45] = 17472;
			ints[46] = 17472;
			ints[47] = 17472;
			ints[48] = 17472;
			ints[49] = 17472;
			ints[50] = 17472;
			ints[51] = 17472;
			ints[52] = 17472;
			ints[53] = 17472;
			ints[54] = 17472;
			ints[55] = 17472;
			ints[56] = 17472;
			ints[57] = 17472;
			ints[58] = 17472;
			ints[59] = 17472;
			ints[60] = 17472;
			ints[61] = 17472;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short40()
		{
			int[] ints = new int[62];
			ints[0] = 1073743925;
			ints[1] = 1073743925;
			ints[2] = 1073743925;
			ints[3] = 1073743925;
			ints[4] = 1073743925;
			ints[5] = 1073743925;
			ints[6] = 1073743925;
			ints[7] = 1073743925;
			ints[8] = 1073743925;
			ints[9] = 1073743925;
			ints[10] = 1073743925;
			ints[11] = 1073743925;
			ints[12] = 1073743925;
			ints[13] = 1073743925;
			ints[14] = 1073743925;
			ints[15] = 1073743925;
			ints[16] = 1073743925;
			ints[17] = 1073743925;
			ints[18] = 1073743925;
			ints[19] = 1073743925;
			ints[20] = 1073743925;
			ints[21] = 1073743925;
			ints[22] = 1073743925;
			ints[23] = 1073743925;
			ints[24] = 1073743925;
			ints[25] = 1073743925;
			ints[26] = 1073743925;
			ints[27] = 1073743925;
			ints[28] = 1073743925;
			ints[29] = 1073743925;
			ints[30] = 1073743925;
			ints[31] = 90174403;
			ints[32] = 1073743925;
			ints[33] = 1073743925;
			ints[34] = 1073743925;
			ints[35] = 1073743925;
			ints[36] = 1073743925;
			ints[37] = 1073743925;
			ints[38] = 1073743925;
			ints[39] = 1073743925;
			ints[40] = 1073743925;
			ints[41] = 1073743925;
			ints[42] = 1073743925;
			ints[43] = 1073743925;
			ints[44] = 1073743925;
			ints[45] = 1073743925;
			ints[46] = 1073743925;
			ints[47] = 1073743925;
			ints[48] = 1073743925;
			ints[49] = 1073743925;
			ints[50] = 1073743925;
			ints[51] = 1073743925;
			ints[52] = 1073743925;
			ints[53] = 1073743925;
			ints[54] = 1073743925;
			ints[55] = 1073743925;
			ints[56] = 1073743925;
			ints[57] = 1073743925;
			ints[58] = 1073743925;
			ints[59] = 1073743925;
			ints[60] = 1073743925;
			ints[61] = 950001716;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short41()
		{
			int[] ints = new int[62];
			ints[0] = 4096;
			ints[1] = 4096;
			ints[2] = 4096;
			ints[3] = 4096;
			ints[4] = 4096;
			ints[5] = 4096;
			ints[6] = 4096;
			ints[7] = 4096;
			ints[8] = 4096;
			ints[9] = 4096;
			ints[10] = 4096;
			ints[11] = 4096;
			ints[12] = 4096;
			ints[13] = 4096;
			ints[14] = 4096;
			ints[15] = 4096;
			ints[16] = 4096;
			ints[17] = 4096;
			ints[18] = 4096;
			ints[19] = 4096;
			ints[20] = 4096;
			ints[21] = 4096;
			ints[22] = 4096;
			ints[23] = 4096;
			ints[24] = 4096;
			ints[25] = 4096;
			ints[26] = 4096;
			ints[27] = 4096;
			ints[28] = 4096;
			ints[29] = 4096;
			ints[30] = 4096;
			ints[31] = -1044481;
			ints[32] = 4096;
			ints[33] = 4096;
			ints[34] = 4096;
			ints[35] = 4096;
			ints[36] = 4096;
			ints[37] = 4096;
			ints[38] = 4096;
			ints[39] = 4096;
			ints[40] = 4096;
			ints[41] = 4096;
			ints[42] = 4096;
			ints[43] = 4096;
			ints[44] = 4096;
			ints[45] = 4096;
			ints[46] = 4096;
			ints[47] = 4096;
			ints[48] = 4096;
			ints[49] = 4096;
			ints[50] = 4096;
			ints[51] = 4096;
			ints[52] = 4096;
			ints[53] = 4096;
			ints[54] = 4096;
			ints[55] = 4096;
			ints[56] = 4096;
			ints[57] = 4096;
			ints[58] = 4096;
			ints[59] = 4096;
			ints[60] = 4096;
			ints[61] = int.MinValue;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short42()
		{
			int[] ints = new int[40];
			ints[0] = 1073774784;
			ints[1] = 1073741824;
			ints[2] = 146957480;
			ints[3] = 146957480;
			ints[4] = 146957480;
			ints[5] = 146957480;
			ints[6] = 146957480;
			ints[7] = 146957480;
			ints[8] = 146957480;
			ints[9] = 146957480;
			ints[10] = 146957480;
			ints[11] = 146957480;
			ints[12] = 146957480;
			ints[13] = 146957480;
			ints[14] = 146957480;
			ints[15] = 146957480;
			ints[16] = 146957480;
			ints[17] = 146957480;
			ints[18] = 146957480;
			ints[19] = 146957480;
			ints[20] = 146957480;
			ints[21] = 146957480;
			ints[22] = 146957480;
			ints[23] = 146957480;
			ints[24] = 146957480;
			ints[25] = 146957480;
			ints[26] = 146957480;
			ints[27] = 146957480;
			ints[28] = 146957480;
			ints[29] = 146957480;
			ints[30] = 146957480;
			ints[31] = 146957480;
			ints[32] = 146957480;
			ints[33] = 146957480;
			ints[34] = 146957480;
			ints[35] = 146957480;
			ints[36] = 146957480;
			ints[37] = 50367728;
			ints[38] = 1886753605;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short43()
		{
			int[] ints = new int[7];
			ints[0] = -2147352027;
			ints[1] = 2130706756;
			ints[2] = -2147352797;
			this.IntroSort_Short<int>(ints);
		}

		[Test]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_Short44()
		{
			int[] ints = new int[7];
			ints[0] = 8192;
			ints[1] = 8126;
			this.IntroSort_Short<int>(ints);
		}

	}
}
