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
    /// The interface describing the operations of a FIFO queue data structure.
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    public interface IQueue<T> : IDirectedCollectionValue<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        bool AllowsDuplicates { get; }
        /// <summary>
        /// Get the <code>index</code>'th element of the queue.  The front of the queue has index 0.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// Enqueue an item at the back of the queue. 
        /// </summary>
        /// <param name="item">The item</param>
        void Enqueue(T item);
        /// <summary>
        /// Dequeue an item from the front of the queue.
        /// </summary>
        /// <returns>The item</returns>
        T Dequeue();
    }
}