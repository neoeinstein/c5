// <copyright file="$(FileName)" company="">Copyright © 2008</copyright>
// <auto-generated>This code was generated by a Microsoft Pex.
// 
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.</auto-generated>
using C5.Tests;
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
