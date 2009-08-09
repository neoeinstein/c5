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
using System.Diagnostics.Contracts;
using SCG = System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A generic collection to which one may add items. This is just the intersection
    /// of the main stream generic collection interfaces and the priority queue interface,
    /// <see cref="T:C5.ICollection{T}"/> and <see cref="T:C5.IPriorityQueue{T}"/>.
    /// </summary>
    [ContractClass(typeof(Contracts.IExtensibleContract<>))]
    public interface IExtensible<T> : ICollectionValue<T>, ICloneable
    {
        /// <summary>
        /// If true any call of an updating operation will throw an
        /// <see cref="ReadOnlyCollectionException"/>
        /// </summary>
        /// <value>True if this collection is read-only.</value>
        bool IsReadOnly { get; }

        //TODO: wonder where the right position of this is
        /// <summary>
        /// 
        /// </summary>
        /// <value>False if this collection has set semantics, true if bag semantics.</value>
        bool AllowsDuplicates { get; }

        //TODO: wonder where the right position of this is. And the semantics.
        /// <summary>
        /// (Here should be a discussion of the role of equalityComparers. Any ). 
        /// </summary>
        /// <value>The equalityComparer used by this collection to check equality of items. 
        /// Or null (????) if collection does not check equality at all or uses a comparer.</value>
        SCG.IEqualityComparer<T> EqualityComparer { get; }

        //ItemEqualityTypeEnum ItemEqualityType {get ;}

        //TODO: find a good name

        /// <summary>
        /// By convention this is true for any collection with set semantics.
        /// </summary>
        /// <value>True if only one representative of a group of equal items 
        /// is kept in the collection together with the total count.</value>
        bool DuplicatesByCounting { get; }

        /// <summary>
        /// Add an item to this collection if possible. If this collection has set
        /// semantics, the item will be added if not already in the collection. If
        /// bag semantics, the item will always be added.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>True if item was added.</returns>
        bool Add(T item);

        /// <summary>
        /// Add the elements from another collection with a more specialized item type 
        /// to this collection. If this
        /// collection has set semantics, only items not already in the collection
        /// will be added.
        /// </summary>
        /// <typeparam name="U">The type of items to add</typeparam>
        /// <param name="items">The items to add</param>
        void AddAll<U>(SCG.IEnumerable<U> items) where U : T;

        //void Clear(); // for priority queue
        //int Count why not?
        /// <summary>
        /// Check the integrity of the internal data structures of this collection.
        /// <i>This is only relevant for developers of the library</i>
        /// </summary>
        /// <returns>True if check was passed.</returns>
        [Pure]
        bool Check();
    }
}