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
    [ContractClassFor(typeof(ICollection<>))]
    internal sealed class ICollectionContract<T> : ICollection<T>
    {
        Speed ICollection<T>.ContainsSpeed
        {
            get
            {
                Contract.Ensures(Enum.IsDefined(typeof(Speed), Contract.Result<Speed>()));
                return default(Speed);
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures((Contract.Result<bool>() == true &&
                              @this.ContainsCount(item) == Contract.OldValue(@this.ContainsCount(item)) - 1) ||
                             (Contract.Result<bool>() == false &&
                              Contract.OldValue(!@this.Contains(item)) &&
                              @this.Contains(item)));
            return default(bool);
        }

        bool ICollection<T>.Remove(T item, out T removeditem)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures((Contract.Result<bool>() == true &&
                              @this.ContainsCount(item) == Contract.OldValue(@this.ContainsCount(item)) - 1) ||
                             (Contract.Result<bool>() == false &&
                              Contract.OldValue(!@this.Contains(item)) &&
                              @this.Contains(item)));
            Contract.Ensures((Contract.Result<bool>() == true &&
                              @this.EqualityComparer.Equals(item, Contract.ValueAtReturn(out removeditem))) ||
                             (Contract.Result<bool>() == false &&
                              Contract.ValueAtReturn(out removeditem) == null));
            removeditem = default(T);
            return default(bool);
        }

        void ICollection<T>.RemoveAllCopies(T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(!@this.Contains(item));
        }

        void ICollection<T>.RemoveAll<U>(SCG.IEnumerable<U> items)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentNullException>(items != null, "items");
            Contract.Ensures(@this.DuplicatesByCounting || Contract.ForAll(items, i => !@this.Contains(i)));
            Contract.Ensures(Contract.ForAll(items, i => Contract.OldValue(@this.ContainsCount(i)) >= @this.ContainsCount(i)));
        }

        void ICollection<T>.Clear()
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(@this.IsEmpty);
        }

        void ICollection<T>.RetainAll<U>(SCG.IEnumerable<U> items)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentNullException>(items != null, "items");
            Contract.Ensures(@this.DuplicatesByCounting || Contract.ForAll(items, i => Contract.OldValue(@this.Contains(i)) == @this.Contains(i)));
            Contract.Ensures(Contract.Exists(items, i => @this.Contains(i)) || @this.IsEmpty);
        }

        int ICollection<T>.Count
        {
            get
            {
                ICollection<T> @this = this;
                Contract.Ensures((Contract.Result<int>() == 0 && @this.IsEmpty) || !@this.IsEmpty);
                return default(int);
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return default(bool); }
        }

        bool ICollection<T>.Add(T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<DuplicateNotAllowedException>(@this.AllowsDuplicates || !@this.Contains(item));
            Contract.Ensures(@this.Contains(item));
            Contract.Ensures(Contract.OldValue(@this.ContainsCount(item)) >= @this.ContainsCount(item));
            Contract.Ensures(
                (Contract.Result<bool>() == true && @this.Count == Contract.OldValue(@this.Count) + 1) ||
                (Contract.Result<bool>() == false && @this.Count == Contract.OldValue(@this.Count)));
            Contract.EnsuresOnThrow<DuplicateNotAllowedException>(@this.Count == Contract.OldValue(@this.Count));
            Contract.EnsuresOnThrow<DuplicateNotAllowedException>(@this.ContainsCount(item) == Contract.OldValue(@this.ContainsCount(item)));
            return default(bool);
        }

        bool ICollection<T>.Contains(T item)
        {
            ICollection<T> @this = this;
            Contract.Ensures((Contract.Result<bool>() == true && @this.ContainsCount(item) > 0) ||
                             (Contract.Result<bool>() == false && @this.ContainsCount(item) == 0));
            return default(bool);
        }

        int ICollection<T>.ContainsCount(T item)
        {
            ICollection<T> @this = this;
            Contract.Ensures((Contract.Result<int>() == 0 && !@this.Contains(item)) ||
                             (Contract.Result<int>() > 0 && @this.Contains(item)));
            return default(int);
        }

        ICollectionValue<T> ICollection<T>.UniqueItems()
        {
            return default(ICollectionValue<T>);
        }

        ICollectionValue<KeyValuePair<T, int>> ICollection<T>.ItemMultiplicities()
        {
            ICollection<T> @this = this;
            Contract.Ensures(Contract.Result<ICollectionValue<KeyValuePair<T, int>>>().All(kvp => kvp.Value > 0));
            Contract.Ensures(Contract.Result<ICollectionValue<KeyValuePair<T, int>>>().All(kvp => kvp.Value == @this.ContainsCount(kvp.Key)));
            Contract.Ensures(@this.AllowsDuplicates || Contract.Result<ICollectionValue<KeyValuePair<T, int>>>().All(kvp => kvp.Value == 1));
            return default(ICollectionValue<KeyValuePair<T, int>>);
        }

        bool ICollection<T>.ContainsAll<U>(SCG.IEnumerable<U> items)
        {
            Contract.Requires<ArgumentNullException>(items != null, "items");
            return default(bool);
        }

        bool ICollection<T>.Find(ref T item)
        {
            ICollection<T> @this = this;
            Contract.Ensures((Contract.Result<bool>() == true && @this.Contains(item)) ||
                             (Contract.Result<bool>() == false && !@this.Contains(item)));
            Contract.Ensures(@this.Contains(item) || (ReferenceEquals(item, Contract.ValueAtReturn(out item))));
            return default(bool);
        }

        bool ICollection<T>.FindOrAdd(ref T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures((Contract.Result<bool>() == true && Contract.OldValue(@this.Contains(item))) ||
                             (Contract.Result<bool>() == false && Contract.OldValue(!@this.Contains(item))));
            Contract.Ensures((Contract.Result<bool>() == true && @this.Count == Contract.OldValue(@this.Count)) ||
                             (Contract.Result<bool>() == false && @this.Count == Contract.OldValue(@this.Count) + 1));
            Contract.Ensures(@this.Contains(item));
            return default(bool);
        }

        bool ICollection<T>.Update(T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count));
            return default(bool);
        }

        bool ICollection<T>.Update(T item, out T olditem)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count));
            olditem = default(T);
            return default(bool);
        }

        bool ICollection<T>.UpdateOrAdd(T item)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures((Contract.Result<bool>() == true && @this.Count == Contract.OldValue(@this.Count)) ||
                             (Contract.Result<bool>() == false && @this.Count == Contract.OldValue(@this.Count) + 1));
            Contract.Ensures(@this.Contains(item));
            return default(bool);
        }

        bool ICollection<T>.UpdateOrAdd(T item, out T olditem)
        {
            ICollection<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures((Contract.Result<bool>() == true && @this.Count == Contract.OldValue(@this.Count)) ||
                             (Contract.Result<bool>() == false && @this.Count == Contract.OldValue(@this.Count) + 1));
            Contract.Ensures(@this.Contains(item));
            olditem = default(T);
            return default(bool);
        }

        void ICollection<T>.CopyTo(T[] array, int index)
        {
            ICollection<T> @this = this;
            Contract.Requires<ArgumentNullException>(array != null, "array");
            Contract.Requires<ArgumentOutOfRangeException>(index <= array.GetUpperBound(0), "index");
            Contract.Requires<ArgumentOutOfRangeException>(index >= array.GetLowerBound(0), "index");
            Contract.Requires<ArgumentException>(index + @this.Count <= array.Length, "array");
            Contract.Requires(index + @this.Count <= array.GetUpperBound(0), "Starting at index, collection will not fit in array");
            Contract.Ensures(Contract.ForAll(index, index + @this.Count, i => @this.Contains(array[i])));
        }

        int ICollection<T>.GetUnsequencedHashCode()
        {
            return default(int);
        }

        bool ICollection<T>.UnsequencedEquals(ICollection<T> otherCollection)
        {
            ICollection<T> @this = this;
            Contract.Ensures(otherCollection != null || Contract.Result<bool>() == false);
            Contract.Ensures(@this.Count == otherCollection.Count || Contract.Result<bool>() == false);
            Contract.Ensures(@this.GetUnsequencedHashCode() == otherCollection.GetUnsequencedHashCode() || Contract.Result<bool>() == false);
            Contract.Ensures(Contract.Result<bool>() == false ||
                             (@this.ContainsAll(otherCollection) && otherCollection.ContainsAll(@this)));
            return default(bool);
        }

        #region Interface Members not in Contract

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

        #endregion
    }
}
