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
    [ContractClassFor(typeof(ISortedDictionary<,>))]
    internal sealed class ISortedDictionaryContract<K, V> : ISortedDictionary<K, V>
    {
        ISorted<K> ISortedDictionary<K, V>.Keys
        {
            get
            {
                ISortedDictionary<K, V> @this = this;
                Contract.Ensures(Contract.Result<ISorted<K>>() != null);
                Contract.Ensures(Contract.Result<ISorted<K>>().Count == @this.Count);
                return default(ISorted<K>);
            }
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.FindMin()
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(@this.All(kvp => @this.Comparer.Compare(Contract.Result<KeyValuePair<K, V>>().Key, kvp.Key) <= 0));
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.DeleteMin()
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count) - 1);
            Contract.Ensures(@this.All(kvp => @this.Comparer.Compare(Contract.Result<KeyValuePair<K, V>>().Key, kvp.Key) <= 0));
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.FindMax()
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(@this.All(kvp => @this.Comparer.Compare(kvp.Key, Contract.Result<KeyValuePair<K, V>>().Key) <= 0));
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.DeleteMax()
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            Contract.Ensures(@this.Count == Contract.OldValue(@this.Count) - 1);
            Contract.Ensures(@this.All(kvp => @this.Comparer.Compare(kvp.Key, Contract.Result<KeyValuePair<K, V>>().Key) <= 0));
            return default(KeyValuePair<K, V>);
        }

        SCG.IComparer<K> ISortedDictionary<K, V>.Comparer
        {
            get
            {
                Contract.Ensures(Contract.Result<SCG.IComparer<K>>() != null);
                return default(SCG.IComparer<K>);
            }
        }

        bool ISortedDictionary<K, V>.TryPredecessor(K item, out KeyValuePair<K, V> res)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures((@this.Comparer.Compare(item, @this.FindMin().Key) <= 0 && Contract.Result<bool>() == false) ||
                             (@this.Comparer.Compare(item, @this.FindMin().Key) > 0 && Contract.Result<bool>() == true));
            Contract.Ensures(@this.Comparer.Compare(item, @this.FindMin().Key) <= 0 || Equals(Contract.ValueAtReturn(out res), default(K)));
            res = default(KeyValuePair<K, V>);
            return default(bool);
        }

        bool ISortedDictionary<K, V>.TrySuccessor(K item, out KeyValuePair<K, V> res)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures((@this.Comparer.Compare(@this.FindMax().Key, item) <= 0 && Contract.Result<bool>() == false) ||
                             (@this.Comparer.Compare(@this.FindMax().Key, item) > 0 && Contract.Result<bool>() == true));
            Contract.Ensures(@this.Comparer.Compare(@this.FindMax().Key, item) <= 0 || Equals(Contract.ValueAtReturn(out res), default(K)));
            res = default(KeyValuePair<K, V>);
            return default(bool);
        }

        bool ISortedDictionary<K, V>.TryWeakPredecessor(K item, out KeyValuePair<K, V> res)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures((@this.Comparer.Compare(item, @this.FindMin().Key) < 0 && Contract.Result<bool>() == false) ||
                             (@this.Comparer.Compare(item, @this.FindMin().Key) >= 0 && Contract.Result<bool>() == true));
            Contract.Ensures(@this.Comparer.Compare(item, @this.FindMin().Key) < 0 || Equals(Contract.ValueAtReturn(out res), default(K)));
            res = default(KeyValuePair<K, V>);
            return default(bool);
        }

        bool ISortedDictionary<K, V>.TryWeakSuccessor(K item, out KeyValuePair<K, V> res)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures((@this.Comparer.Compare(@this.FindMax().Key, item) < 0 && Contract.Result<bool>() == false) ||
                             (@this.Comparer.Compare(@this.FindMax().Key, item) >= 0 && Contract.Result<bool>() == true));
            Contract.Ensures(@this.Comparer.Compare(@this.FindMax().Key, item) < 0 || Equals(Contract.ValueAtReturn(out res), default(K)));
            res = default(KeyValuePair<K, V>);
            return default(bool);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.Predecessor(K item)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(@this.Comparer.Compare(item, @this.FindMin().Key) > 0);
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.Successor(K item)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(@this.Comparer.Compare(@this.FindMax().Key, item) > 0);
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.WeakPredecessor(K item)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(@this.Comparer.Compare(item, @this.FindMin().Key) >= 0);
            return default(KeyValuePair<K, V>);
        }

        KeyValuePair<K, V> ISortedDictionary<K, V>.WeakSuccessor(K item)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<NoSuchItemException>(@this.Comparer.Compare(@this.FindMax().Key, item) >= 0);
            return default(KeyValuePair<K, V>);
        }

        bool ISortedDictionary<K, V>.Cut(IComparable<K> cutFunction, out KeyValuePair<K, V> low, out bool lowIsValid, out KeyValuePair<K, V> high, out bool highIsValid)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ArgumentNullException>(cutFunction != null, "cutFunction");
            Contract.Ensures((@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) == 0) && Contract.Result<bool>() == true) ||
                             (!@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) == 0) && Contract.Result<bool>() == false));
            Contract.Ensures((@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) < 0) && Contract.ValueAtReturn(out lowIsValid) == true) ||
                             (!@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) < 0) && Contract.ValueAtReturn(out lowIsValid) == false));
            Contract.Ensures(@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) < 0) || Equals(Contract.ValueAtReturn(out low), default(K)));
            Contract.Ensures((@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) > 0) && Contract.ValueAtReturn(out highIsValid) == true) ||
                             (!@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) > 0) && Contract.ValueAtReturn(out highIsValid) == false));
            Contract.Ensures(@this.Exists(kvp => cutFunction.CompareTo(kvp.Key) > 0) || Equals(Contract.ValueAtReturn(out high), default(K)));
            low = high = default(KeyValuePair<K, V>);
            lowIsValid = highIsValid = default(bool);
            return default(bool);
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeFrom(K bot)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>() != null);
            Contract.Ensures(Contract.ForAll(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>(), kvp => @this.Comparer.Compare(bot, kvp.Key) <= 0));
            return default(IDirectedEnumerable<KeyValuePair<K, V>>);
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeFromTo(K bot, K top)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>() != null);
            Contract.Ensures(Contract.ForAll(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>(), kvp => @this.Comparer.Compare(bot, kvp.Key) <= 0));
            Contract.Ensures(Contract.ForAll(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>(), kvp => @this.Comparer.Compare(kvp.Key, top) < 0));
            return default(IDirectedEnumerable<KeyValuePair<K, V>>);
        }

        IDirectedEnumerable<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeTo(K top)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>() != null);
            Contract.Ensures(Contract.ForAll(Contract.Result<IDirectedEnumerable<KeyValuePair<K, V>>>(), kvp => @this.Comparer.Compare(kvp.Key, top) < 0));
            return default(IDirectedEnumerable<KeyValuePair<K, V>>);
        }

        IDirectedCollectionValue<KeyValuePair<K, V>> ISortedDictionary<K, V>.RangeAll()
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Ensures(Contract.Result<IDirectedCollectionValue<KeyValuePair<K, V>>>() != null);
            Contract.Ensures(Contract.Result<IDirectedCollectionValue<KeyValuePair<K, V>>>().Count == @this.Count);
            return default(IDirectedCollectionValue<KeyValuePair<K, V>>);
        }

        void ISortedDictionary<K, V>.AddSorted(SCG.IEnumerable<KeyValuePair<K, V>> items)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<ArgumentNullException>(items != null, "items");
            Contract.Ensures(@this.Count >= Contract.OldValue(@this.Count));
            Contract.Ensures(Contract.ForAll(items, kvp => @this.Contains(kvp.Key)));
        }

        void ISortedDictionary<K, V>.RemoveRangeFrom(K low)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(!@this.Exists(kvp => @this.Comparer.Compare(low, kvp.Key) <= 0));
            Contract.Ensures(@this.Count <= Contract.OldValue(@this.Count));
        }

        void ISortedDictionary<K, V>.RemoveRangeFromTo(K low, K hi)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(!@this.Exists(kvp => @this.Comparer.Compare(low, kvp.Key) <= 0 && @this.Comparer.Compare(kvp.Key, hi) < 0));
            Contract.Ensures(@this.Count <= Contract.OldValue(@this.Count));
        }

        void ISortedDictionary<K, V>.RemoveRangeTo(K hi)
        {
            ISortedDictionary<K, V> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Ensures(!@this.Exists(kvp => @this.Comparer.Compare(kvp.Key, hi) < 0));
            Contract.Ensures(@this.Count <= Contract.OldValue(@this.Count));
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
