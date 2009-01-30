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
    public partial class SortingFixture
    {
        [PexMethod(MaxConditions = 4000)]
        [Description("Constructs a specially designed array that triggers quicksort's worst-case running time.")]
        [Parallelizable]
        // Examples: {1, 3, 2, 4} and {1, 5, 3, 7, 2, 4, 6, 8}
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

            PexStore.Value("array", arr);

            IntroSort_Short(arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [Parallelizable]
        public void IntroSort_Short<T>(T[] arr)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.IntroSort(sorted);

            PexStore.Value("sorted", sorted);

            AssertSorted(sorted, arr);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        [Parallelizable]
        public void IntroSort_Full<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.IntroSort(sorted, start, count, SCG.Comparer<T>.Default);

            PexStore.Value("sorted", sorted);

            AssertSorted(sorted, arr, start, count);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        [Parallelizable]
        public void InsertionSort<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.InsertionSort(sorted, start, count, SCG.Comparer<T>.Default);

            PexStore.Value("sorted", sorted);

            AssertSorted(sorted, arr, start, count);
        }

        [PexMethod]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentNullException))]
        [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentOutOfRangeException))]
        [Parallelizable]
        public void HeapSort<T>(T[] arr, int start, int count)
        {
            var sorted = arr == null ? null : (T[])arr.Clone();

            Sorting.HeapSort(sorted, start, count, SCG.Comparer<T>.Default);

            PexStore.Value("sorted", sorted);

            AssertSorted(sorted, arr, start, count);
        }

        internal static void AssertSorted<T>(T[] sorted, T[] arr)
        {
            AssertSorted(sorted, arr, 0, sorted.Length);
        }

        internal static void AssertSorted<T>(T[] sorted, T[] arr, int start, int count)
        {
            Assert.AreEqual(arr.Length, sorted.Length,
                "Sorting algorithms should not change the length of the result.");

            var comparison = new Comparison<T>(SCG.Comparer<T>.Default.Compare);
            var eqalityComparer = SCG.EqualityComparer<T>.Default;

            var i = 0;

            for (; i < start; ++i)
            {
                Assert.AreEqual(arr[i], sorted[i], eqalityComparer,
                    "Items outside the sort area should not be modified. Index: {0}", i);
            }
            for (++i; i < start + count; ++i)
            {
                Assert.LessThanOrEqualTo(sorted[i - 1], sorted[i], comparison,
                    "Items in the sort area are not properly sorted. Index: {0}", i);
            }
            for (; i < sorted.Length; ++i)
            {
                Assert.AreEqual(arr[i], sorted[i], eqalityComparer,
                    "Items outside the sort area should not be modified. Index: {0}", i);
            }
        }
    }
}
