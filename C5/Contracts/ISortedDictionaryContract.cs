using System;
using System.Diagnostics.Contracts;
using SCG = System.Collections.Generic;

namespace C5.Contracts
{
    [ContractClassFor(typeof(ISortedDictionary<,>))]
    internal sealed class ISortedDictionaryContract<K, V> : ISortedDictionary<K, V>
    {
        ISorted<K> ISortedDictionary<K, V>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.FindMin()
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.DeleteMin()
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.FindMax()
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.DeleteMax()
        {
            throw new NotImplementedException();
        }

        SCG.IComparer<K> ISortedDictionary<K, V>.Comparer
        {
            get { throw new NotImplementedException(); }
        }

        bool ISortedDictionary<K, V>.TryPredecessor(K key, out KeyValuePair<K, V> res)
        {
            throw new NotImplementedException();
        }

        bool ISortedDictionary<K, V>.TrySuccessor(K key, out KeyValuePair<K, V> res)
        {
            throw new NotImplementedException();
        }

        bool ISortedDictionary<K, V>.TryWeakPredecessor(K key, out KeyValuePair<K, V> res)
        {
            throw new NotImplementedException();
        }

        bool ISortedDictionary<K, V>.TryWeakSuccessor(K key, out KeyValuePair<K, V> res)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.Predecessor(K key)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.Successor(K key)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.WeakPredecessor(K key)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.WeakSuccessor(K key)
        {
            throw new NotImplementedException();
        }

        bool ISortedDictionary<K, V>.Cut(IComparable<K> cutFunction, out KeyValuePair<K, V> lowEntry, out bool lowIsValid, out KeyValuePair<K, V> highEntry, out bool highIsValid)
        {
            throw new NotImplementedException();
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeFrom(K bot)
        {
            throw new NotImplementedException();
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeFromTo(K lowerBound, K upperBound)
        {
            throw new NotImplementedException();
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeTo(K top)
        {
            throw new NotImplementedException();
        }

        IDirectedCollectionValue<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeAll()
        {
            throw new NotImplementedException();
        }

        void ISortedDictionary<K, V>.AddSorted(SCG.IEnumerable<KeyValuePair<K, V>> items)
        {
            throw new NotImplementedException();
        }

        void ISortedDictionary<K, V>.RemoveRangeFrom(K low)
        {
            throw new NotImplementedException();
        }

        void ISortedDictionary<K, V>.RemoveRangeFromTo(K low, K hi)
        {
            throw new NotImplementedException();
        }

        void ISortedDictionary<K, V>.RemoveRangeTo(K hi)
        {
            throw new NotImplementedException();
        }

        #region Interface Members not in Contract

        #region IDictionary<K,V> Members

        System.Collections.Generic.IEqualityComparer<K> IDictionary<K, V>.EqualityComparer
        {
            get { throw new NotImplementedException(); }
        }

        V IDictionary<K, V>.this[K key]
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

        bool IDictionary<K, V>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        ICollectionValue<K> IDictionary<K, V>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        ICollectionValue<V> IDictionary<K, V>.Values
        {
            get { throw new NotImplementedException(); }
        }

        Converter<K, V> IDictionary<K, V>.Fun
        {
            get { throw new NotImplementedException(); }
        }

        void IDictionary<K, V>.Add(K key, V val)
        {
            throw new NotImplementedException();
        }

        void IDictionary<K, V>.AddAll<U, W>(System.Collections.Generic.IEnumerable<KeyValuePair<U, W>> entries)
        {
            throw new NotImplementedException();
        }

        Speed IDictionary<K, V>.ContainsSpeed
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<K, V>.ContainsAll<H>(System.Collections.Generic.IEnumerable<H> items)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Remove(K key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Remove(K key, out V val)
        {
            throw new NotImplementedException();
        }

        void IDictionary<K, V>.Clear()
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Contains(K key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Find(K key, out V val)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Find(ref K key, out V val)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Update(K key, V val)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Update(K key, V val, out V oldval)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.FindOrAdd(K key, ref V val)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.UpdateOrAdd(K key, V val)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.UpdateOrAdd(K key, V val, out V oldval)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<K, V>.Check()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollectionValue<KeyValuePair<K,V>> Members

        EventTypeEnum ICollectionValue<KeyValuePair<K, V>>.ListenableEvents
        {
            get { throw new NotImplementedException(); }
        }

        EventTypeEnum ICollectionValue<KeyValuePair<K, V>>.ActiveEvents
        {
            get { throw new NotImplementedException(); }
        }

        event CollectionChangedHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.CollectionChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event CollectionClearedHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.CollectionCleared
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemsAddedHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.ItemsAdded
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemInsertedHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.ItemInserted
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemsRemovedHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.ItemsRemoved
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event ItemRemovedAtHandler<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.ItemRemovedAt
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        bool ICollectionValue<KeyValuePair<K, V>>.IsEmpty
        {
            get { throw new NotImplementedException(); }
        }

        int ICollectionValue<KeyValuePair<K, V>>.Count
        {
            get { throw new NotImplementedException(); }
        }

        Speed ICollectionValue<KeyValuePair<K, V>>.CountSpeed
        {
            get { throw new NotImplementedException(); }
        }

        void ICollectionValue<KeyValuePair<K, V>>.CopyTo(KeyValuePair<K, V>[] array, int index)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V>[] ICollectionValue<KeyValuePair<K, V>>.ToArray()
        {
            throw new NotImplementedException();
        }

        void ICollectionValue<KeyValuePair<K, V>>.Apply(Action<KeyValuePair<K, V>> action)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<KeyValuePair<K, V>>.Exists(Predicate<KeyValuePair<K, V>> predicate)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<KeyValuePair<K, V>>.Find(Predicate<KeyValuePair<K, V>> predicate, out KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        bool ICollectionValue<KeyValuePair<K, V>>.All(Predicate<KeyValuePair<K, V>> predicate)
        {
            throw new NotImplementedException();
        }

        KeyValuePair<K, V> ICollectionValue<KeyValuePair<K, V>>.Choose()
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IEnumerable<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.Filter(Predicate<KeyValuePair<K, V>> filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<K,V>> Members

        System.Collections.Generic.IEnumerator<KeyValuePair<K, V>> System.Collections.Generic.IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
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
