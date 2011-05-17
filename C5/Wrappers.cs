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
    /// A read-only wrapper class for a generic enumerator
    /// </summary>
    public class GuardedEnumerator<T> : SCG.IEnumerator<T>
    {
        #region Fields

        SCG.IEnumerator<T> enumerator;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a wrapper around a generic enumerator
        /// </summary>
        /// <param name="enumerator">The enumerator to wrap</param>
        public GuardedEnumerator(SCG.IEnumerator<T> enumerator)
        { this.enumerator = enumerator; }

        #endregion

        #region IEnumerator<T> Members

        /// <summary>
        /// Move wrapped enumerator to next item, or the first item if
        /// this is the first call to MoveNext. 
        /// </summary>
        /// <returns>True if enumerator is valid now</returns>
        public bool MoveNext() { return enumerator.MoveNext(); }


        /// <summary>
        /// Undefined if enumerator is not valid (MoveNext hash been called returning true)
        /// </summary>
        /// <value>The current item of the wrapped enumerator.</value>
        public T Current { get { return enumerator.Current; } }

        #endregion

        #region IDisposable Members

        //TODO: consider possible danger of calling through to Dispose. 
        /// <summary>
        /// Dispose wrapped enumerator.
        /// </summary>
        public void Dispose() { enumerator.Dispose(); }

        #endregion


        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { return enumerator.Current; }
        }

        void System.Collections.IEnumerator.Reset()
        {
            enumerator.Reset();
        }

        #endregion
    }



    /// <summary>
    /// A read-only wrapper class for a generic enumerable
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedEnumerable<T> : SCG.IEnumerable<T>
    {
        #region Fields

        SCG.IEnumerable<T> enumerable;

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1"/> guarded by this wrapper
        /// </summary>
        protected SCG.IEnumerable<T> UnderlyingEnumerable
        {
            get { return enumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap an enumerable in a read-only wrapper
        /// </summary>
        /// <param name="enumerable">The enumerable to wrap</param>
        public GuardedEnumerable(SCG.IEnumerable<T> enumerable)
        { this.enumerable = enumerable; }

        #endregion

        #region SCG.IEnumerable<T> Members

        /// <summary>
        /// Get an enumerator from the wrapped enumerable
        /// </summary>
        /// <returns>The enumerator (itself wrapped)</returns>
        public SCG.IEnumerator<T> GetEnumerator()
        { return new GuardedEnumerator<T>(UnderlyingEnumerable.GetEnumerator()); }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }



    /// <summary>
    /// A read-only wrapper for a generic directed enumerable
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedDirectedEnumerable<T> : GuardedEnumerable<T>, IDirectedEnumerable<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IDirectedEnumerable`1"/> guarded by this wrapper
        /// </summary>
        protected IDirectedEnumerable<T> UnderlyingDirectedEnumerable
        {
            get { return (IDirectedEnumerable<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a directed enumerable in a read-only wrapper
        /// </summary>
        /// <param name="directedenumerable">the collection to wrap</param>
        public GuardedDirectedEnumerable(IDirectedEnumerable<T> directedenumerable)
            : base(directedenumerable)
        { }

        #endregion

        #region IDirectedEnumerable<T> Members

        /// <summary>
        /// Get a enumerable that enumerates the wrapped collection in the opposite direction
        /// </summary>
        /// <returns>The mirrored enumerable</returns>
        public IDirectedEnumerable<T> Backwards()
        { return new GuardedDirectedEnumerable<T>(UnderlyingDirectedEnumerable.Backwards()); }


        /// <summary>
        /// <code>Forwards</code> if same, else <code>Backwards</code>
        /// </summary>
        /// <value>The enumeration direction relative to the original collection.</value>
        public EnumerationDirection Direction
        { get { return UnderlyingDirectedEnumerable.Direction; } }

        #endregion
    }



    /// <summary>
    /// A read-only wrapper for an ICollectionValue&lt;T&gt;
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedCollectionValue<T> : GuardedEnumerable<T>, ICollectionValue<T>
    {
        #region Events
        /// <summary>
        /// The ListenableEvents value of the wrapped collection
        /// </summary>
        /// <value></value>
        public virtual EventTypeEnum ListenableEvents { get { return UnderlyingCollectionValue.ListenableEvents; } }

        /// <summary>
        /// The ActiveEvents value of the wrapped collection
        /// </summary>
        /// <value></value>
        public virtual EventTypeEnum ActiveEvents { get { return UnderlyingCollectionValue.ActiveEvents; } }

        ProxyEventBlock<T> eventBlock;
        /// <summary>
        /// The change event. Will be raised for every change operation on the collection.
        /// </summary>
        public event CollectionChangedHandler<T> CollectionChanged
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).CollectionChanged += value; }
            remove { if (eventBlock != null) eventBlock.CollectionChanged -= value; }
        }

        /// <summary>
        /// The change event. Will be raised for every change operation on the collection.
        /// </summary>
        public event CollectionClearedHandler<T> CollectionCleared
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).CollectionCleared += value; }
            remove { if (eventBlock != null) eventBlock.CollectionCleared -= value; }
        }

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        public event ItemsAddedHandler<T> ItemsAdded
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).ItemsAdded += value; }
            remove { if (eventBlock != null) eventBlock.ItemsAdded -= value; }
        }

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        public event ItemInsertedHandler<T> ItemInserted
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).ItemInserted += value; }
            remove { if (eventBlock != null) eventBlock.ItemInserted -= value; }
        }

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        public event ItemsRemovedHandler<T> ItemsRemoved
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).ItemsRemoved += value; }
            remove { if (eventBlock != null) eventBlock.ItemsRemoved -= value; }
        }

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        public event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add { (eventBlock ?? (eventBlock = new ProxyEventBlock<T>(this, UnderlyingCollectionValue))).ItemRemovedAt += value; }
            remove { if (eventBlock != null) eventBlock.ItemRemovedAt -= value; }
        }
        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="T:C5.ICollectionValue`1"/> guarded by this wrapper
        /// </summary>
        protected ICollectionValue<T> UnderlyingCollectionValue
        {
            get { return (ICollectionValue<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a ICollectionValue&lt;T&gt; in a read-only wrapper
        /// </summary>
        /// <param name="collectionvalue">the collection to wrap</param>
        public GuardedCollectionValue(ICollectionValue<T> collectionvalue)
            : base(collectionvalue)
        { }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Get the size of the wrapped collection
        /// </summary>
        /// <value>The size</value>
        public virtual bool IsEmpty { get { return UnderlyingCollectionValue.IsEmpty; } }

        /// <summary>
        /// Get the size of the wrapped collection
        /// </summary>
        /// <value>The size</value>
        public virtual int Count { get { return UnderlyingCollectionValue.Count; } }

        /// <summary>
        /// The value is symbolic indicating the type of asymptotic complexity
        /// in terms of the size of this collection (worst-case or amortized as
        /// relevant).
        /// </summary>
        /// <value>A characterization of the speed of the 
        /// <code>Count</code> property in this collection.</value>
        public virtual Speed CountSpeed { get { return UnderlyingCollectionValue.CountSpeed; } }

        /// <summary>
        /// Copy the items of the wrapped collection to an array
        /// </summary>
        /// <param name="a">The array</param>
        /// <param name="i">Starting offset</param>
        public virtual void CopyTo(T[] a, int i) { UnderlyingCollectionValue.CopyTo(a, i); }

        /// <summary>
        /// Create an array from the items of the wrapped collection
        /// </summary>
        /// <returns>The array</returns>
        public virtual T[] ToArray() { return UnderlyingCollectionValue.ToArray(); }

        /// <summary>
        /// Apply a delegate to all items of the wrapped enumerable.
        /// </summary>
        /// <param name="a">The delegate to apply</param>
        //TODO: change this to throw an exception?
        public virtual void Apply(Action<T> a) { UnderlyingCollectionValue.Apply(a); }


        /// <summary>
        /// Check if there exists an item  that satisfies a
        /// specific predicate in the wrapped enumerable.
        /// </summary>
        /// <param name="filter">A filter delegate 
        /// (<see cref="T:C5.Filter`1"/>) defining the predicate</param>
        /// <returns>True is such an item exists</returns>
        public virtual bool Exists(Func<T, bool> filter) { return UnderlyingCollectionValue.Exists(filter); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Find(Func<T, bool> filter, out T item) { return UnderlyingCollectionValue.Find(filter, out item); }

        /// <summary>
        /// Check if all items in the wrapped enumerable satisfies a specific predicate.
        /// </summary>
        /// <param name="filter">A filter delegate 
        /// (<see cref="T:C5.Filter`1"/>) defining the predicate</param>
        /// <returns>True if all items satisfies the predicate</returns>
        public virtual bool All(Func<T, bool> filter) { return UnderlyingCollectionValue.All(filter); }

        /// <summary>
        /// Create an enumerable, enumerating the items of this collection that satisfies 
        /// a certain condition.
        /// </summary>
        /// <param name="filter">The T->bool filter delegate defining the condition</param>
        /// <returns>The filtered enumerable</returns>
        public virtual SCG.IEnumerable<T> Filter(Func<T, bool> filter) { return UnderlyingCollectionValue.Filter(filter); }

        /// <summary>
        /// Choose some item of this collection. 
        /// </summary>
        /// <exception cref="NoSuchItemException">if collection is empty.</exception>
        /// <returns></returns>
        public virtual T Choose() { return UnderlyingCollectionValue.Choose(); }

        #endregion

        #region IShowable Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringbuilder"></param>
        /// <param name="formatProvider"></param>
        /// <param name="rest"></param>
        /// <returns></returns>
        public bool Show(System.Text.StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
        {
            return UnderlyingCollectionValue.Show(stringbuilder, ref rest, formatProvider);
        }
        #endregion

        #region IFormattable Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return UnderlyingCollectionValue.ToString(format, formatProvider);
        }

        #endregion
    }



    /// <summary>
    /// A read-only wrapper for a directed collection
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedDirectedCollectionValue<T> : GuardedCollectionValue<T>, IDirectedCollectionValue<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IDirectedCollectionValue`1"/> guarded by this wrapper
        /// </summary>
        protected IDirectedCollectionValue<T> UnderlyingDirectedCollectionValue
        {
            get { return (IDirectedCollectionValue<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a directed collection in a read-only wrapper
        /// </summary>
        /// <param name="directedcollection">the collection to wrap</param>
        public GuardedDirectedCollectionValue(IDirectedCollectionValue<T> directedcollection)
            : base(directedcollection)
        { }

        #endregion

        #region IDirectedCollection<T> Members

        /// <summary>
        /// Get a collection that enumerates the wrapped collection in the opposite direction
        /// </summary>
        /// <returns>The mirrored collection</returns>
        public virtual IDirectedCollectionValue<T> Backwards()
        { return new GuardedDirectedCollectionValue<T>(UnderlyingDirectedCollectionValue.Backwards()); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool FindLast(Func<T, bool> predicate, out T item) { return UnderlyingDirectedCollectionValue.FindLast(predicate, out item); }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        { return Backwards(); }


        /// <summary>
        /// <code>Forwards</code> if same, else <code>Backwards</code>
        /// </summary>
        /// <value>The enumeration direction relative to the original collection.</value>
        public EnumerationDirection Direction
        { get { return UnderlyingDirectedCollectionValue.Direction; } }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for an <see cref="T:C5.IExtensible`1"/>.
    /// </summary>
    public class GuardedExtensible<T> : GuardedCollectionValue<T>, IExtensible<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IExtensible`1"/> guarded by this wrapper
        /// </summary>
        protected IExtensible<T> UnderlyingExtensible
        {
            get { return (IExtensible<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap an IExtensible&lt;T&gt; in a read-only wrapper
        /// </summary>
        /// <param name="extensible">the collection to wrap</param>
        public GuardedExtensible(IExtensible<T> extensible)
            : base(extensible)
        { }

        #endregion

        #region IExtensible<T> Members

        /// <summary>
        /// (This is a read-only wrapper)
        /// </summary>
        /// <value>True</value>
        public virtual bool IsReadOnly { get { return true; } }

        /// <summary>
        /// Check  wrapped collection for internal consistency
        /// </summary>
        /// <returns>True if check passed</returns>
        public virtual bool Check() { return UnderlyingExtensible.Check(); }

        /// <summary> </summary>
        /// <value>False if wrapped collection has set semantics</value>
        public virtual bool AllowsDuplicates { get { return UnderlyingExtensible.AllowsDuplicates; } }

        //TODO: the equalityComparer should be guarded
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public virtual SCG.IEqualityComparer<T> EqualityComparer { get { return UnderlyingExtensible.EqualityComparer; } }

        /// <summary>
        /// By convention this is true for any collection with set semantics.
        /// </summary>
        /// <value>True if only one representative of a group of equal items 
        /// is kept in the collection together with the total count.</value>
        public virtual bool DuplicatesByCounting { get { return UnderlyingExtensible.DuplicatesByCounting; } }


        /// <summary> </summary>
        /// <value>True if wrapped collection is empty</value>
        public override bool IsEmpty { get { return UnderlyingExtensible.IsEmpty; } }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Add(T item)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public virtual void AddAll(SCG.IEnumerable<T> items)
        { throw new ReadOnlyCollectionException(); }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return new GuardedExtensible<T>((IExtensible<T>)(UnderlyingExtensible.Clone()));
        }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for a priority queue
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedPriorityQueue<T> : GuardedExtensible<T>, IPriorityQueue<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IPriorityQueue`1"/> guarded by this wrapper
        /// </summary>
        protected IPriorityQueue<T> UnderlyingPriorityQueue
        {
            get { return (IPriorityQueue<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a priority queue in a read-only wrapper
        /// </summary>
        /// <param name="priorityQueue"></param>
        public GuardedPriorityQueue(IPriorityQueue<T> priorityQueue) : base(priorityQueue) { }

        #endregion

        #region IPriorityQueue<T> Members

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T this[IPriorityQueueHandle<T> handle]
        {
            get { return UnderlyingPriorityQueue[handle]; }
            set { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <param name="item"></param>
        public virtual bool Add(ref IPriorityQueueHandle<T> handle, T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Find(IPriorityQueueHandle<T> handle, out T item)
        { return UnderlyingPriorityQueue.Find(handle, out item); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T Delete(IPriorityQueueHandle<T> handle)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// Find the minimum of the wrapped collection
        /// </summary>
        /// <returns>The minimum</returns>
        public virtual T FindMin() { return UnderlyingPriorityQueue.FindMin(); }

        /// <summary>
        /// Find the minimum of the wrapped collection
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T FindMin(out IPriorityQueueHandle<T> handle)
        { return UnderlyingPriorityQueue.FindMin(out handle); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public virtual T DeleteMin()
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T DeleteMin(out IPriorityQueueHandle<T> handle)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// Find the maximum of the wrapped collection
        /// </summary>
        /// <returns>The maximum</returns>
        public virtual T FindMax() { return UnderlyingPriorityQueue.FindMax(); }

        /// <summary>
        /// Find the maximum of the wrapped collection
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T FindMax(out IPriorityQueueHandle<T> handle)
        { return UnderlyingPriorityQueue.FindMax(out handle); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public virtual T DeleteMax()
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <returns></returns>
        public virtual T DeleteMax(out IPriorityQueueHandle<T> handle)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="handle"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual T Replace(IPriorityQueueHandle<T> handle, T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        //TODO: we should guard the comparer!
        /// <summary>
        /// The comparer object supplied at creation time for the underlying collection
        /// </summary>
        /// <value>The comparer</value>
        public virtual SCG.IComparer<T> Comparer { get { return UnderlyingPriorityQueue.Comparer; } }

        #endregion

        #region IClonable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedPriorityQueue<T>((IPriorityQueue<T>)(UnderlyingPriorityQueue.Clone()));
        }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for an <see cref="T:C5.ICollection`1"/>,
    /// <para>
    /// <i>Suitable for wrapping hash tables, <see cref="T:C5.HashSet`1"/>
    /// and <see cref="T:C5.HashBag`1"/>  </i></para>
    /// </summary>
    public class GuardedCollection<T> : GuardedExtensible<T>, ICollection<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.ICollection`1"/> guarded by this wrapper
        /// </summary>
        protected ICollection<T> UnderlyingCollection
        {
            get { return (ICollection<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap an ICollection&lt;T&gt; in a read-only wrapper
        /// </summary>
        /// <param name="collection">the collection to wrap</param>
        public GuardedCollection(ICollection<T> collection)
            : base(collection)
        { }

        #endregion

        #region ICollection<T> Members

        /// <summary> </summary>
        /// <value>Speed of wrapped collection</value>
        public virtual Speed ContainsSpeed { get { return UnderlyingCollection.ContainsSpeed; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetUnsequencedHashCode()
        { return UnderlyingCollection.GetUnsequencedHashCode(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public virtual bool UnsequencedEquals(ICollection<T> that)
        { return UnderlyingCollection.UnsequencedEquals(that); }


        /// <summary>
        /// Check if an item is in the wrapped collection
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>True if found</returns>
        public virtual bool Contains(T item) { return UnderlyingCollection.Contains(item); }


        /// <summary>
        /// Count the number of times an item appears in the wrapped collection
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The number of copies</returns>
        public virtual int ContainsCount(T item) { return UnderlyingCollection.ContainsCount(item); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ICollectionValue<T> UniqueItems() { return new GuardedCollectionValue<T>(UnderlyingCollection.UniqueItems()); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ICollectionValue<KeyValuePair<T, int>> ItemMultiplicities() { return new GuardedCollectionValue<KeyValuePair<T, int>>(UnderlyingCollection.ItemMultiplicities()); }

        /// <summary>
        /// Check if all items in the argument is in the wrapped collection
        /// </summary>
        /// <param name="items">The items</param>
        /// <returns>True if so</returns>
        public virtual bool ContainsAll(SCG.IEnumerable<T> items) { return UnderlyingCollection.ContainsAll(items); }

        /// <summary> 
        /// Search for an item in the wrapped collection
        /// </summary>
        /// <param name="item">On entry the item to look for, on exit the equivalent item found (if any)</param>
        /// <returns></returns>
        public virtual bool Find(ref T item) { return UnderlyingCollection.Find(ref item); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool FindOrAdd(ref T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Update(T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <param name="olditem"></param>
        /// <returns></returns>
        public virtual bool Update(T item, out T olditem)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool UpdateOrAdd(T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <param name="olditem"></param>
        /// <returns></returns>
        public virtual bool UpdateOrAdd(T item, out T olditem)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool Remove(T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item">The value to remove.</param>
        /// <param name="removeditem">The removed value.</param>
        /// <returns></returns>
        public virtual bool Remove(T item, out T removeditem)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        public virtual void RemoveAllCopies(T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public virtual void RemoveAll(SCG.IEnumerable<T> items)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        public virtual void Clear()
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public virtual void RetainAll(SCG.IEnumerable<T> items)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        #endregion

        #region System.Collections.Generic.ICollection<T> Members

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        void SCG.ICollection<T>.Add(T item)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedCollection<T>((ICollection<T>)(UnderlyingCollection.Clone()));
        }

        #endregion

    }

    /// <summary>
    /// A read-only wrapper for a sequenced collection
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedSequenced<T> : GuardedCollection<T>, ISequenced<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.ISequenced`1"/> guarded by this wrapper
        /// </summary>
        protected ISequenced<T> UnderlyingSequenced
        {
            get { return (ISequenced<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a sequenced collection in a read-only wrapper
        /// </summary>
        /// <param name="sequenced"></param>
        public GuardedSequenced(ISequenced<T> sequenced) : base(sequenced) { }

        #endregion

        #region ISequenced<T> Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSequencedHashCode()
        { return UnderlyingSequenced.GetSequencedHashCode(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public bool SequencedEquals(ISequenced<T> that)
        { return UnderlyingSequenced.SequencedEquals(that); }

        #endregion

        #region IDirectedCollection<T> Members

        /// <summary>
        /// Get a collection that enumerates the wrapped collection in the opposite direction
        /// </summary>
        /// <returns>The mirrored collection</returns>
        public virtual IDirectedCollectionValue<T> Backwards()
        { return new GuardedDirectedCollectionValue<T>(UnderlyingSequenced.Backwards()); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool FindLast(Func<T, bool> predicate, out T item) { return UnderlyingSequenced.FindLast(predicate, out item); }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        { return Backwards(); }



        /// <summary>
        /// <code>Forwards</code> if same, else <code>Backwards</code>
        /// </summary>
        /// <value>The enumeration direction relative to the original collection.</value>
        public EnumerationDirection Direction
        { get { return EnumerationDirection.Forwards; } }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedSequenced<T>((ISequenced<T>)(UnderlyingSequenced.Clone()));
        }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for a sorted collection
    ///
    /// <i>This is mainly interesting as a base of other guard classes</i>
    /// </summary>
    public class GuardedSorted<T> : GuardedSequenced<T>, ISorted<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.ISorted`1"/> guarded by this wrapper
        /// </summary>
        protected ISorted<T> UnderlyingSorted
        {
            get { return (ISorted<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a sorted collection in a read-only wrapper
        /// </summary>
        /// <param name="sorted"></param>
        public GuardedSorted(ISorted<T> sorted) : base(sorted) { }

        #endregion

        #region ISorted<T> Members

        /// <summary>
        /// Find the strict predecessor of item in the guarded sorted collection,
        /// that is, the greatest item in the collection smaller than the item.
        /// </summary>
        /// <param name="item">The item to find the predecessor for.</param>
        /// <param name="res">The predecessor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a predecessor; otherwise false.</returns>
        public bool TryPredecessor(T item, out T res) { return UnderlyingSorted.TryPredecessor(item, out res); }


        /// <summary>
        /// Find the strict successor of item in the guarded sorted collection,
        /// that is, the least item in the collection greater than the supplied value.
        /// </summary>
        /// <param name="item">The item to find the successor for.</param>
        /// <param name="res">The successor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a successor; otherwise false.</returns>
        public bool TrySuccessor(T item, out T res) { return UnderlyingSorted.TrySuccessor(item, out res); }


        /// <summary>
        /// Find the weak predecessor of item in the guarded sorted collection,
        /// that is, the greatest item in the collection smaller than or equal to the item.
        /// </summary>
        /// <param name="item">The item to find the weak predecessor for.</param>
        /// <param name="res">The weak predecessor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a weak predecessor; otherwise false.</returns>
        public bool TryWeakPredecessor(T item, out T res) { return UnderlyingSorted.TryWeakPredecessor(item, out res); }


        /// <summary>
        /// Find the weak successor of item in the sorted collection,
        /// that is, the least item in the collection greater than or equal to the supplied value.
        /// </summary>
        /// <param name="item">The item to find the weak successor for.</param>
        /// <param name="res">The weak successor, if any; otherwise the default value for T.</param>
        /// <returns>True if item has a weak successor; otherwise false.</returns>
        public bool TryWeakSuccessor(T item, out T res) { return UnderlyingSorted.TryWeakSuccessor(item, out res); }


        /// <summary>
        /// Find the predecessor of the item in the wrapped sorted collection
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists </exception>    
        /// <param name="item">The item</param>
        /// <returns>The predecessor</returns>
        public T Predecessor(T item) { return UnderlyingSorted.Predecessor(item); }


        /// <summary>
        /// Find the Successor of the item in the wrapped sorted collection
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists </exception>    
        /// <param name="item">The item</param>
        /// <returns>The Successor</returns>
        public T Successor(T item) { return UnderlyingSorted.Successor(item); }


        /// <summary>
        /// Find the weak predecessor of the item in the wrapped sorted collection
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists </exception>    
        /// <param name="item">The item</param>
        /// <returns>The weak predecessor</returns>
        public T WeakPredecessor(T item) { return UnderlyingSorted.WeakPredecessor(item); }


        /// <summary>
        /// Find the weak Successor of the item in the wrapped sorted collection
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such element exists </exception>    
        /// <param name="item">The item</param>
        /// <returns>The weak Successor</returns>
        public T WeakSuccessor(T item) { return UnderlyingSorted.WeakSuccessor(item); }


        /// <summary>
        /// Run Cut on the wrapped sorted collection
        /// </summary>
        /// <param name="c"></param>
        /// <param name="low"></param>
        /// <param name="lval"></param>
        /// <param name="high"></param>
        /// <param name="hval"></param>
        /// <returns></returns>
        public bool Cut(IComparable<T> c, out T low, out bool lval, out T high, out bool hval)
        { return UnderlyingSorted.Cut(c, out low, out lval, out high, out hval); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public IDirectedEnumerable<T> RangeFrom(T bot) { return UnderlyingSorted.RangeFrom(bot); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<T> RangeFromTo(T bot, T top)
        { return UnderlyingSorted.RangeFromTo(bot, top); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<T> RangeTo(T top) { return UnderlyingSorted.RangeTo(top); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <returns></returns>
        public IDirectedCollectionValue<T> RangeAll() { return UnderlyingSorted.RangeAll(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public void AddSorted(SCG.IEnumerable<T> items)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="low"></param>
        public void RemoveRangeFrom(T low)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="low"></param>
        /// <param name="hi"></param>
        public void RemoveRangeFromTo(T low, T hi)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="hi"></param>
        public void RemoveRangeTo(T hi)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        /// <summary>
        /// Find the minimum of the wrapped collection
        /// </summary>
        /// <returns>The minimum</returns>
        public T FindMin() { return UnderlyingSorted.FindMin(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public T DeleteMin()
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// Find the maximum of the wrapped collection
        /// </summary>
        /// <returns>The maximum</returns>
        public T FindMax() { return UnderlyingSorted.FindMax(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public T DeleteMax()
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        //TODO: we should guard the comparer!
        /// <summary>
        /// The comparer object supplied at creation time for the underlying collection
        /// </summary>
        /// <value>The comparer</value>
        public SCG.IComparer<T> Comparer { get { return UnderlyingSorted.Comparer; } }
        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        { return Backwards(); }

        #endregion

        #region IClonable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedSorted<T>((ISorted<T>)(UnderlyingSorted.Clone()));
        }

        #endregion
    }

    /// <summary>
    /// Read-only wrapper for indexed collections
    ///
    /// <i>Suitable for wrapping Lists, TreeSet, TreeBag and SortedArray</i>
    /// </summary>
    public class GuardedIndexed<T> : GuardedSequenced<T>, IIndexed<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IIndexed`1"/> guarded by this wrapper
        /// </summary>
        protected IIndexed<T> UnderlyingIndexed
        {
            get { return (IIndexed<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap an indexed collection in a read-only wrapper
        /// </summary>
        /// <param name="list">the indexed collection</param>
        public GuardedIndexed(IIndexed<T> list)
            : base(list)
        { }

        #endregion

        #region IIndexed<T> Members

        /// <summary>
        /// </summary>
        /// <value>The i'th item of the wrapped indexed collection</value>
        public T this[int i] { get { return UnderlyingIndexed[i]; } }

        /// <summary>
        /// </summary>
        /// <value></value>
        public virtual Speed IndexingSpeed { get { return UnderlyingIndexed.IndexingSpeed; } }

        /// <summary>
        /// </summary>
        /// <value>A directed collection of the items in the indicated interval of the wrapped collection</value>
        public IDirectedCollectionValue<T> this[int start, int end]
        { get { return new GuardedDirectedCollectionValue<T>(UnderlyingIndexed[start, end]); } }


        /// <summary>
        /// Finds the index of the first item in the collection that satifies the predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindIndex(Func<T, bool> predicate)
        {
            return UnderlyingIndexed.FindIndex(predicate);
        }

        /// <summary>
        /// Finds the index of the last item of the collection that satisfies the predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindLastIndex(Func<T, bool> predicate)
        {
            return UnderlyingIndexed.FindLastIndex(predicate);
        }

        /// <summary>
        /// Find the (first) index of an item in the wrapped collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item) { return UnderlyingIndexed.IndexOf(item); }


        /// <summary>
        /// Find the last index of an item in the wrapped collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int LastIndexOf(T item) { return UnderlyingIndexed.LastIndexOf(item); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="i"></param>
        /// <returns></returns>
        public T RemoveAt(int i)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="start"></param>
        /// <param name="count"></param>
        public void RemoveInterval(int start, int count)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Returns a read-only wrapped clone of the wrapped collection
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedIndexed<T>((IIndexed<T>)(UnderlyingIndexed.Clone()));
        }

        #endregion
    }


    /// <summary>
    /// Read-only wrapper for indexed sorted collections
    ///
    /// <i>Suitable for wrapping TreeSet, TreeBag and SortedArray</i>
    /// </summary>
    public class GuardedIndexedSorted<T> : GuardedSorted<T>, IIndexedSorted<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IIndexedSorted`1"/> guarded by this wrapper
        /// </summary>
        protected IIndexedSorted<T> UnderlyingIndexedSorted
        {
            get { return (IIndexedSorted<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap an indexed sorted collection in a read-only wrapper
        /// </summary>
        /// <param name="list">the indexed sorted collection</param>
        public GuardedIndexedSorted(IIndexedSorted<T> list)
            : base(list)
        { }

        #endregion

        #region IIndexedSorted<T> Members

        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public new IDirectedCollectionValue<T> RangeFrom(T bot)
        { return UnderlyingIndexedSorted.RangeFrom(bot); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public new IDirectedCollectionValue<T> RangeFromTo(T bot, T top)
        { return UnderlyingIndexedSorted.RangeFromTo(bot, top); }


        /// <summary>
        /// Get the specified range from the wrapped collection. 
        /// (The current implementation erroneously does not wrap the result.)
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public new IDirectedCollectionValue<T> RangeTo(T top)
        { return UnderlyingIndexedSorted.RangeTo(top); }


        /// <summary>
        /// Report the number of items in the specified range of the wrapped collection
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public int CountFrom(T bot) { return UnderlyingIndexedSorted.CountFrom(bot); }


        /// <summary>
        /// Report the number of items in the specified range of the wrapped collection
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public int CountFromTo(T bot, T top) { return UnderlyingIndexedSorted.CountFromTo(bot, top); }


        /// <summary>
        /// Report the number of items in the specified range of the wrapped collection
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public int CountTo(T top) { return UnderlyingIndexedSorted.CountTo(top); }


        /// <summary>
        /// Run FindAll on the wrapped collection with the indicated filter.
        /// The result will <b>not</b> be read-only.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public IIndexedSorted<T> FindAll(Func<T, bool> f)
        { return UnderlyingIndexedSorted.FindAll(f); }


        /// <summary>
        /// Run Map on the wrapped collection with the indicated mapper.
        /// The result will <b>not</b> be read-only.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="c">The comparer to use in the result</param>
        /// <returns></returns>
        public IIndexedSorted<V> Map<V>(Func<T, V> m, SCG.IComparer<V> c)
        { return UnderlyingIndexedSorted.Map(m, c); }

        #endregion

        #region IIndexed<T> Members

        /// <summary>
        /// 
        /// </summary>
        /// <value>The i'th item of the wrapped indexed collection</value>
        public virtual T this[int i] { get { return UnderlyingIndexedSorted[i]; } }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public virtual Speed IndexingSpeed { get { return UnderlyingIndexedSorted.IndexingSpeed; } }

        /// <summary> </summary>
        /// <value>A directed collection of the items in the indicated interval of the wrapped collection</value>
        public IDirectedCollectionValue<T> this[int start, int end]
        { get { return new GuardedDirectedCollectionValue<T>(UnderlyingIndexedSorted[start, end]); } }


        /// <summary>
        /// Finds the index of the first item in the collection that satisfies the predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindIndex(Func<T, bool> predicate)
        {
            return UnderlyingIndexedSorted.FindIndex(predicate);
        }

        /// <summary>
        /// Finds the index of the last item in the collection that satisfies the predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindLastIndex(Func<T, bool> predicate)
        {
            return UnderlyingIndexedSorted.FindLastIndex(predicate);
        }

        /// <summary>
        /// Find the (first) index of an item in the wrapped collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item) { return UnderlyingIndexedSorted.IndexOf(item); }


        /// <summary>
        /// Find the last index of an item in the wrapped collection
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int LastIndexOf(T item) { return UnderlyingIndexedSorted.LastIndexOf(item); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="i"></param>
        /// <returns></returns>
        public T RemoveAt(int i)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="start"></param>
        /// <param name="count"></param>
        public void RemoveInterval(int start, int count)
        { throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object"); }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        { return Backwards(); }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedIndexedSorted<T>((IIndexedSorted<T>)(UnderlyingIndexedSorted.Clone()));
        }

        #endregion
    }



    /// <summary>
    /// A read-only wrapper for a generic list collection
    /// <i>Suitable as a wrapper for LinkedList, HashedLinkedList, ArrayList and HashedArray.
    /// <see cref="T:C5.LinkedList`1"/>, 
    /// <see cref="T:C5.HashedLinkedList`1"/>, 
    /// <see cref="T:C5.ArrayList`1"/> or
    /// <see cref="T:C5.HashedArrayList`1"/>.
    /// </i>
    /// </summary>
    public class GuardedList<T> : GuardedIndexed<T>, IList<T>, SCG.IList<T>
    {
        #region Fields

        private readonly GuardedList<T> underlyingList_Underlying;
        private readonly bool isSlidableView;

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IList`1"/> guarded by this wrapper
        /// </summary>
        protected IList<T> UnderlyingList
        {
            get { return (IList<T>)UnderlyingEnumerable; }
        }

        /// <summary>
        /// The <see cref="T:C5.IList`1"/> that underlies the <see cref="UnderlyingList"/>.
        /// This is non-null when the <see cref="UnderlyingList"/> is a view.
        /// </summary>
        protected GuardedList<T> UnderlyingList_Underlying
        {
            get { return underlyingList_Underlying; }
        }

        /// <summary>
        /// Whether the wrapped list is a view that should be allowed to slide over the underlying list
        /// </summary>
        protected bool IsSlidableView
        {
            get { return isSlidableView; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a list in a read-only wrapper.  A list gets wrapped as read-only,
        /// a list view gets wrapped as read-only and non-slidable.
        /// </summary>
        /// <param name="list">The list</param>
        public GuardedList(IList<T> list)
            : base(list)
        {
            // If wrapping a list view, make innerlist = the view, and make 
            // underlying = a guarded version of the view's underlying list
            if (list.Underlying != null)
                this.underlyingList_Underlying = new GuardedList<T>(list.Underlying, null, false);
        }

        GuardedList(IList<T> list, GuardedList<T> underlying, bool slidableView)
            : base(list)
        {
            this.underlyingList_Underlying = underlying; this.isSlidableView = slidableView;
        }
        #endregion

        #region IList<T> Members

        /// <summary>
        /// 
        /// </summary>
        /// <value>The first item of the wrapped list</value>
        public T First { get { return UnderlyingList.First; } }


        /// <summary>
        /// 
        /// </summary>
        /// <value>The last item of the wrapped list</value>
        public T Last { get { return UnderlyingList.Last; } }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> if used as setter</exception>
        /// <value>True if wrapped list has FIFO semantics for the Add(T item) and Remove() methods</value>
        public bool FIFO
        {
            get { return UnderlyingList.FIFO; }
            set { throw new ReadOnlyCollectionException("List is read only"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsFixedSize
        {
            get { return true; }
        }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> if used as setter</exception>
        /// <value>The i'th item of the wrapped list</value>
        public new T this[int i]
        {
            get { return UnderlyingList[i]; }
            set { throw new ReadOnlyCollectionException("List is read only"); }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="pointer"></param>
        /// <param name="item"></param>
        public void Insert(IList<T> pointer, T item)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        public void InsertFirst(T item)
        { throw new ReadOnlyCollectionException("List is read only"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        public void InsertLast(T item)
        { throw new ReadOnlyCollectionException("List is read only"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public void InsertBefore(T item, T target)
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="item"></param>
        /// <param name="target"></param>
        public void InsertAfter(T item, T target)
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="i"></param>
        /// <param name="items"></param>
        public void InsertAll(int i, SCG.IEnumerable<T> items)
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// Perform FindAll on the wrapped list. The result is <b>not</b> necessarily read-only.
        /// </summary>
        /// <param name="filter">The filter to use</param>
        /// <returns></returns>
        public IList<T> FindAll(Func<T, bool> filter) { return UnderlyingList.FindAll(filter); }


        /// <summary>
        /// Perform Map on the wrapped list. The result is <b>not</b> necessarily read-only.
        /// </summary>
        /// <typeparam name="V">The type of items of the new list</typeparam>
        /// <param name="mapper">The mapper to use.</param>
        /// <returns>The mapped list</returns>
        public IList<V> Map<V>(Func<T, V> mapper) { return UnderlyingList.Map(mapper); }

        /// <summary>
        /// Perform Map on the wrapped list. The result is <b>not</b> necessarily read-only.
        /// </summary>
        /// <typeparam name="V">The type of items of the new list</typeparam>
        /// <param name="mapper">The delegate defining the map.</param>
        /// <param name="itemequalityComparer">The itemequalityComparer to use for the new list</param>
        /// <returns>The new list.</returns>
        public IList<V> Map<V>(Func<T, V> mapper, SCG.IEqualityComparer<V> itemequalityComparer) { return UnderlyingList.Map(mapper, itemequalityComparer); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public T Remove() { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public T RemoveFirst() { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public T RemoveLast() { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// Create the indicated view on the wrapped list and wrap it read-only.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IList<T> View(int start, int count)
        {
            IList<T> view = UnderlyingList.View(start, count);
            return view == null ? null : new GuardedList<T>(view, UnderlyingList_Underlying ?? this, true);
        }

        /// <summary>
        /// Create the indicated view on the wrapped list and wrap it read-only.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IList<T> ViewOf(T item)
        {
            IList<T> view = UnderlyingList.ViewOf(item);
            return view == null ? null : new GuardedList<T>(view, UnderlyingList_Underlying ?? this, true);
        }

        /// <summary>
        /// Create the indicated view on the wrapped list and wrap it read-only.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IList<T> LastViewOf(T item)
        {
            IList<T> view = UnderlyingList.LastViewOf(item);
            return view == null ? null : new GuardedList<T>(view, UnderlyingList_Underlying ?? this, true);
        }


        /// <summary>
        /// </summary>
        /// <value>The wrapped underlying list of the wrapped view </value>
        public IList<T> Underlying { get { return UnderlyingList_Underlying; } }


        /// <summary>
        /// 
        /// </summary>
        /// <value>The offset of the wrapped list as a view.</value>
        public int Offset { get { return UnderlyingList.Offset; } }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public virtual bool IsValid { get { return UnderlyingList.IsValid; } }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> if this is a wrapped view and not a view that was made on a wrapper</exception>
        /// <param name="offset"></param>
        public IList<T> Slide(int offset)
        {
            if (IsSlidableView)
            {
                UnderlyingList.Slide(offset);
                return this;
            }
            else
                throw new ReadOnlyCollectionException("List is read only");
        }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public IList<T> Slide(int offset, int size)
        {
            if (IsSlidableView)
            {
                UnderlyingList.Slide(offset, size);
                return this;
            }
            else
                throw new ReadOnlyCollectionException("List is read only");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="offset"></param>
        /// <returns></returns>
        public bool TrySlide(int offset)
        {
            if (IsSlidableView)
                return UnderlyingList.TrySlide(offset);
            else
                throw new ReadOnlyCollectionException("List is read only");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool TrySlide(int offset, int size)
        {
            if (IsSlidableView)
                return UnderlyingList.TrySlide(offset, size);
            else
                throw new ReadOnlyCollectionException("List is read only");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherView"></param>
        /// <returns></returns>
        public IList<T> Span(IList<T> otherView)
        {
            GuardedList<T> otherGuardedList = otherView as GuardedList<T>;
            if (otherGuardedList == null)
                throw new IncompatibleViewException();
            IList<T> span = UnderlyingList.Span(otherGuardedList.UnderlyingList);
            if (span == null)
                return null;
            return new GuardedList<T>(span, UnderlyingList_Underlying ?? otherGuardedList.UnderlyingList_Underlying ?? this, true);
        }

        /// <summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// </summary>
        public void Reverse() { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="start"></param>
        /// <param name="count"></param>
        public void Reverse(int start, int count)
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// Check if wrapped list is sorted according to the default sorting order
        /// for the item type T, as defined by the <see cref="T:C5.Comparer`1"/> class 
        /// </summary>
        /// <exception cref="NotComparableException">if T is not comparable</exception>
        /// <returns>True if the list is sorted, else false.</returns>
        public bool IsSorted() { return UnderlyingList.IsSorted(Comparer<T>.Default); }

        /// <summary>
        /// Check if wrapped list is sorted
        /// </summary>
        /// <param name="c">The sorting order to use</param>
        /// <returns>True if sorted</returns>
        public bool IsSorted(SCG.IComparer<T> c) { return UnderlyingList.IsSorted(c); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        public void Sort()
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="c"></param>
        public void Sort(SCG.IComparer<T> c)
        { throw new ReadOnlyCollectionException("List is read only"); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        public void Shuffle()
        { throw new ReadOnlyCollectionException("List is read only"); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="rnd"></param>
        public void Shuffle(Random rnd)
        { throw new ReadOnlyCollectionException("List is read only"); }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        { return Backwards(); }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Ignore: this may be called by a foreach or using statement.
        /// </summary>
        public void Dispose() { }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedList<T>((IList<T>)(UnderlyingList.Clone()));
        }

        #endregion

        #region System.Collections.Generic.IList<T> Members

        void System.Collections.Generic.IList<T>.RemoveAt(int index)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        void System.Collections.Generic.ICollection<T>.Add(T item)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        #endregion

        #region System.Collections.ICollection Members

        bool System.Collections.ICollection.IsSynchronized
        {
            get { return false; }
        }

        [Obsolete]
        Object System.Collections.ICollection.SyncRoot
        {
            get { return UnderlyingList.SyncRoot; }
        }

        void System.Collections.ICollection.CopyTo(Array arr, int index)
        {
            if (index < 0 || index + Count > arr.Length)
                throw new ArgumentOutOfRangeException();

            foreach (T item in this)
                arr.SetValue(item, index++);
        }

        #endregion

        #region System.Collections.IList Members

        Object System.Collections.IList.this[int index]
        {
            get { return this[index]; }
            set
            {
                throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
            }
        }

        int System.Collections.IList.Add(Object o)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        bool System.Collections.IList.Contains(Object o)
        {
            return Contains((T)o);
        }

        int System.Collections.IList.IndexOf(Object o)
        {
            return Math.Max(-1, IndexOf((T)o));
        }

        void System.Collections.IList.Insert(int index, Object o)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        void System.Collections.IList.Remove(Object o)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            throw new ReadOnlyCollectionException("Collection cannot be modified through this guard object");
        }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for a generic indexable queue (allows indexing).
    /// 
    /// <para>Suitable for wrapping a <see cref="T:C5.CircularQueue`1"/></para>
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    public class GuardedQueue<T> : GuardedDirectedCollectionValue<T>, IQueue<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IQueue`1"/> guarded by this wrapper
        /// </summary>
        protected IQueue<T> UnderlyingQueue
        {
            get { return (IQueue<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a queue in a read-only wrapper
        /// </summary>
        /// <param name="queue">The queue</param>
        public GuardedQueue(IQueue<T> queue) : base(queue) { }

        #endregion

        #region IQueue<T> Members
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool AllowsDuplicates { get { return UnderlyingQueue.AllowsDuplicates; } }

        /// <summary>
        /// Index into the wrapped queue
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T this[int i] { get { return UnderlyingQueue[i]; } }

        /// <summary>
        /// Gets the the item from the front of the queue without dequeueing it.
        /// </summary>
        /// <returns>The next item to be dequeued.</returns>
        public T PeekQueue()
        {
            return this[0];
        }

        /// <summary>
        /// Get the <paramref name="i"/>'th element of the queue.
        /// </summary>
        /// <param name="i">Index from the front of the queue. The front of the queue has index 0.</param>
        /// <returns>The <paramref name="i"/>'th item from the front of the queue.</returns>
        public T PeekQueue(int i)
        {
            return this[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns>-</returns>
        public void Enqueue(T item)
        { throw new ReadOnlyCollectionException("Queue cannot be modified through this guard object"); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns>-</returns>
        public T Dequeue()
        { throw new ReadOnlyCollectionException("Queue cannot be modified through this guard object"); }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for a generic indexable stack (allows indexing).
    /// 
    /// <para>Suitable for wrapping a <see cref="T:C5.CircularQueue`1"/></para>
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    public class GuardedStack<T> : GuardedDirectedCollectionValue<T>, IStack<T>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IStack`1"/> guarded by this wrapper
        /// </summary>
        protected IStack<T> UnderlyingStack
        {
            get { return (IStack<T>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a stack in a read-only wrapper
        /// </summary>
        /// <param name="stack">The stack</param>
        public GuardedStack(IStack<T> stack) : base(stack) { }

        #endregion

        #region IStack<T> Members
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool AllowsDuplicates { get { return UnderlyingStack.AllowsDuplicates; } }

        /// <summary>
        /// Index into the wrapped stack
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T this[int i] { get { return UnderlyingStack[i]; } }

        /// <summary>
        /// Gets the the item from the top of the stack without popping it.
        /// </summary>
        /// <returns>The next item to be popped from the stack.</returns>
        public T Peek()
        {
            return this[Count - 1];
        }

        /// <summary>
        /// Get the <paramref name="i"/>'th element of from the top of the stack.
        /// </summary>
        /// <param name="i">Index from the top of the stack. The top of the stack has index 0.</param>
        /// <returns>The <paramref name="i"/>'th item from the top of the stack.</returns>
        public T Peek(int i)
        {
            return this[Count - 1 - i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns>-</returns>
        public void Push(T item)
        { throw new ReadOnlyCollectionException("Stack cannot be modified through this guard object"); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns>-</returns>
        public T Pop()
        { throw new ReadOnlyCollectionException("Stack cannot be modified through this guard object"); }

        #endregion
    }

    /// <summary>
    /// A read-only wrapper for a dictionary.
    ///
    /// <i>Suitable for wrapping a HashDictionary. <see cref="T:C5.HashDictionary`2"/></i>
    /// </summary>
    public class GuardedDictionary<K, V> : GuardedCollectionValue<KeyValuePair<K, V>>, IDictionary<K, V>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.IDictionary`2"/> guarded by this wrapper
        /// </summary>
        protected IDictionary<K, V> UnderlyingDictionary
        {
            get { return (IDictionary<K, V>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a dictionary in a read-only wrapper
        /// </summary>
        /// <param name="dict">the dictionary</param>
        public GuardedDictionary(IDictionary<K, V> dict) : base(dict) { }

        #endregion

        #region IDictionary<K,V> Members

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public SCG.IEqualityComparer<K> EqualityComparer { get { return UnderlyingDictionary.EqualityComparer; } }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a
        /// read-only wrappper if used as a setter</exception>
        /// <value>Get the value corresponding to a key in the wrapped dictionary</value>
        public V this[K key]
        {
            get { return UnderlyingDictionary[key]; }
            set { throw new ReadOnlyCollectionException(); }
        }

        /// <summary>
        /// (This is a read-only wrapper)
        /// </summary>
        /// <value>True</value>
        public bool IsReadOnly { get { return true; } }


        //TODO: guard with a read-only wrapper? Probably so!
        /// <summary> </summary>
        /// <value>The collection of keys of the wrapped dictionary</value>
        public ICollectionValue<K> Keys
        { get { return UnderlyingDictionary.Keys; } }


        /// <summary> </summary>
        /// <value>The collection of values of the wrapped dictionary</value>
        public ICollectionValue<V> Values { get { return UnderlyingDictionary.Values; } }

        /// <summary>
        /// 
        /// </summary>
        public virtual Func<K, V> Func { get { return delegate(K k) { return this[k]; }; } }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Add(K key, V val)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public void AddAll<L, W>(SCG.IEnumerable<KeyValuePair<L, W>> items)
            where L : K
            where W : V
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(K key)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Remove(K key, out V val)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        public void Clear()
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Speed ContainsSpeed { get { return UnderlyingDictionary.ContainsSpeed; } }

        /// <summary>
        /// Check if the wrapped dictionary contains a specific key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True if it does</returns>
        public bool Contains(K key) { return UnderlyingDictionary.Contains(key); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool ContainsAll<H>(SCG.IEnumerable<H> keys) where H : K { return UnderlyingDictionary.ContainsAll(keys); }

        /// <summary>
        /// Search for a key in the wrapped dictionary, reporting the value if found
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">On exit: the value if found</param>
        /// <returns>True if found</returns>
        public bool Find(K key, out V val) { return UnderlyingDictionary.Find(key, out val); }

        /// <summary>
        /// Search for a key in the wrapped dictionary, reporting the value if found
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">On exit: the value if found</param>
        /// <returns>True if found</returns>
        public bool Find(ref K key, out V val) { return UnderlyingDictionary.Find(ref key, out val); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Update(K key, V val)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="oldval"></param>
        /// <returns></returns>
        public bool Update(K key, V val, out V oldval)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool FindOrAdd(K key, ref V val)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool UpdateOrAdd(K key, V val)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="oldval"></param>
        /// <returns></returns>
        public bool UpdateOrAdd(K key, V val, out V oldval)
        { throw new ReadOnlyCollectionException(); }


        /// <summary>
        /// Check the internal consistency of the wrapped dictionary
        /// </summary>
        /// <returns>True if check passed</returns>
        public bool Check() { return UnderlyingDictionary.Check(); }

        #endregion

        #region IClonable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return new GuardedDictionary<K, V>((IDictionary<K, V>)(UnderlyingDictionary.Clone()));
        }

        #endregion
    }



    /// <summary>
    /// A read-only wrapper for a sorted dictionary.
    ///
    /// <i>Suitable for wrapping a TreeDictionary. <see cref="T:C5.TreeDictionary`2"/></i>
    /// </summary>
    public class GuardedSortedDictionary<K, V> : GuardedDictionary<K, V>, ISortedDictionary<K, V>
    {
        #region Properties

        /// <summary>
        /// The <see cref="T:C5.ISortedDictionary`2"/> guarded by this wrapper
        /// </summary>
        protected ISortedDictionary<K, V> UnderlyingSortedDictionary
        {
            get { return (ISortedDictionary<K, V>)UnderlyingEnumerable; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Wrap a sorted dictionary in a read-only wrapper
        /// </summary>
        /// <param name="sorteddict">the dictionary</param>
        public GuardedSortedDictionary(ISortedDictionary<K, V> sorteddict)
            : base(sorteddict)
        { }

        #endregion

        #region ISortedDictionary<K,V> Members

        /// <summary>
        /// The key comparer used by this dictionary.
        /// </summary>
        /// <value></value>
        public SCG.IComparer<K> Comparer { get { return UnderlyingSortedDictionary.Comparer; } }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public new ISorted<K> Keys { get { return null; } }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a predecessor</returns>
        public bool TryPredecessor(K key, out KeyValuePair<K, V> res)
        {
            return UnderlyingSortedDictionary.TryPredecessor(key, out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The successor, if any</param>
        /// <returns>True if the key has a successor</returns>
        public bool TrySuccessor(K key, out KeyValuePair<K, V> res)
        {
            return UnderlyingSortedDictionary.TrySuccessor(key, out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak predecessor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The predecessor, if any</param>
        /// <returns>True if key has a weak predecessor</returns>
        public bool TryWeakPredecessor(K key, out KeyValuePair<K, V> res)
        {
            return UnderlyingSortedDictionary.TryWeakPredecessor(key, out res);
        }

        /// <summary>
        /// Find the entry in the dictionary whose key is the
        /// weak successor of the specified key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="res">The weak successor, if any</param>
        /// <returns>True if the key has a weak successor</returns>
        public bool TryWeakSuccessor(K key, out KeyValuePair<K, V> res)
        {
            return UnderlyingSortedDictionary.TryWeakSuccessor(key, out res);
        }

        /// <summary>
        /// Get the entry in the wrapped dictionary whose key is the
        /// predecessor of a specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such entry exists </exception>    
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> Predecessor(K key)
        { return UnderlyingSortedDictionary.Predecessor(key); }

        /// <summary>
        /// Get the entry in the wrapped dictionary whose key is the
        /// successor of a specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such entry exists </exception>    
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> Successor(K key)
        { return UnderlyingSortedDictionary.Successor(key); }


        /// <summary>
        /// Get the entry in the wrapped dictionary whose key is the
        /// weak predecessor of a specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such entry exists </exception>    
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> WeakPredecessor(K key)
        { return UnderlyingSortedDictionary.WeakPredecessor(key); }


        /// <summary>
        /// Get the entry in the wrapped dictionary whose key is the
        /// weak successor of a specified key.
        /// </summary>
        /// <exception cref="NoSuchItemException"> if no such entry exists </exception>    
        /// <param name="key">The key</param>
        /// <returns>The entry</returns>
        public KeyValuePair<K, V> WeakSuccessor(K key)
        { return UnderlyingSortedDictionary.WeakSuccessor(key); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> FindMin()
        {
            return UnderlyingSortedDictionary.FindMin();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public KeyValuePair<K, V> DeleteMin()
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<K, V> FindMax()
        {
            return UnderlyingSortedDictionary.FindMax();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <returns></returns>
        public KeyValuePair<K, V> DeleteMax()
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lowEntry"></param>
        /// <param name="lowIsValid"></param>
        /// <param name="highEntry"></param>
        /// <param name="highIsValid"></param>
        /// <returns></returns>
        public bool Cut(IComparable<K> c, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid)
        {
            return UnderlyingSortedDictionary.Cut(c, out lowEntry, out lowIsValid, out highEntry, out highIsValid); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeFrom(K bot)
        {
            return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(UnderlyingSortedDictionary.RangeFrom(bot));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeFromTo(K bot, K top)
        {
            return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(UnderlyingSortedDictionary.RangeFromTo(bot, top));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public IDirectedEnumerable<KeyValuePair<K, V>> RangeTo(K top)
        {
            return new GuardedDirectedEnumerable<KeyValuePair<K, V>>(UnderlyingSortedDictionary.RangeTo(top));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDirectedCollectionValue<KeyValuePair<K, V>> RangeAll()
        {
            return new GuardedDirectedCollectionValue<KeyValuePair<K, V>>(UnderlyingSortedDictionary.RangeAll());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="items"></param>
        public void AddSorted(System.Collections.Generic.IEnumerable<KeyValuePair<K, V>> items)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="low"></param>
        public void RemoveRangeFrom(K low)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="low"></param>
        /// <param name="hi"></param>
        public void RemoveRangeFromTo(K low, K hi)
        { throw new ReadOnlyCollectionException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ReadOnlyCollectionException"> since this is a read-only wrappper</exception>
        /// <param name="hi"></param>
        public void RemoveRangeTo(K hi)
        { throw new ReadOnlyCollectionException(); }

        #endregion

        #region IClonable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new GuardedSortedDictionary<K, V>((ISortedDictionary<K, V>)(UnderlyingDictionary.Clone()));
        }

        #endregion
    }

}