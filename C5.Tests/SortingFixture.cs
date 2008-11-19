using System;
using System.Diagnostics;
using Microsoft.Pex.Framework.Creatable;
using SCG = System.Collections.Generic;
using MbUnit.Framework;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;

namespace C5.Tests
{
    [Author("Marcus Griep")]
    [Category("Utility")]
    [TestsOn(typeof(Sorting))]
    [PexClass(typeof(Sorting), MaxConditions = 1000)]
    [PexGenericArguments(typeof(int))]
    [PexGenericArguments(typeof(double))]
    [PexGenericArguments(typeof(string))]
    public partial class SortingFixture
    {
        [PexMethod(MaxConditions = 4000)]
        [Description("Constructs a specially designed array that triggers quicksort's worst-case running time.")]
        public void IntroSort_WorstCase(int k)
        {
            PexAssume.IsTrue(0 < k && k < int.MaxValue / 2 && k % 2 == 0);
            var arr = new int[2 * k];

            for (var i = 1; i <= k; ++i)
            {
                if (i % 2 == 0)
                {
                    arr[k + i - 1] = 2 * i;
                    arr[k + i - 2] = 2 * i - 2;
                }
                else
                {
                    arr[i - 1] = i;
                    arr[i] = i + k;
                }
            }

            IntroSort_Short(arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        public void IntroSort_Short<T>(T[] arr)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.IntroSort(sorted);

            VerifyAscending(sorted);
            VerifyLengthNotChanged(sorted, arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        public void IntroSort_Full<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.IntroSort(sorted, start, count, SCG.Comparer<T>.Default);

            VerifyAscending(sorted, start, count);
            VerifyOtherElementsUnmodified(sorted, arr, start, count);
            VerifyLengthNotChanged(sorted, arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        public void InsertionSort<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.InsertionSort(sorted, start, count, SCG.Comparer<T>.Default);

            VerifyAscending(sorted, start, count);
            VerifyOtherElementsUnmodified(sorted, arr, start, count);
            VerifyLengthNotChanged(sorted, arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        public void HeapSort<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.HeapSort(sorted, start, count, SCG.Comparer<T>.Default);

            VerifyAscending(sorted, start, count);
            VerifyOtherElementsUnmodified(sorted, arr, start, count);
            VerifyLengthNotChanged(sorted, arr);
        }

        internal static void VerifyAscending<T>(T[] sorted)
        {
            VerifyAscending(sorted, 0, sorted.Length);
        }

        internal static void VerifyAscending<T>(T[] sorted, int start, int count)
        {
            for (var i = start + 1; i < start + count; ++i)
            {
                Assert.LessThanOrEqualTo(sorted[i - 1], sorted[i], SCG.Comparer<T>.Default.Compare,
                    "Items in the sort area are not properly sorted.");
            }
        }

        internal static void VerifyOtherElementsUnmodified<T>(T[] sorted, T[] arr, int start, int count)
        {
            var comparer = SCG.EqualityComparer<T>.Default;
            for (var i = 0; i < start; ++i)
            {
                Assert.AreEqual(arr[i], sorted[i], comparer,
                    "Items before the sort area should not be modified. Index: {0}", i);
            }
            for (var i = start + count + 1; i < sorted.Length; ++i)
            {
                Assert.AreEqual(arr[i], sorted[i], comparer,
                    "Items after the sort area should not be modified. Index: {0}", i);
            }
        }

        internal static void VerifyLengthNotChanged<T>(T[] sorted, T[] arr)
        {
            Assert.AreEqual(arr.Length, sorted.Length,
                "Sorting algorithms should not change the length of the result.");
        }
    }
}
