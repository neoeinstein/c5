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
                Contract.Ensures((Contract.Result<EventTypeEnum>() & ~EventTypeEnum.All) == 0);
                return default(EventTypeEnum);
            }
        }

        EventTypeEnum ICollectionValue<T>.ActiveEvents
        {
            get
            {
                Contract.Ensures((Contract.Result<EventTypeEnum>() & ~EventTypeEnum.All) == 0);
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
                Contract.Ensures((@this.Count == 0 && Contract.Result<bool>() == true) || Contract.Result<bool>() == false);
                return default(bool);
            }
        }

        int ICollectionValue<T>.Count
        {
            get
            {
                ICollectionValue<T> @this = this;
                Contract.Ensures((Contract.Result<int>() == 0 && @this.IsEmpty) || !@this.IsEmpty);
                return default(int);
            }
        }

        Speed ICollectionValue<T>.CountSpeed
        {
            get
            {
                Contract.Ensures(Enum.IsDefined(typeof(Speed), Contract.Result<Speed>()));
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
            Contract.Ensures(Contract.Result<T[]>().Length == @this.Count);
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
            Contract.Ensures(Contract.Result<bool>() == true && Contract.Exists(@this, predicate));
            return default(bool);
        }

        bool ICollectionValue<T>.Find(Predicate<T> predicate, out T item)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(Contract.Exists(@this, predicate) && Contract.ValueAtReturn(out item) != null);
            item = default(T);
            return default(bool);
        }

        bool ICollectionValue<T>.All(Predicate<T> predicate)
        {
            ICollectionValue<T> @this = this;
            Contract.Requires<ArgumentNullException>(predicate != null, "predicate");
            Contract.Ensures(Contract.Result<bool>() == true && Contract.ForAll(@this, predicate));
            return default(bool);
        }

        T ICollectionValue<T>.Choose()
        {
            ICollectionValue<T> @this = this;
            Contract.Requires(!@this.IsEmpty);
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