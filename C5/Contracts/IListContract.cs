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
    [ContractClassFor(typeof(IList<>))]
    internal sealed class IListContract<T> : IList<T>
    {
        T IList<T>.First
        {
            get
            {
                IList<T> @this = this;
                Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
                Contract.Ensures(ReferenceEquals(Contract.Result<T>(), @this[0]));
                return default(T);
            }
        }

        T IList<T>.Last
        {
            get
            {
                IList<T> @this = this;
                Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
                Contract.Ensures(ReferenceEquals(Contract.Result<T>(), @this[@this.Count - 1]));
                return default(T);
            }
        }

        bool IList<T>.FIFO
        {
            get { return default(bool); }
            set {  }
        }

        T IList<T>.RemoveAt(int index)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Requires<IndexOutOfRangeException>(0 <= index && index < @this.Count);
            throw new NotImplementedException();
        }

        void IList<T>.Insert(IList<T> pointer, T item)
        {
            IList<T> @this = this;
            Contract.Requires<ArgumentNullException>(pointer != null, "pointer");
            Contract.Requires<NotAViewException>(@this == pointer.Underlying);
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
        }

        void IList<T>.InsertFirst(T item)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(@this.EqualityComparer.Equals(@this.First, item));
        }

        void IList<T>.InsertLast(T item)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(@this.EqualityComparer.Equals(@this.Last, item));
        }

        void IList<T>.InsertAll<U>(int index, SCG.IEnumerable<U> items)
        {
            IList<T> @this = this;
            Contract.Requires<IndexOutOfRangeException>(0 <= index && index < @this.Count);
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
        }

        IList<T> IList<T>.FindAll(Predicate<T> filter)
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        IList<V> IList<T>.Map<V>(Converter<T, V> mapper)
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        IList<V> IList<T>.Map<V>(Converter<T, V> mapper, SCG.IEqualityComparer<V> equalityComparer)
        {
            throw new NotImplementedException();
        }

        T IList<T>.Remove()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            return default(T);
        }

        T IList<T>.RemoveFirst()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(@this.EqualityComparer.Equals(Contract.OldValue(@this.First), Contract.Result<T>()));
            return default(T);
        }

        T IList<T>.RemoveLast()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(@this.EqualityComparer.Equals(Contract.OldValue(@this.Last), Contract.Result<T>()));
            return default(T);
        }

        IList<T> IList<T>.View(int start, int count)
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        IList<T> IList<T>.ViewOf(T item)
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        IList<T> IList<T>.LastViewOf(T item)
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        IList<T> IList<T>.Underlying
        {
            get { throw new NotImplementedException(); }
        }

        int IList<T>.Offset
        {
            get { throw new NotImplementedException(); }
        }

        bool IList<T>.IsValid
        {
            get { throw new NotImplementedException(); }
        }

        IList<T> IList<T>.Slide(int offset)
        {
            IList<T> @this = this;
            Contract.Requires<ViewDisposedException>(!@this.IsValid);
            Contract.Requires<NotAViewException>(@this.Underlying != null);
            Contract.Requires<ArgumentOutOfRangeException>(0 <= offset + Contract.OldValue(@this.Offset), "offset");
            Contract.Requires<ArgumentOutOfRangeException>(offset + Contract.OldValue(@this.Offset) + @this.Count <= @this.Underlying.Count, "offset");
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(@this.Offset == Contract.OldValue(@this.Offset) + offset);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count));
            Contract.Ensures(ReferenceEquals(Contract.Result<IList<T>>(), @this));
            Contract.Ensures(@this.IsValid);
            return default(IList<T>);
        }

        IList<T> IList<T>.Slide(int offset, int size)
        {
            IList<T> @this = this;
            Contract.Requires<ViewDisposedException>(!@this.IsValid);
            Contract.Requires<NotAViewException>(@this.Underlying != null);
            Contract.Requires<ArgumentOutOfRangeException>(0 <= offset + Contract.OldValue(@this.Offset), "offset");
            Contract.Requires<ArgumentOutOfRangeException>(offset + Contract.OldValue(@this.Offset) <= @this.Underlying.Count, "offset");
            Contract.Requires<ArgumentOutOfRangeException>(size >= 0, "size");
            Contract.Requires<ArgumentOutOfRangeException>(offset + Contract.OldValue(@this.Offset) + size <= @this.Underlying.Count, "size");
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(@this.Offset == Contract.OldValue(@this.Offset) + offset);
            Contract.Ensures(@this.Count == size);
            Contract.Ensures(ReferenceEquals(Contract.Result<IList<T>>(), @this));
            Contract.Ensures(@this.IsValid);
            return default(IList<T>);
        }

        bool IList<T>.TrySlide(int offset)
        {
            IList<T> @this = this;
            Contract.Requires<ViewDisposedException>(!@this.IsValid);
            Contract.Requires<NotAViewException>(@this.Underlying != null);
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(
                Logical.Equivalence(
                    0 <= offset + Contract.OldValue(@this.Offset) &&
                    offset + Contract.OldValue(@this.Offset) + @this.Count <= @this.Underlying.Count,
                    Contract.Result<bool>));
            Contract.Ensures(@this.Offset == Contract.OldValue(@this.Offset) + (Contract.Result<bool>() ? offset : 0));
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count));
            Contract.Ensures(@this.IsValid);
            return default(bool);
        }

        bool IList<T>.TrySlide(int offset, int size)
        {
            IList<T> @this = this;
            Contract.Requires<ViewDisposedException>(!@this.IsValid);
            Contract.Requires<NotAViewException>(@this.Underlying != null);
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(
                Logical.Equivalence(
                    0 <= offset + Contract.OldValue(@this.Offset) &&
                    offset + Contract.OldValue(@this.Offset) + size <= @this.Underlying.Count &&
                    0 <= size,
                    Contract.Result<bool>));
            Contract.Ensures(@this.Offset == Contract.OldValue(@this.Offset) + (Contract.Result<bool>() ? offset : 0));
            Contract.Ensures(@this.Count == size);
            Contract.Ensures(@this.IsValid);
            return default(bool);
        }

        IList<T> IList<T>.Span(IList<T> otherView)
        {
            Contract.Requires<ArgumentNullException>(otherView != null, "otherView");
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            throw new NotImplementedException();
        }

        void IList<T>.Reverse()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
            Contract.Ensures(Contract.ForAll(0, @this.Count,
                i => ReferenceEquals(Contract.OldValue(@this[i]), @this[@this.Count - i - 1])));
        }

        bool IList<T>.IsSorted()
        {
            IList<T> @this = this;
            Contract.Ensures(@this.IsSorted(Comparer<T>.Default));
            return default(bool);
        }

        bool IList<T>.IsSorted(SCG.IComparer<T> comparer)
        {
            IList<T> @this = this;
            Contract.Requires<ArgumentNullException>(comparer != null, "comparer");
            Contract.Ensures(@this.IsEmpty ||
                             Contract.ForAll(1, @this.Count, i => comparer.Compare(@this[i - 1], @this[i]) <= 0));
            return default(bool);
        }

        void IList<T>.Sort()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
            Contract.Ensures(@this.IsSorted());
        }

        void IList<T>.Sort(SCG.IComparer<T> comparer)
        {
            IList<T> @this = this;
            Contract.Requires<ArgumentNullException>(comparer != null, "comparer");
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
            Contract.Ensures(@this.IsSorted(comparer));
        }

        void IList<T>.Shuffle()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
        }

        void IList<T>.Shuffle(Random rnd)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
        }

        T IList<T>.this[int index]
        {
            get
            {
                IList<T> @this = this;
                Contract.Requires<IndexOutOfRangeException>(0 <= index && index < @this.Count);
                return default(T);
            }
            set
            {
                IList<T> @this = this;
                Contract.Requires<IndexOutOfRangeException>(0 <= index && index < @this.Count);
                Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
                Contract.Ensures(Contract.OldValue(@this.Count) == @this.Count);
            }
        }

        bool IList<T>.Remove(T item)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(Logical.Implication(@this.Contains(item), Contract.Result<bool>));
            Contract.Ensures(Logical.Implication(Contract.Result<bool>(), ()=> Contract.OldValue(@this.Count) - 1 == @this.Count));
            Contract.Ensures(Logical.Implication(!Contract.Result<bool>(), ()=> Contract.OldValue(@this.Count) == @this.Count));
            return default(bool);
        }

        int IList<T>.IndexOf(T item)
        {
            IIndexed<T> @this = this;
            Contract.Ensures(~(@this.Count + 1) < Contract.Result<int>() && Contract.Result<int>() < @this.Count);
            Contract.Ensures(Logical.Equivalence(Contract.Result<int>() >= 0, () => @this.Contains(item)));
            Contract.Ensures((Contract.Result<int>() >= 0)
                                 ? Contract.Result<int>() <= @this.LastIndexOf(item)
                                 : Contract.Result<int>() == @this.LastIndexOf(item));
            Contract.Ensures(@this.EqualityComparer.Equals(@this[Contract.Result<int>()], item));
            return default(int);
        }

        int IList<T>.Count
        {
            get
            {
                IList<T> @this = this;
                Contract.Ensures(Contract.Result<int>() >= 0);
                Contract.Ensures(Logical.Equivalence(Contract.Result<int>() == 0, () => @this.IsEmpty));
                return default(int);
            }
        }

        bool IList<T>.IsReadOnly
        {
            get { return default(bool); }
        }

        bool IList<T>.Add(T item)
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            return default(bool);
        }

        void IList<T>.CopyTo(T[] array, int index)
        {
            IList<T> @this = this;
            Contract.Requires<ArgumentNullException>(array != null, "array");
            Contract.Requires<ArgumentOutOfRangeException>(index <= array.GetUpperBound(0), "index");
            Contract.Requires<ArgumentOutOfRangeException>(index >= array.GetLowerBound(0), "index");
            Contract.Requires<ArgumentException>(index + @this.Count <= array.Length, "array");
            Contract.Requires(index + @this.Count <= array.GetUpperBound(0), "Starting at index, collection will not fit in array");
        }

        void IList<T>.Clear()
        {
            IList<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<FixedSizeCollectionException>(!@this.IsFixedSize);
            Contract.Ensures(@this.IsEmpty);
        }

        bool IList<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        #region Interface Members not in Contract

        #region IIndexed<T> Members

        T IIndexed<T>.this[int index]
        {
            get { throw new NotImplementedException(); }
        }

        Speed IIndexed<T>.IndexingSpeed
        {
            get { throw new NotImplementedException(); }
        }

        IDirectedCollectionValue<T> IIndexed<T>.this[int start, int count]
        {
            get { throw new NotImplementedException(); }
        }

        int IIndexed<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        int IIndexed<T>.LastIndexOf(T item)
        {
            throw new NotImplementedException();
        }

        int IIndexed<T>.FindIndex(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        int IIndexed<T>.FindLastIndex(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        T IIndexed<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void IIndexed<T>.RemoveInterval(int start, int count)
        {
            throw new NotImplementedException();
        }

        #endregion

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

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IList<T> Members

        int System.Collections.Generic.IList<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        void System.Collections.Generic.IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        void System.Collections.Generic.IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        T System.Collections.Generic.IList<T>.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IList Members

        int System.Collections.IList.Add(object value)
        {
            throw new NotImplementedException();
        }

        void System.Collections.IList.Clear()
        {
            throw new NotImplementedException();
        }

        bool System.Collections.IList.Contains(object value)
        {
            throw new NotImplementedException();
        }

        int System.Collections.IList.IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        bool System.Collections.IList.IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        bool System.Collections.IList.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        void System.Collections.IList.Remove(object value)
        {
            throw new NotImplementedException();
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        object System.Collections.IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection Members

        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        int System.Collections.ICollection.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool System.Collections.ICollection.IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        object System.Collections.ICollection.SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #endregion
    }
}
