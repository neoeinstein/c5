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

using System.Diagnostics.Contracts;

namespace C5.Contracts
{
    [ContractClassFor(typeof(IPersistentSorted<>))]
    internal sealed class IPersistentSortedContract<T> : IPersistentSorted<T>
    {
        ISorted<T> IPersistentSorted<T>.Snapshot()
        {
            IPersistentSorted<T> @this = this;
            Contract.Ensures(@this.SequencedEquals(Contract.Result<ISorted<T>>()));
            return default(ISorted<T>);
        }

        #region Interface Members not in Contract

        #region ISorted<T> Members

        T ISorted<T>.FindMin()
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.DeleteMin()
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.FindMax()
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.DeleteMax()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.Generic.IComparer<T> ISorted<T>.Comparer
        {
            get { throw new System.NotImplementedException(); }
        }

        bool ISorted<T>.TryPredecessor(T item, out T res)
        {
            throw new System.NotImplementedException();
        }

        bool ISorted<T>.TrySuccessor(T item, out T res)
        {
            throw new System.NotImplementedException();
        }

        bool ISorted<T>.TryWeakPredecessor(T item, out T res)
        {
            throw new System.NotImplementedException();
        }

        bool ISorted<T>.TryWeakSuccessor(T item, out T res)
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.Predecessor(T item)
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.Successor(T item)
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.WeakPredecessor(T item)
        {
            throw new System.NotImplementedException();
        }

        T ISorted<T>.WeakSuccessor(T item)
        {
            throw new System.NotImplementedException();
        }

        bool ISorted<T>.Cut(System.IComparable<T> cutFunction, out T low, out bool lowIsValid, out T high, out bool highIsValid)
        {
            throw new System.NotImplementedException();
        }

        IDirectedEnumerable<T> ISorted<T>.RangeFrom(T bot)
        {
            throw new System.NotImplementedException();
        }

        IDirectedEnumerable<T> ISorted<T>.RangeFromTo(T bot, T top)
        {
            throw new System.NotImplementedException();
        }

        IDirectedEnumerable<T> ISorted<T>.RangeTo(T top)
        {
            throw new System.NotImplementedException();
        }

        IDirectedCollectionValue<T> ISorted<T>.RangeAll()
        {
            throw new System.NotImplementedException();
        }

        void ISorted<T>.AddSorted<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new System.NotImplementedException();
        }

        void ISorted<T>.RemoveRangeFrom(T low)
        {
            throw new System.NotImplementedException();
        }

        void ISorted<T>.RemoveRangeFromTo(T low, T hi)
        {
            throw new System.NotImplementedException();
        }

        void ISorted<T>.RemoveRangeTo(T hi)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ISequenced<T> Members

        int ISequenced<T>.GetSequencedHashCode()
        {
            throw new System.NotImplementedException();
        }

        bool ISequenced<T>.SequencedEquals(ISequenced<T> otherCollection)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICollection<T> Members

        Speed ICollection<T>.ContainsSpeed
        {
            get { throw new System.NotImplementedException(); }
        }

