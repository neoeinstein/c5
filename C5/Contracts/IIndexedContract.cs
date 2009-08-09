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

namespace C5.Contracts
{
    [ContractClassFor(typeof(IIndexed<>))]
    internal sealed class IIndexedContract<T> : IIndexed<T>
    {
        T IIndexed<T>.this[int index]
        {
            get
            {
                IIndexed<T> @this = this;
                Contract.Requires<IndexOutOfRangeException>(index < @this.Count);
                return default(T);
            }
        }

        Speed IIndexed<T>.IndexingSpeed
        {
            get
            {
                Contract.Ensures(Enum.IsDefined(typeof(Speed), Contract.Result<Speed>()));
                return default(Speed);
            }
        }

        IDirectedCollectionValue<T> IIndexed<T>.this[int start, int count]
        {
            get
            {
                IIndexed<T> @this = this;
                Contract.Requires<ArgumentOutOfRangeException>(start < @this.Count, "start");
                Contract.Requires<ArgumentOutOfRangeException>(count >= 0, "count");
                Contract.Requires<ArgumentOutOfRangeException>(start + count < @this.Count, "count");
                Contract.Ensures(Contract.Result<IDirectedCollectionValue<T>>() != null);
                Contract.Ensures(Contract.Result<IDirectedCollectionValue<T>>().Count == count);
                return default(IDirectedCollectionValue<T>);
            }
        }

        int IIndexed<T>.IndexOf(T item)
        {
            IIndexed<T> @this = this;
            Contract.Ensures(~(@this.Count + 1) < Contract.Result<int>() && Contract.Result<int>() < @this.Count);
            Contract.Ensures((@this.Contains(item) && Contract.Result<int>() >= 0) ||
                             (!@this.Contains(item) && Contract.Result<int>() < 0));
            Contract.Ensures((Contract.Result<int>() >= 0 && Contract.Result<int>() <= @this.LastIndexOf(item)) ||
                             (Contract.Result<int>() < 0 && Contract.Result<int>() == @this.LastIndexOf(item)));
            Contract.Ensures(@this.EqualityComparer.Equals(@this[Contract.Result<int>()], item));
            return default(int);
        }

        int IIndexed<T>.LastIndexOf(T item)
        {
            IIndexed<T> @this = this;
            Contract.Ensures(~(@this.Count + 1) < Contract.Result<int>() && Contract.Result<int>() < @this.Count);
            Contract.Ensures((@this.Contains(item) && Contract.Result<int>() >= 0) ||
                             (!@this.Contains(item) && Contract.Result<int>() < 0));
            Contract.Ensures((Contract.Result<int>() >= 0 && Contract.Result<int>() >= @this.IndexOf(item)) ||
                             (Contract.Result<int>() < 0 && Contract.Result<int>() == @this.IndexOf(item)));
            Contract.Ensures(@this.EqualityComparer.Equals(@this[Contract.Result<int>()], item));
            return default(int);
        }

        int IIndexed<T>.FindIndex(Predicate<T> predicate)
        {
            IIndexed<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(-1 <= Contract.Result<int>() && Contract.Result<int>() < @this.Count);
            Contract.Ensures((@this.Exists(predicate) && Contract.Result<int>() >= 0) ||
                             (!@this.Exists(predicate) && Contract.Result<int>() == -1));
            Contract.Ensures((Contract.Result<int>() >= 0 && Contract.Result<int>() <= @this.FindLastIndex(predicate)) ||
                             (Contract.Result<int>() < 0 && Contract.Result<int>() == @this.FindLastIndex(predicate)));
            Contract.Ensures(predicate(@this[Contract.Result<int>()]));
            return default(int);
        }

        int IIndexed<T>.FindLastIndex(Predicate<T> predicate)
        {
            IIndexed<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(-1 <= Contract.Result<int>() && Contract.Result<int>() < @this.Count);
            Contract.Ensures((@this.Exists(predicate) && Contract.Result<int>() >= 0) ||
                             (!@this.Exists(predicate) && Contract.Result<int>() == -1));
            Contract.Ensures((Contract.Result<int>() >= 0 && Contract.Result<int>() >= @this.FindIndex(predicate)) ||
                             (Contract.Result<int>() < 0 && Contract.Result<int>() == @this.FindIndex(predicate)));
            Contract.Ensures(predicate(@this[Contract.Result<int>()]));
            return default(int);
        }

        T IIndexed<T>.RemoveAt(int index)
        {
            IIndexed<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<IndexOutOfRangeException>(index < @this.Count);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count) - 1);
            Contract.Ensures(@this.EqualityComparer.Equals(Contract.Result<T>(), Contract.OldValue(@this[index])));
            return default(T);
        }

        void IIndexed<T>.RemoveInterval(int start, int count)
        {
            IIndexed<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentOutOfRangeException>(start < @this.Count, "start");
            Contract.Requires<ArgumentOutOfRangeException>(count >= 0, "count");
            Contract.Requires<ArgumentOutOfRangeException>(start + count < @this.Count, "count");
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count) - count);
        }

        #region Interface Members not in Contract

        #region ISequenced<T> Members

        int ISequenced<T>.GetSequencedHashCode()
        {
            throw new NotImplementedException();
        }

        bool ISequenced<T>.SequencedEquals(ISequenced<T> otherCollection)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollection<T> Members

        Speed ICollection<T>.ContainsSpeed
        {
            get { throw new NotImplementedException(); }
        }

        int ICollection<T>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        int ICollection<T>.GetUnsequencedHashCode()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.UnsequencedEquals(ICollection<T> otherCollection)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        int ICollection<T>.ContainsCount(T item)
        {
            throw new NotImplementedException();
        }

        ICollectionValue<T> ICollection<T>.UniqueItems()
        {
            throw new NotImplementedException();
        }

        ICollectionValue<KeyValuePair<T, int>> ICollection<T>.ItemMultiplicities()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.ContainsAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Find(ref T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.FindOrAdd(ref T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Update(T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Update(T item, out T olditem)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.UpdateOrAdd(T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.UpdateOrAdd(T item, out T olditem)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item, out T removeditem)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.RemoveAllCopies(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.RemoveAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.RetainAll<U>(System.Collections.Generic.IEnumerable<U> items)
        {
            throw new NotImplementedException();
        }

        #endregion

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

        #region ICollection<T> Members

        void System.Collections.Generic.ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void System.Collections.Generic.ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool System.Collections.Generic.ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void System.Collections.Generic.ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int System.Collections.Generic.ICollection<T>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool System.Collections.Generic.ICollection<T>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool System.Collections.Generic.ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDirectedCollectionValue<T> Members

        IDirectedCollectionValue<T> IDirectedCollectionValue<T>.Backwards()
        {
            throw new NotImplementedException();
        }

        bool IDirectedCollectionValue<T>.FindLast(Predicate<T> predicate, out T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDirectedEnumerable<T> Members

        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        {
            throw new NotImplementedException();
        }

        EnumerationDirection IDirectedEnumerable<T>.Direction
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #endregion
    }
}
