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
    [ContractClassFor(typeof(IDictionary<,>))]
    internal sealed class IDictionaryContract<K, V> : IDictionary<K, V>
    {
        SCG.IEqualityComparer<K> IDictionary<K, V>.EqualityComparer
        {
            get { throw new NotImplementedException(); }
        }

        V IDictionary<K, V>.this[K key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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

        void IDictionary<K, V>.AddAll<U, W>(SCG.IEnumerable<KeyValuePair<U, W>> entries)
        {
            throw new NotImplementedException();
        }

        Speed IDictionary<K, V>.ContainsSpeed
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<K, V>.ContainsAll<H>(SCG.IEnumerable<H> items)
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

        #region Interface Members not in Contract

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

        SCG.IEnumerable<KeyValuePair<K, V>> ICollectionValue<KeyValuePair<K, V>>.Filter(Predicate<KeyValuePair<K, V>> filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<K,V>> Members

        SCG.IEnumerator<KeyValuePair<K, V>> SCG.IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
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
