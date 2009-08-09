﻿/*
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
using System.Diagnostics.Contracts;

namespace C5
{
    /// <summary>
    /// A sized generic collection, that can be enumerated backwards.
    /// </summary>
    [ContractClass(typeof(Contracts.IDirectedCollectionValueContract<>))]
    public interface IDirectedCollectionValue<T> : ICollectionValue<T>, IDirectedEnumerable<T>
    {
        /// <summary>
        /// Create a collection containing the same items as this collection, but
        /// whose enumerator will enumerate the items backwards. The new collection
        /// will become invalid if the original is modified. Method typically used as in
        /// <code>foreach (T x in coll.Backwards()) {...}</code>
        /// </summary>
        /// <returns>The backwards collection.</returns>
        [Pure]
        new IDirectedCollectionValue<T> Backwards();

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the first one in enumeration order.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <param name="item"></param>
        /// <returns>True is such an item exists</returns>
        [Pure]
        bool FindLast(Predicate<T> predicate, out T item);
    }
}