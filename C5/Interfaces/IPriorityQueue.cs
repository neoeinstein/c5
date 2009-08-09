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

using SCG = System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A generic collection of items prioritized by a comparison (order) relation.
    /// Supports adding items and reporting or removing extremal elements. 
    /// <para>
    /// 
    /// </para>
    /// When adding an item, the user may choose to have a handle allocated for this item in the queue. 
    /// The resulting handle may be used for deleting the item even if not extremal, and for replacing the item.
    /// A priority queue typically only holds numeric priorities associated with some objects
    /// maintained separately in other collection objects.
    /// </summary>
    public interface IPriorityQueue<T> : IExtensible<T>
    {
        /// <summary>
        /// Find the current least item of this priority queue.
        /// </summary>
        /// <returns>The least item.</returns>
        T FindMin();


        /// <summary>
        /// Remove the least item from this  priority queue.
        /// </summary>
        /// <returns>The removed item.</returns>
        T DeleteMin();


        /// <summary>
        /// Find the current largest item of this priority queue.
        /// </summary>
        /// <returns>The largest item.</returns>
        T FindMax();


        /// <summary>
        /// Remove the largest item from this priority queue.
        /// </summary>
        /// <returns>The removed item.</returns>
        T DeleteMax();

        /// <summary>
        /// The comparer object supplied at creation time for this collection
        /// </summary>
        /// <value>The comparer</value>
        SCG.IComparer<T> Comparer { get; }
        /// <summary>
        /// Get or set the item corresponding to a handle. Throws exceptions on 
        /// invalid handles.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        T this[IPriorityQueueHandle<T> handle] { get; set; }

        /// <summary>
        /// Check if the entry corresponding to a handle is in the priority queue.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Find(IPriorityQueueHandle<T> handle, out T item);

        /// <summary>
        /// Add an item to the priority queue, receiving a 
        /// handle for the item in the queue, 
        /// or reusing an existing unused handle.
        /// </summary>
        /// <param name="handle">On output: a handle for the added item. 
        /// On input: null for allocating a new handle, or a currently unused handle for reuse. 
        /// A handle for reuse must be compatible with this priority queue, 
        /// by being created by a priority queue of the same runtime type, but not 
        /// necessarily the same priority queue object.</param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Add(ref IPriorityQueueHandle<T> handle, T item);

        /// <summary>
        /// Delete an item with a handle from a priority queue
        /// </summary>
        /// <param name="handle">The handle for the item. The handle will be invalidated, but reusable.</param>
        /// <returns>The deleted item</returns>
        T Delete(IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Replace an item with a handle in a priority queue with a new item. 
        /// Typically used for changing the priority of some queued object.
        /// </summary>
        /// <param name="handle">The handle for the old item</param>
        /// <param name="item">The new item</param>
        /// <returns>The old item</returns>
        T Replace(IPriorityQueueHandle<T> handle, T item);

        /// <summary>
        /// Find the current least item of this priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the item.</param>
        /// <returns>The least item.</returns>
        T FindMin(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Find the current largest item of this priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the item.</param>
        /// <returns>The largest item.</returns>

        T FindMax(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Remove the least item from this  priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the removed item.</param>
        /// <returns>The removed item.</returns>

        T DeleteMin(out IPriorityQueueHandle<T> handle);

        /// <summary>
        /// Remove the largest item from this  priority queue.
        /// </summary>
        /// <param name="handle">On return: the handle of the removed item.</param>
        /// <returns>The removed item.</returns>
        T DeleteMax(out IPriorityQueueHandle<T> handle);
    }
}