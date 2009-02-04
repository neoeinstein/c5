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
    /// Base class for classes implementing <see cref="ICollectionValue{T}"/>.
    /// </summary>
    [Serializable]
    public abstract class CollectionValueBase<T> : EnumerableBase<T>, ICollectionValue<T>, IShowable
    {
        #region Event handling
        private EventBlock<T> eventBlock;

        private void EnsureEventBlockNotNull()
        {
            if (eventBlock == null)
            {
                eventBlock = new EventBlock<T>();
            }
        }

        /// <summary>
        /// A flag bitmap indicating the Events that are raised by this collection.
        /// </summary>
        public virtual EventTypeEnum ListenableEvents 
        { 
            get 
            { 
                return 0; 
            } 
        }

        /// <summary>
        /// A flag bitmap of the Events currently subscribed to by this collection.
        /// </summary>
        public virtual EventTypeEnum ActiveEvents 
        { 
            get 
            { 
                return eventBlock == null ? EventTypeEnum.None : eventBlock.Events; 
            } 
        }

        private void CheckWillListen(EventTypeEnum eventType)
        {
            if ((ListenableEvents & eventType) == EventTypeEnum.None)
                throw new UnlistenableEventException();
        }

        /// <summary>
        /// The change event. Will be raised for every change operation on the collection.
        /// </summary>
        /// <exception cref="UnlistenableEventException">
        /// If this collection does not raise CollectionChanged Events.
        /// </exception>
        public virtual event CollectionChangedHandler<T> CollectionChanged
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.Changed);
                EnsureEventBlockNotNull();
                eventBlock.CollectionChanged += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.Changed);
                if (eventBlock != null)
                {
                    eventBlock.CollectionChanged -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary>
        /// Fire the CollectionChanged event
        /// </summary>
        protected virtual void RaiseCollectionChanged()
        { 
            if (eventBlock != null) 
                eventBlock.RaiseCollectionChanged(this); 
        }

        /// <summary>
        /// The clear event. Will be raised for every Clear operation on the collection.
        /// </summary>
        public virtual event CollectionClearedHandler<T> CollectionCleared
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.Cleared);
                EnsureEventBlockNotNull();
                eventBlock.CollectionCleared += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.Cleared);
                if (eventBlock != null)
                {
                    eventBlock.CollectionCleared -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary>
        /// Fire the CollectionCleared event
        /// </summary>
        protected virtual void RaiseCollectionCleared(bool full, int count)
        { 
            if (eventBlock != null) 
                eventBlock.RaiseCollectionCleared(this, full, count); 
        }

        /// <summary>
        /// Fire the CollectionCleared event
        /// </summary>
        protected virtual void RaiseCollectionCleared(bool full, int count, int? offset)
        { 
            if (eventBlock != null) 
                eventBlock.RaiseCollectionCleared(this, full, count, offset); 
        }

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        public virtual event ItemsAddedHandler<T> ItemsAdded
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.Added);
                EnsureEventBlockNotNull();
                eventBlock.ItemsAdded += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.Added);
                if (eventBlock != null)
                {
                    eventBlock.ItemsAdded -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary>
        /// Fire the ItemsAdded event
        /// </summary>
        /// <param name="item">The item that was added</param>
        /// <param name="count">The number of items added</param>
        protected virtual void RaiseItemsAdded(T item, int count)
        { 
            if (eventBlock != null)
                eventBlock.RaiseItemsAdded(this, item, count); 
        }

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        public virtual event ItemsRemovedHandler<T> ItemsRemoved
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.Removed);
                EnsureEventBlockNotNull();
                eventBlock.ItemsRemoved += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.Removed);
                if (eventBlock != null)
                {
                    eventBlock.ItemsRemoved -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary>
        /// Fire the ItemsRemoved event
        /// </summary>
        /// <param name="item">The item that was removed</param>
        /// <param name="count">The number of items removed</param>
        protected virtual void RaiseItemsRemoved(T item, int count)
        { 
            if (eventBlock != null) 
                eventBlock.RaiseItemsRemoved(this, item, count); 
        }

        /// <summary>
        /// The item added  event. Will be raised for every individual addition to the collection.
        /// </summary>
        public virtual event ItemInsertedHandler<T> ItemInserted
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.Inserted);
                EnsureEventBlockNotNull();
                eventBlock.ItemInserted += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.Inserted);
                if (eventBlock != null)
                {
                    eventBlock.ItemInserted -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary>
        /// Fire the ItemInserted event
        /// </summary>
        /// <param name="item">The item that was added</param>
        /// <param name="index"></param>
        protected virtual void RaiseItemInserted(T item, int index)
        { 
            if (eventBlock != null) 
                eventBlock.RaiseItemInserted(this, item, index); 
        }

        /// <summary>
        /// The item removed event. Will be raised for every individual removal from the collection.
        /// </summary>
        public virtual event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add 
            { 
                CheckWillListen(EventTypeEnum.RemovedAt);
                EnsureEventBlockNotNull();
                eventBlock.ItemRemovedAt += value; 
            }
            remove
            {
                CheckWillListen(EventTypeEnum.RemovedAt);
                if (eventBlock != null)
                {
                    eventBlock.ItemRemovedAt -= value;
                    if (eventBlock.Events == 0)
                        eventBlock = null;
                }
            }
        }
        /// <summary> 
        /// Fire the ItemRemovedAt event
        /// </summary>
        /// <param name="item">The item that was removed</param>
        /// <param name="index"></param>
        protected virtual void RaiseItemRemovedAt(T item, int index)
        { 
            if (eventBlock != null) 
                eventBlock.RaiseItemRemovedAt(this, item, index); 
        }

        #region Event support for IList
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="item"></param>
        protected virtual void RaiseForSetThis(int index, T value, T item)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsRemoved(item, 1);
                RaiseItemRemovedAt(item, index);
                RaiseItemsAdded(value, 1);
                RaiseItemInserted(value, index);
                RaiseCollectionChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="item"></param>
        protected virtual void RaiseForInsert(int i, T item)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemInserted(item, i);
                RaiseItemsAdded(item, 1);
                RaiseCollectionChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected void RaiseForRemove(T item)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsRemoved(item, 1);
                RaiseCollectionChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        protected void RaiseForRemove(T item, int count)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsRemoved(item, count);
                RaiseCollectionChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        protected void RaiseForRemoveAt(int index, T item)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemRemovedAt(item, index);
                RaiseItemsRemoved(item, 1);
                RaiseCollectionChanged();
            }
        }

        #endregion

        #region Event Support for ICollection
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newitem"></param>
        /// <param name="olditem"></param>
        protected virtual void RaiseForUpdate(T newitem, T olditem)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsRemoved(olditem, 1);
                RaiseItemsAdded(newitem, 1);
                RaiseCollectionChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newitem"></param>
        /// <param name="olditem"></param>
        /// <param name="count"></param>
        protected virtual void RaiseForUpdate(T newitem, T olditem, int count)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsRemoved(olditem, count);
                RaiseItemsAdded(newitem, count);
                RaiseCollectionChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void RaiseForAdd(T item)
        {
            if (ActiveEvents != 0)
            {
                RaiseItemsAdded(item, 1);
                RaiseCollectionChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wasRemoved"></param>
        protected virtual void RaiseForRemoveAll(ICollectionValue<T> wasRemoved)
        {
            if ((ActiveEvents & EventTypeEnum.Removed) != 0)
                foreach (T item in wasRemoved)
                    RaiseItemsRemoved(item, 1);
            if (wasRemoved != null && wasRemoved.Count > 0)
                RaiseCollectionChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        protected class RaiseForRemoveAllHandler
        {
            CollectionValueBase<T> collection;
            CircularQueue<T> wasRemoved;
            bool wasChanged = false;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="collection"></param>
            public RaiseForRemoveAllHandler(CollectionValueBase<T> collection)
            {
                this.collection = collection;
                mustFireRemoved = (collection.ActiveEvents & EventTypeEnum.Removed) != EventTypeEnum.None;
                MustFire = (collection.ActiveEvents & (EventTypeEnum.Removed | EventTypeEnum.Changed)) != EventTypeEnum.None;
            }

            bool mustFireRemoved;
            /// <summary>
            /// 
            /// </summary>
            public readonly bool MustFire;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public void Remove(T item)
            {
                if (mustFireRemoved)
                {
                    if (wasRemoved == null)
                        wasRemoved = new CircularQueue<T>();
                    wasRemoved.Enqueue(item);
                }
                if (!wasChanged)
                    wasChanged = true;
            }

            /// <summary>
            /// 
            /// </summary>
            public void Raise()
            {
                if (wasRemoved != null)
                    foreach (T item in wasRemoved)
                        collection.RaiseItemsRemoved(item, 1);
                if (wasChanged)
                    collection.RaiseCollectionChanged();
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Check if collection is empty.
        /// </summary>
        /// <value>True if empty</value>
        public abstract bool IsEmpty { get; }

        /// <summary>
        /// The number of items in this collection.
        /// </summary>
        /// <value></value>
        public abstract int Count { get; }

        /// <summary>
        /// The value is symbolic indicating the type of asymptotic complexity
        /// in terms of the size of this collection (worst-case or amortized as
        /// relevant).
        /// </summary>
        /// <value>A characterization of the speed of the 
        /// <code>Count</code> property in this collection.</value>
        public abstract Speed CountSpeed { get; }

        /// <summary>
        /// Copy the items of this collection to part of an array.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> if <code>index</code> 
        /// is not a valid index
        /// into the array (i.e. negative or greater than the size of the array)
        /// or the array does not have room for the items.</exception>
        /// <param name="array">The array to copy to.</param>
        /// <param name="index">The starting index.</param>
        public virtual void CopyTo(T[] array, int index)
        {
            if (index < 0 || index + Count > array.Length)
                throw new ArgumentOutOfRangeException();

            foreach (T item in this) 
                array[index++] = item;
        }

        /// <summary>
        /// Create an array with the items of this collection (in the same order as an
        /// enumerator would output them).
        /// </summary>
        /// <returns>The array</returns>
        //
        public virtual T[] ToArray()
        {
            T[] res = new T[Count];
            int i = 0;

            foreach (T item in this) 
                res[i++] = item;

            return res;
        }

        /// <summary>
        /// Apply an single argument action, <see cref="T:C5.Act`1"/> to this enumerable
        /// </summary>
        /// <param name="action">The action delegate</param>
        
        public virtual void Apply(Action<T> action)
        {
            foreach (T item in this)
                action(item);
        }


        /// <summary>
        /// Check if there exists an item in this collection that satisfies a
        /// given predicate.
        /// </summary>
        /// <seealso cref="Find(Predicate{T},out T)"/>
        /// <seealso cref="All(Predicate{T})"/>
        /// <param name="predicate">The predicate to use to test items.</param>
        /// <returns><see langword="True"/> if an item satisfying the predicate exists</returns>
        public virtual bool Exists(Predicate<T> predicate)
        {
            foreach (T item in this)
                if (predicate(item))
                    return true;

            return false;
        }

        /// <summary>
        /// Check if there exists an item in this collection that satisfies a
        /// given predicate and return the first one found in enumeration order.
        /// </summary>
        /// <seealso cref="Exists(Predicate{T})"/>
        /// <param name="predicate">The predicate to use to test items.</param>
        /// <param name="item">
        /// The first item satisfying <paramref name="predicate"/> or 
        /// <code><see langword="default"/>(<typeparamref name="T"/>)</code> otherwise.
        /// </param>
        /// <returns><see langword="True"/> if an item satisfying the predicate exists.</returns>
        public virtual bool Find(Predicate<T> predicate, out T item)
        {
            foreach (T jtem in this)
            {
                if (predicate(jtem))
                {
                    item = jtem;
                    return true;
                }
            }
            item = default(T);
            return false;
        }

        /// <summary>
        /// Check if all items in this collection satisfies a specific predicate.
        /// </summary>
        /// <seealso cref="Exists(Predicate{T})"/>
        /// <param name="predicate">The predicate to use to test items.</param>
        /// <returns><see langword="True"/> if all items satisfy the predicate.</returns>
        public virtual bool All(Predicate<T> predicate)
        {
            foreach (T item in this)
                if (!predicate(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Create an enumerable, containing all items of this collection that satisfy 
        /// a certain condition.
        /// </summary>
        /// <param name="predicate">A predicate defining the filter.</param>
        /// <returns>
        /// An enumerable containing all items for which <paramref name="predicate"/>
        /// returns <see langword="true"/>.
        /// </returns>
        public virtual SCG.IEnumerable<T> Filter(Predicate<T> predicate)
        {
            foreach (T item in this)
                if (predicate(item))
                    yield return item;
        }

        /// <summary>
        /// Choose some item of this collection. 
        /// </summary>
        /// <exception cref="NoSuchItemException">If the collection is empty.</exception>
        /// <returns></returns>
        public abstract T Choose();


        /// <summary>
        /// Create an enumerator for this collection.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public override abstract SCG.IEnumerator<T> GetEnumerator();

        #region IShowable Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringbuilder"></param>
        /// <param name="rest"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public virtual bool Show(System.Text.StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
        {
            return Showing.ShowCollectionValue<T>(this, stringbuilder, ref rest, formatProvider);
        }
        #endregion

        #region IFormattable Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return Showing.ShowString(this, format, formatProvider);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

    }
}