        int ICollection<T>.Count
        {
            get { throw new System.NotImplementedException(); }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        bool ICollection<T>.Add(T item)
        {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int index)
        {
            throw new System.NotImplementedException();
        }

        int ICollection<T>.GetUnsequencedHashCode()
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.UnsequencedEquals(ICollection<T> otherCollection)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        int ICollection<T>.ContainsCount(T item)
        {
            throw new System.NotImplementedException();
        }

        ICollectionValue<T> ICollection<T>.UniqueItems()
        {
            throw new System.NotImplementedException();
        }

        ICollectionValue<KeyValuePair<T, int>> ICollection<T>.ItemMultiplicities()
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.ContainsAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Find(ref T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.FindOrAdd(ref T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Update(T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Update(T item, out T olditem)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.UpdateOrAdd(T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.UpdateOrAdd(T item, out T olditem)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollection<T>.Remove(T item, out T removeditem)
        {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.RemoveAllCopies(T item)
        {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.RemoveAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new System.NotImplementedException();
        }

        void ICollection<T>.RetainAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IExtensible<T> Members

        bool IExtensible<T>.IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        bool IExtensible<T>.AllowsDuplicates
        {
            get { throw new System.NotImplementedException(); }
        }

        System.Collections.Generic.IEqualityComparer<T> IExtensible<T>.EqualityComparer
        {
            get { throw new System.NotImplementedException(); }
        }

        bool IExtensible<T>.DuplicatesByCounting
        {
            get { throw new System.NotImplementedException(); }
        }

        bool IExtensible<T>.Add(T item)
        {
            throw new System.NotImplementedException();
        }

        void IExtensible<T>.AddAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new System.NotImplementedException();
        }

        bool IExtensible<T>.Check()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICollectionValue<T> Members

        EventTypeEnum ICollectionValue<T>.ListenableEvents
        {
            get { throw new System.NotImplementedException(); }
        }

        EventTypeEnum ICollectionValue<T>.ActiveEvents
        {
            get { throw new System.NotImplementedException(); }
        }

        event CollectionChangedHandler<T> ICollectionValue<T>.CollectionChanged
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        event CollectionClearedHandler<T> ICollectionValue<T>.CollectionCleared
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        event ItemsAddedHandler<T> ICollectionValue<T>.ItemsAdded
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        event ItemInsertedHandler<T> ICollectionValue<T>.ItemInserted
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        event ItemsRemovedHandler<T> ICollectionValue<T>.ItemsRemoved
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        event ItemRemovedAtHandler<T> ICollectionValue<T>.ItemRemovedAt
        {
            add { throw new System.NotImplementedException(); }
            remove { throw new System.NotImplementedException(); }
        }

        bool ICollectionValue<T>.IsEmpty
        {
            get { throw new System.NotImplementedException(); }
        }

        int ICollectionValue<T>.Count
        {
            get { throw new System.NotImplementedException(); }
        }

        Speed ICollectionValue<T>.CountSpeed
        {
            get { throw new System.NotImplementedException(); }
        }

        void ICollectionValue<T>.CopyTo(T[] array, int index)
        {
            throw new System.NotImplementedException();
        }

        T[] ICollectionValue<T>.ToArray()
        {
            throw new System.NotImplementedException();
        }

        void ICollectionValue<T>.Apply(System.Action<T> action)
        {
            throw new System.NotImplementedException();
        }

        bool ICollectionValue<T>.Exists(System.Predicate<T> predicate)
        {
            throw new System.NotImplementedException();
        }

        bool ICollectionValue<T>.Find(System.Predicate<T> predicate, out T item)
        {
            throw new System.NotImplementedException();
        }

        bool ICollectionValue<T>.All(System.Predicate<T> predicate)
        {
            throw new System.NotImplementedException();
        }

        T ICollectionValue<T>.Choose()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.Generic.IEnumerable<T> ICollectionValue<T>.Filter(System.Predicate<T> filter)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IShowable Members

        bool IShowable.Show(System.Text.StringBuilder stringbuilder, ref int rest, System.IFormatProvider formatProvider)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IFormattable Members

        string System.IFormattable.ToString(string format, System.IFormatProvider formatProvider)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICloneable Members

        object System.ICloneable.Clone()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region ICollection<T> Members

        void System.Collections.Generic.ICollection<T>.Add(T item)
        {
            throw new System.NotImplementedException();
        }

        void System.Collections.Generic.ICollection<T>.Clear()
        {
            throw new System.NotImplementedException();
        }

        bool System.Collections.Generic.ICollection<T>.Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        int System.Collections.Generic.ICollection<T>.Count
        {
            get { throw new System.NotImplementedException(); }
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        bool System.Collections.Generic.ICollection<T>.Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDirectedCollectionValue<T> Members

        IDirectedCollectionValue<T> IDirectedCollectionValue<T>.Backwards()
        {
            throw new System.NotImplementedException();
        }

        bool IDirectedCollectionValue<T>.FindLast(System.Predicate<T> predicate, out T item)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        {
            throw new System.NotImplementedException();
        }

        EnumerationDirection IDirectedEnumerable<T>.Direction
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion

        #region IDisposable Members

        void System.IDisposable.Dispose()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #endregion
    }
}
