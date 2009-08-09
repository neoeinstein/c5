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
            get { throw new NotImplementedException(); }
        }

        T IList<T>.Last
        {
            get { throw new NotImplementedException(); }
        }

        bool IList<T>.FIFO
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        T IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Insert(IList<T> pointer, T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.InsertFirst(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.InsertLast(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.InsertAll<U>(int index, SCG.IEnumerable<U> items)
        {
            throw new NotImplementedException();
        }

        IList<T> IList<T>.FindAll(Predicate<T> filter)
        {
            throw new NotImplementedException();
        }

        IList<V> IList<T>.Map<V>(Converter<T, V> mapper)
        {
            throw new NotImplementedException();
        }

        IList<V> IList<T>.Map<V>(Converter<T, V> mapper, SCG.IEqualityComparer<V> equalityComparer)
        {
            throw new NotImplementedException();
        }

        T IList<T>.Remove()
        {
            throw new NotImplementedException();
        }

        T IList<T>.RemoveFirst()
        {
            throw new NotImplementedException();
        }

        T IList<T>.RemoveLast()
        {
            throw new NotImplementedException();
        }

        IList<T> IList<T>.View(int start, int count)
        {
            throw new NotImplementedException();
        }

        IList<T> IList<T>.ViewOf(T item)
        {
            throw new NotImplementedException();
        }

        IList<T> IList<T>.LastViewOf(T item)
        {
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
            throw new NotImplementedException();
        }

        IList<T> IList<T>.Slide(int offset, int size)
        {
            throw new NotImplementedException();
        }

        bool IList<T>.TrySlide(int offset)
        {
            throw new NotImplementedException();
        }

        bool IList<T>.TrySlide(int offset, int size)
        {
            throw new NotImplementedException();
        }

        IList<T> IList<T>.Span(IList<T> otherView)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Reverse()
        {
            throw new NotImplementedException();
        }

        bool IList<T>.IsSorted()
        {
            throw new NotImplementedException();
        }

        bool IList<T>.IsSorted(SCG.IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Sort()
        {
            throw new NotImplementedException();
        }

        void IList<T>.Sort(SCG.IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Shuffle()
        {
            throw new NotImplementedException();
        }

        void IList<T>.Shuffle(Random rnd)
        {
            throw new NotImplementedException();
        }

        T IList<T>.this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        bool IList<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        int IList<T>.IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        int IList<T>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool IList<T>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool IList<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        void IList<T>.Clear()
        {
            throw new NotImplementedException();
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
