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

namespace C5
{
    /// <summary>
    /// Specifies the types of events that can be subscribed to.
    /// </summary>
    [Flags]
    public enum EventTypeEnum
    {
        /// <summary>
        /// Raises no events.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Raises an event when the collection is changed.
        /// If multiple changes are made as part of one call,
        /// this event is only raised once for the operation.
        /// </summary>
        Changed = 0x00000001,

        /// <summary>
        /// Raises an event when the collection is cleared.
        /// </summary>
        /// <seealso cref="ICollection&lt;T&gt;.Clear()"/>
        Cleared = 0x00000002,

        /// <summary>
        /// Raises an event when an item is added to the collection.
        /// If multiple items are added at once, the event
        /// is raised once for each item added.
        /// </summary>
        /// <seealso cref="IExtensible&lt;T&gt;.Add(T)"/>
        Added = 0x00000004,

        /// <summary>
        /// Raises an event when an item is removed from the collection.
        /// If multiple items are removed at once, the event
        /// is raised once for each item removed.
        /// </summary>
        /// <seealso cref="ICollection&lt;T&gt;.Remove(T)"/>
        Removed = 0x00000008,

        /// <summary>
        /// Combination of <see cref="C5.EventTypeEnum.Changed"/>,
        /// <see cref="C5.EventTypeEnum.Cleared"/>, <see cref="C5.EventTypeEnum.Added"/>,
        /// and <see cref="C5.EventTypeEnum.Removed"/>. This is the basic set of
        /// events supported by an <see cref="C5.ICollection&lt;T&gt;"/>.
        /// </summary>
        Basic = Changed | Cleared | Added | Removed,

        /// <summary>
        /// Raises an event when an item is inserted into a collection at
        /// a specified position. If multiple items are inserted at once,
        /// the event is raised once for each item inserted.
        /// </summary>
        /// <seealso cref="C5.IList&lt;T&gt;.InsertFirst(T)"/>
        Inserted = 0x00000010,

        /// <summary>
        /// Raises an event when an item is removed from a collection by
        /// its specific index.
        /// </summary>
        /// <seealso cref="C5.IIndexed&lt;T&gt;.RemoveAt(int)"/>
        RemovedAt = 0x00000020,

        /// <summary>
        /// A combination of all supported event types supported by the
        /// library.
        /// </summary>
        All = Basic | Inserted | RemovedAt,
    }
}