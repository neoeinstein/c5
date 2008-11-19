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
		[Description("Constructs a specially designed array that triggers quicksort\'s worst-case running time.")]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_WorstCase01()
		{
			this.IntroSort_WorstCase(2);
		}

		[Test]
		[Description("Constructs a specially designed array that triggers quicksort\'s worst-case running time.")]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_WorstCase02()
		{
			this.IntroSort_WorstCase(4);
		}

		[Test]
		[Description("Constructs a specially designed array that triggers quicksort\'s worst-case running time.")]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_WorstCase03()
		{
			this.IntroSort_WorstCase(16);
		}

		[Test]
		[Description("Constructs a specially designed array that triggers quicksort\'s worst-case running time.")]
		[PexGeneratedBy(typeof(SortingFixture))]
		public void IntroSort_WorstCase04()
		{
			this.IntroSort_WorstCase(20);
		}

	}
}
