// <copyright file="$(FileName)" company="">Copyright © 2008</copyright>
// <auto-generated>This code was generated by a Microsoft Pex.
// 
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.</auto-generated>
using System;
using C5.Tests;
using MbUnit.Framework;
using Microsoft.Pex.Framework.Generated;

namespace C5.Tests
{
    public partial class SortingFixture
    {
        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort01()
        {
            int[] ints = new int[0];
            this.InsertionSort<int>(ints, 2, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort02()
        {
            int[] ints = new int[1];
            this.InsertionSort<int>(ints, 0, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort03()
        {
            int[] ints = new int[1];
            this.InsertionSort<int>(ints, 0, 0);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort04()
        {
            int[] ints = new int[3];
            this.InsertionSort<int>(ints, 0, 2);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort05()
        {
            int[] ints = new int[1];
            this.InsertionSort<int>(ints, 0, int.MinValue);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort06()
        {
            int[] ints = new int[2];
            this.InsertionSort<int>(ints, 1, 0);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort07()
        {
            int[] ints = new int[2];
            this.InsertionSort<int>(ints, 1, 2);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort08()
        {
            int[] ints = new int[3];
            ints[0] = 2147467264;
            ints[1] = -2147483646;
            ints[2] = 2147467264;
            this.InsertionSort<int>(ints, 0, 2);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertionSort09()
        {
            this.InsertionSort<int>((int[])null, 2, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort10()
        {
            int[] ints = new int[0];
            this.InsertionSort<int>(ints, int.MinValue, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort11()
        {
            int[] ints = new int[3];
            ints[0] = 2046;
            ints[1] = 2048;
            ints[2] = 2048;
            this.InsertionSort<int>(ints, 0, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort12()
        {
            int[] ints = new int[7];
            ints[0] = 2046;
            ints[1] = 2048;
            ints[2] = 2048;
            ints[3] = 2048;
            ints[4] = 2048;
            ints[5] = 2048;
            ints[6] = 2048;
            this.InsertionSort<int>(ints, 0, 4);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort13()
        {
            int[] ints = new int[3];
            this.InsertionSort<int>(ints, 2, 0);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort14()
        {
            int[] ints = new int[3];
            ints[0] = 2013265886;
            ints[1] = -2147483618;
            ints[2] = 939525119;
            this.InsertionSort<int>(ints, 0, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort15()
        {
            int[] ints = new int[3];
            ints[0] = 2147483632;
            ints[1] = 8;
            ints[2] = -2147483639;
            this.InsertionSort<int>(ints, 0, 3);
        }

        [Test]
        [PexGeneratedBy(typeof(SortingFixture))]
        public void InsertionSort16()
        {
            int[] ints = new int[7];
            ints[0] = 2147483632;
            ints[1] = 8;
            ints[2] = -2147483639;
            ints[3] = -2147483639;
            ints[4] = -2147483639;
            ints[5] = -2147483639;
            ints[6] = -2147483639;
            this.InsertionSort<int>(ints, 0, 4);
        }
    }
}
