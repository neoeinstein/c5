/*
 * Copyright (c) 2003-2006 Niels Kokholm and Peter Sestoft
 * Copyright (c) 2009 Marcus Griep
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace C5
{
    /// <summary>
    /// The type of event raised after an operation on a collection has changed its contents.
    /// Normally, a multioperation like AddAll, 
    /// <see cref="M:C5.IExtensible`1.AddAll(System.Collections.Generic.IEnumerable{`0})"/> 
    /// will only fire one CollectionChanged event. Any operation that changes the collection
    /// must fire CollectionChanged as its last event.
    /// </summary>
    public delegate void CollectionChangedHandler<T>(object sender);

    /// <summary>
    /// The type of event raised after the Clear() operation on a collection.
    /// <para/>
    /// Note: The Clear() operation will not fire ItemsRemoved Events. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    public delegate void CollectionClearedHandler<T>(object sender, ClearedEventArgs eventArgs);

    /// <summary>
    /// The type of event raised after an item has been added to a collection.
    /// The event will be raised at a point of time, where the collection object is 
    /// in an internally consistent state and before the corresponding CollectionChanged 
    /// event is raised.
    /// <para/>
    /// Note: an Update operation will fire an ItemsRemoved and an ItemsAdded event.
    /// <para/>
    /// Note: When an item is inserted into a list (<see cref="T:C5.IList`1"/>), both
    /// ItemInserted and ItemsAdded Events will be fired.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs">An object with the item that was added</param>
    public delegate void ItemsAddedHandler<T>(object sender, ItemCountEventArgs<T> eventArgs);

    /// <summary>
    /// The type of event raised after an item has been removed from a collection.
    /// The event will be raised at a point of time, where the collection object is 
    /// in an internally consistent state and before the corresponding CollectionChanged 
    /// event is raised.
    /// <para/>
    /// Note: The Clear() operation will not fire ItemsRemoved Events. 
    /// <para/>
    /// Note: an Update operation will fire an ItemsRemoved and an ItemsAdded event.
    /// <para/>
    /// Note: When an item is removed from a list by the RemoveAt operation, both an 
    /// ItemsRemoved and an ItemRemovedAt event will be fired.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs">An object with the item that was removed</param>
    public delegate void ItemsRemovedHandler<T>(object sender, ItemCountEventArgs<T> eventArgs);

    /// <summary>
    /// The type of event raised after an item has been inserted into a list by an Insert, 
    /// InsertFirst or InsertLast operation.
    /// The event will be raised at a point of time, where the collection object is 
    /// in an internally consistent state and before the corresponding CollectionChanged 
    /// event is raised.
    /// <para/>
    /// Note: an ItemsAdded event will also be fired.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    public delegate void ItemInsertedHandler<T>(object sender, ItemAtEventArgs<T> eventArgs);

    /// <summary>
    /// The type of event raised after an item has been removed from a list by a RemoveAt(int i)
    /// operation (or RemoveFirst(), RemoveLast(), Remove() operation).
    /// The event will be raised at a point of time, where the collection object is 
    /// in an internally consistent state and before the corresponding CollectionChanged 
    /// event is raised.
    /// <para/>
    /// Note: an ItemRemoved event will also be fired.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    public delegate void ItemRemovedAtHandler<T>(object sender, ItemAtEventArgs<T> eventArgs);
}