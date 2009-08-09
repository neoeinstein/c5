#region License
/*
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
#endregion

using System;
using System.Diagnostics.Contracts;
using SCG = System.Collections.Generic;

namespace C5.Contracts
{
    [ContractClassFor(typeof(IPriorityQueue<>))]
    internal sealed class IPriorityQueueContract<T> : IPriorityQueue<T>
    {
        T IPriorityQueue<T>.FindMin()
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            return default(T);
        }

        T IPriorityQueue<T>.DeleteMin()
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            return default(T);
        }

        T IPriorityQueue<T>.FindMax()
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            return default(T);
        }

        T IPriorityQueue<T>.DeleteMax()
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            return default(T);
        }

        SCG.IComparer<T> IPriorityQueue<T>.Comparer
        {
            get
            {
                Contract.Ensures(Contract.Result<SCG.IComparer<T>>() != null);
                return default(SCG.IComparer<T>);
            }
        }

        T IPriorityQueue<T>.this[IPriorityQueueHandle<T> handle]
        {
            get
            {
                Contract.Requires<ArgumentNullException>(handle != null, "handle");
                return default(T);
            }
            set
            {
                IPriorityQueue<T> @this = this;
                Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
                Contract.Requires<ArgumentNullException>(handle != null, "handle");
            }
        }

        bool IPriorityQueue<T>.Find(IPriorityQueueHandle<T> handle, out T item)
        {
            Contract.Requires<ArgumentNullException>(handle != null, "handle");
            item = default(T);
            return default(bool);
        }

        bool IPriorityQueue<T>.Add(ref IPriorityQueueHandle<T> handle, T item)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<DuplicateNotAllowedException>(@this.AllowsDuplicates ||
                                                            @this.All(i => !@this.EqualityComparer.Equals(i, item)));
            Contract.Ensures(Contract.ValueAtReturn(out handle) != null);
            return default(bool);
        }

        T IPriorityQueue<T>.Delete(IPriorityQueueHandle<T> handle)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentNullException>(handle != null, "handle");
            return default(T);
        }

        T IPriorityQueue<T>.Replace(IPriorityQueueHandle<T> handle, T item)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentNullException>(handle != null, "handle");
            return default(T);
        }

        T IPriorityQueue<T>.FindMin(out IPriorityQueueHandle<T> handle)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(Contract.ValueAtReturn(out handle) != null);
            handle = default(IPriorityQueueHandle<T>);
            return default(T);
        }

        T IPriorityQueue<T>.FindMax(out IPriorityQueueHandle<T> handle)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(Contract.ValueAtReturn(out handle) != null);
            handle = default(IPriorityQueueHandle<T>);
            return default(T);
        }

        T IPriorityQueue<T>.DeleteMin(out IPriorityQueueHandle<T> handle)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(Contract.ValueAtReturn(out handle) != null);
            handle = default(IPriorityQueueHandle<T>);
            return default(T);
        }

        T IPriorityQueue<T>.DeleteMax(out IPriorityQueueHandle<T> handle)
        {
            IPriorityQueue<T> @this = this;
            Contract.Requires(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(Contract.ValueAtReturn(out handle) != null);
            handle = default(IPriorityQueueHandle<T>);
            return default(T);
        }

        #region Inherited Members not in Contract

        #region IExtensible<T> Members

        bool IExtensible<T>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool IExtensible<T>.AllowsDuplicates
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.Generic.IEqualityComparer<T> IExtensible<T>.EqualityComparer
        {
            get { throw new NotImplementedException(); }
        }

        bool IExtensible<T>.DuplicatesByCounting
        {
            get { throw new NotImplementedException(); }
        }

        bool IExtensible<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void IExtensible<T>.AddAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new NotImplementedException();
        }

        bool IExtensible<T>.Check()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollectionValue<T> Members

        EventTypeEnum ICollectionValue<T>.ListenableEvents
        {
            get { throw new NotImplementedException(); }
        }

        EventTypeEnum ICollectionValue<T>.ActiveEvents
        {
            get { throw new NotImplementedException(); }
        }

        event CollectionChangedHandler<T> ICollectionValue<T>.CollectionChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event CollectionClearedHandler<T> ICollectionValue<T>.CollectionCleared
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemsAddedHandler<T> ICollectionValue<T>.ItemsAdded
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemInsertedHandler<T> ICollectionValue<T>.ItemInserted
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemsRemovedHandler<T> ICollectionValue<T>.ItemsRemoved
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemRemovedAtHandler<T> ICollectionValue<T>.ItemRemovedAt
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        bool ICollectionValue<T>.IsEmpty
        {
            get { throw new NotImplementedException(); }
        }

        int ICollectionValue<T>.Count
        {
            get { throw new NotImplementedException(); }
        }

        Speed ICollectionValue<T>.CountSpeed
        {
            get { throw new NotImplementedException(); }
        }

        void ICollectionValue<T>.CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        T[] ICollectionValue<T>.ToArray()
        {
            throw new NotImplementedException();
        }

        void ICollectionValue<T>.Apply(Action<T> action)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<T>.Exists(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<T>.Find(Predicate<T> predicate, out T item)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<T>.All(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        T ICollectionValue<T>.Choose()
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IEnumerable<T> ICollectionValue<T>.Filter(Predicate<T> filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IShowable Members

        bool IShowable.Show(System.Text.StringBuilder stringbuilder, ref int rest, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IFormattable Members

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
