/*
 Copyright (c) 2003-2006 Niels Kokholm and Peter Sestoft
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
*/

using System;
using SCG = System.Collections.Generic;
namespace C5
{
    /// <summary>
    /// A collection where items are maintained in sorted order together
    /// with their indexes in that order.
    /// </summary>
    public interface IIndexedSorted<T> : ISorted<T>, IIndexed<T>
    {
        /// <summary>
        /// Determine the number of items at or above a supplied threshold.
        /// </summary>
        /// <param name="bot">The lower bound (inclusive)</param>
        /// <returns>The number of matcing items.</returns>
        int CountFrom(T bot);


        /// <summary>
        /// Determine the number of items between two supplied thresholds.
        /// </summary>
        /// <param name="bot">The lower bound (inclusive)</param>
        /// <param name="top">The upper bound (exclusive)</param>
        /// <returns>The number of matcing items.</returns>
        int CountFromTo(T bot, T top);


        /// <summary>
        /// Determine the number of items below a supplied threshold.
        /// </summary>
        /// <param name="top">The upper bound (exclusive)</param>
        /// <returns>The number of matcing items.</returns>
        int CountTo(T top);


        /// <summary>
        /// Query this sorted collection for items greater than or equal to a supplied value.
        /// </summary>
        /// <param name="bot">The lower bound (inclusive).</param>
        /// <returns>The result directed collection.</returns>
        new IDirectedCollectionValue<T> RangeFrom(T bot);


        /// <summary>
        /// Query this sorted collection for items between two supplied values.
        /// </summary>
        /// <param name="bot">The lower bound (inclusive).</param>
        /// <param name="top">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        new IDirectedCollectionValue<T> RangeFromTo(T bot, T top);


        /// <summary>
        /// Query this sorted collection for items less than a supplied value.
        /// </summary>
        /// <param name="top">The upper bound (exclusive).</param>
        /// <returns>The result directed collection.</returns>
        new IDirectedCollectionValue<T> RangeTo(T top);


        /// <summary>
        /// Create a new indexed sorted collection consisting of the items of this
        /// indexed sorted collection satisfying a certain predicate.
        /// </summary>
        /// <param name="predicate">The filter delegate defining the predicate.</param>
        /// <returns>The new indexed sorted collection.</returns>
        IIndexedSorted<T> FindAll(Predicate<T> predicate);


        /// <summary>
        /// Create a new indexed sorted collection consisting of the results of
        /// mapping all items of this list.
        /// <exception cref="ArgumentException"/> if the map is not increasing over 
        /// the items of this collection (with respect to the two given comparison 
        /// relations).
        /// </summary>
        /// <param name="mapper">The delegate definging the map.</param>
        /// <param name="comparer">The comparion relation to use for the result.</param>
        /// <returns>The new sorted collection.</returns>
        IIndexedSorted<V> Map<V>(Converter<T, V> mapper, SCG.IComparer<V> comparer);
    }
}