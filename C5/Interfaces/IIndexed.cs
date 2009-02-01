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
    /// A sequenced collection, where indices of items in the order are maintained
    /// </summary>
    public interface IIndexed<T> : ISequenced<T>
    {
        /// <summary>
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"> if <code>index</code> is negative or
        /// &gt;= the size of the collection.</exception>
        /// <value>The <code>index</code>'th item of this list.</value>
        /// <param name="index">the index to lookup</param>
        T this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        Speed IndexingSpeed { get; }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <value>The directed collection of items in a specific index interval.</value>
        /// <param name="start">The low index of the interval (inclusive).</param>
        /// <param name="count">The size of the range.</param>
        IDirectedCollectionValue<T> this[int start, int count] { get; }


        /// <summary>
        /// Searches for an item in the list going forwards from the start. 
        /// </summary>
        /// <param name="item">Item to search for.</param>
        /// <returns>Index of item from start. A negative number if item not found, 
        /// namely the one's complement of the index at which the Add operation would put the item.</returns>
        int IndexOf(T item);


        /// <summary>
        /// Searches for an item in the list going backwards from the end.
        /// </summary>
        /// <param name="item">Item to search for.</param>
        /// <returns>Index of of item from the end. A negative number if item not found, 
        /// namely the two-complement of the index at which the Add operation would put the item.</returns>
        int LastIndexOf(T item);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the index of the first one.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>the index, if found, a negative value else</returns>
        int FindIndex(Predicate<T> predicate);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the index of the last one.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>the index, if found, a negative value else</returns>
        int FindLastIndex(Predicate<T> predicate);


        /// <summary>
        /// Remove the item at a specific position of the list.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"> if <code>index</code> is negative or
        /// &gt;= the size of the collection.</exception>
        /// <param name="index">The index of the item to remove.</param>
        /// <returns>The removed item.</returns>
        T RemoveAt(int index);


        /// <summary>
        /// Remove all items in an index interval.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> if start or count 
        /// is negative or start+count &gt; the size of the collection.</exception>
        /// <param name="start">The index of the first item to remove.</param>
        /// <param name="count">The number of items to remove.</param>
        void RemoveInterval(int start, int count);
    }
}