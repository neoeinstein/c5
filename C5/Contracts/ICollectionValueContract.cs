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
    [ContractClassFor(typeof(ICollectionValue<>))]
    internal sealed class ICollectionValueContract<T> : ICollectionValue<T>
    {
        EventTypeEnum ICollectionValue<T>.ListenableEvents
        {
            get
            {
                Contract.Ensures(Enums.IsValidEventType(Contract.Result<EventTypeEnum>()));
                return default(EventTypeEnum);
            }
        }

        EventTypeEnum ICollectionValue<T>.ActiveEvents
        {
            get
            {
                Contract.Ensures(Enums.IsValidEventType(Contract.Result<EventTypeEnum>()));
                return default(EventTypeEnum);
            }
        }

        event CollectionChangedHandler<T> ICollectionValue<T>.CollectionChanged
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.Changed) == EventTypeEnum.Changed);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.Changed) == EventTypeEnum.Changed);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.Changed) == EventTypeEnum.Changed);
            }
        }

        event CollectionClearedHandler<T> ICollectionValue<T>.CollectionCleared
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.Cleared) == EventTypeEnum.Cleared);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.Cleared) == EventTypeEnum.Cleared);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.Cleared) == EventTypeEnum.Cleared);
            }
        }

        event ItemsAddedHandler<T> ICollectionValue<T>.ItemsAdded
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.Added) == EventTypeEnum.Added);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.Added) == EventTypeEnum.Added);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.Added) == EventTypeEnum.Added);
            }
        }

        event ItemInsertedHandler<T> ICollectionValue<T>.ItemInserted
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.Inserted) == EventTypeEnum.Inserted);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.Inserted) == EventTypeEnum.Inserted);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.Inserted) == EventTypeEnum.Inserted);
            }
        }

        event ItemsRemovedHandler<T> ICollectionValue<T>.ItemsRemoved
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.Removed) == EventTypeEnum.Removed);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.Removed) == EventTypeEnum.Removed);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.Removed) == EventTypeEnum.Removed);
            }
        }

        event ItemRemovedAtHandler<T> ICollectionValue<T>.ItemRemovedAt
        {
            add
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ListenableEvents & EventTypeEnum.RemovedAt) == EventTypeEnum.RemovedAt);
                Contract.Ensures((@this.ActiveEvents & EventTypeEnum.RemovedAt) == EventTypeEnum.RemovedAt);
            }
            remove
            {
                ICollectionValue<T> @this = this;
                Contract.Requires((@this.ActiveEvents & EventTypeEnum.RemovedAt) == EventTypeEnum.RemovedAt);
            }
        }

        bool ICollectionValue<T>.IsEmpty
        {
            get
            {
                ICollectionValue<T> @this = this;
                Contract.Ensures(Logical.Equivalence(Contract.Result<bool>() == true, () => @this.Count == 0));
                return default(bool);
            }
        }

        int ICollectionValue<T>.Count
        {
            get
            {
                ICollectionValue<T> @this = this;
                Contract.Ensures(Logical.Equivalence(Contract.Result<int>() == 0, () => @this.IsEmpty));
                return default(int);
            }
        }

        Speed ICollectionValue<T>.CountSpeed
        {
            get
            {
                Contract.Ensures(Enums.IsValidSpeed(Contract.Result<Speed>()));
                return default(Speed);
            }
        }

        void ICollectionValue<T>.CopyTo(T[] array, int index)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(array != null, "array");
            Contract.Requires<ArgumentOutOfRangeException>(index <= array.GetUpperBound(0), "index");
            Contract.Requires<ArgumentOutOfRangeException>(index >= array.GetLowerBound(0), "index");
            Contract.Requires<ArgumentException>(index + @this.Count <= array.Length, "array");
            Contract.Requires(index + @this.Count <= array.GetUpperBound(0), "Starting at index, collection will not fit in array");
        }

        T[] ICollectionValue<T>.ToArray()
        {
            ICollectionValue<T> @this = this;
            Contract.Ensures(Contract.Result<T[]>() != null);
            return default(T[]);
        }

        void ICollectionValue<T>.Apply(Action<T> action)
        {
            Contract.Requires<ArgumentNullException>(action != null, "action");
        }

        bool ICollectionValue<T>.Exists(Predicate<T> predicate)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(Logical.Equivalence(Contract.Result<bool>() == true, () => Contract.Exists(@this, predicate)));
            return default(bool);
        }

        bool ICollectionValue<T>.Find(Predicate<T> predicate, out T item)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(Logical.Equivalence(Contract.Result<bool>() == true, () => Contract.Exists(@this, predicate)));
            Contract.Ensures(Contract.Result<bool>() == true || object.Equals(Contract.ValueAtReturn<T>(out item), default(T)));
            item = default(T);
            return default(bool);
        }

        bool ICollectionValue<T>.All(Predicate<T> predicate)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(Logical.Equivalence(Contract.Result<bool>() == true, () => Contract.ForAll(@this, predicate)));
            return default(bool);
        }

        T ICollectionValue<T>.Choose()
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<NoSuchItemException>(!@this.IsEmpty);
            return default(T);
        }

        SCG.IEnumerable<T> ICollectionValue<T>.Filter(Predicate<T> filter)
        {
            Contract.Requires<ArgumentNullException>(filter != null, "filter");
            Contract.Ensures(Contract.ForAll(Contract.Result<SCG.IEnumerable<T>>(), filter));
            return default(SCG.IEnumerable<T>);
        }

        #region Inherited Members not in Contract

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

        #endregion
    }
}