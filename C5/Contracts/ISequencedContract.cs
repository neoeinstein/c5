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
    [ContractClassFor(typeof(ISequenced<>))]
    internal sealed class ISequencedContract<T> : ISequenced<T>
    {
        int ISequenced<T>.GetSequencedHashCode()
        {
            return default(int);
        }

        bool ISequenced<T>.SequencedEquals(ISequenced<T> otherCollection)
        {
            ISequenced<T> @this = this;
            Contract.Ensures(otherCollection != null || Contract.Result<bool>() == false);
            Contract.Ensures(@this.Count == otherCollection.Count || Contract.Result<bool>() == false);
            Contract.Ensures(@this.GetUnsequencedHashCode() == otherCollection.GetUnsequencedHashCode() || Contract.Result<bool>() == false);
            Contract.Ensures(@this.GetSequencedHashCode() == otherCollection.GetSequencedHashCode() || Contract.Result<bool>() == false);
            Contract.Ensures(@this.UnsequencedEquals(otherCollection) || Contract.Result<bool>() == false);
            return default(bool);
        }

        #region Interface Members not in Contract

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
