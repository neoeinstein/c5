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
    /// A generic collection that may be enumerated and can answer
    /// efficiently how many items it contains. Like <see cref="SCG.IEnumerable{T}"/>,
    /// this interface does not prescribe any operations to initialize or update the 
    /// collection. The main usage for this interface is to be the return type of 
    /// query operations on generic collection.
    /// </summary>
    public interface ICollectionValue<T> : SCG.IEnumerable<T>, IShowable
    {
        /// <summary>
        /// A flag bitmap of the Events subscribable to by this collection.
        /// </summary>
        /// <value></value>
        EventTypeEnum ListenableEvents { get; }

        /// <summary>
        /// A flag bitmap of the Events currently subscribed to by this collection.
        /// </summary>
        /// <value></value>
        EventTypeEnum ActiveEvents { get; }

        /// <summary>
        /// The change event. Will be raised for every change operation on the collection.
        /// </summary>
        event CollectionChangedHandler<T> CollectionChanged;

        /// <summary>
        /// The change event. Will be raised for every clear operation on the collection.
        /// </summary>
        event CollectionClearedHandler<T> CollectionCleared;

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        event ItemsAddedHandler<T> ItemsAdded;

        /// <summary>
        /// The item inserted  event. Will be raised for every individual insertion to the collection.
        /// </summary>
        event ItemInsertedHandler<T> ItemInserted;

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        event ItemsRemovedHandler<T> ItemsRemoved;

        /// <summary>
        /// The item removed at event. Will be raised for every individual removal at from the collection.
        /// </summary>
        event ItemRemovedAtHandler<T> ItemRemovedAt;

        /// <summary>
        /// 
        /// </summary>
        /// <value>True if this collection is empty.</value>
        bool IsEmpty { get; }

        /// <summary>
        /// </summary>
        /// <value>The number of items in this collection</value>
        int Count { get; }

        /// <summary>
        /// The value is symbolic indicating the type of asymptotic complexity
        /// in terms of the size of this collection (worst-case or amortized as
        /// relevant).
        /// </summary>
        /// <value>A characterization of the speed of the 
        /// <code>Count</code> property in this collection.</value>
        Speed CountSpeed { get; }

        /// <summary>
        /// Copy the items of this collection to a contiguous part of an array.
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="index">The index at which to copy the first item</param>
        void CopyTo(T[] array, int index);

        /// <summary>
        /// Create an array with the items of this collection (in the same order as an
        /// enumerator would output them).
        /// </summary>
        /// <returns>The array</returns>
        T[] ToArray();

        /// <summary>
        /// Apply a delegate to all items of this collection.
        /// </summary>
        /// <param name="action">The delegate to apply</param>
        void Apply(Action<T> action);


        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection.
        /// </summary>
        /// <param name="predicate">A  delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>True is such an item exists</returns>
        bool Exists(Predicate<T> predicate);

        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in this collection and return the first one in enumeration order.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <param name="item"></param>
        /// <returns>True is such an item exists</returns>
        bool Find(Predicate<T> predicate, out T item);


        /// <summary>
        /// Check if all items in this collection satisfies a specific predicate.
        /// </summary>
        /// <param name="predicate">A delegate 
        /// (<see cref="T:C5.Fun`2"/> with <code>R == bool</code>) defining the predicate</param>
        /// <returns>True if all items satisfies the predicate</returns>
        bool All(Predicate<T> predicate);

        /// <summary>
        /// Choose some item of this collection. 
        /// <para>Implementations must assure that the item 
        /// returned may be efficiently removed.</para>
        /// <para>Implementors may decide to implement this method in a way such that repeated
        /// calls do not necessarily give the same result, i.e. so that the result of the following 
        /// test is undetermined:
        /// <code>coll.Choose() == coll.Choose()</code></para>
        /// </summary>
        /// <exception cref="NoSuchItemException">if collection is empty.</exception>
        /// <returns></returns>
        T Choose();

        /// <summary>
        /// Create an enumerable, enumerating the items of this collection that satisfies 
        /// a certain condition.
        /// </summary>
        /// <param name="filter">The T->bool filter delegate defining the condition</param>
        /// <returns>The filtered enumerable</returns>
        SCG.IEnumerable<T> Filter(Predicate<T> filter);
    }
}