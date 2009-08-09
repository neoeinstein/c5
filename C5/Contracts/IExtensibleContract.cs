using System;
using System.Diagnostics.Contracts;
using SCG = System.Collections.Generic;

namespace C5.Contracts
{
    [ContractClassFor(typeof(IExtensible<>))]
    internal sealed class IExtensibleContract<T> : IExtensible<T>
    {
        bool IExtensible<T>.IsReadOnly
        {
            get { return default(bool); }
        }

        bool IExtensible<T>.AllowsDuplicates
        {
            get { return default(bool); }
        }

        SCG.IEqualityComparer<T> IExtensible<T>.EqualityComparer
        {
            get
            {
                Contract.Ensures(Contract.Result<SCG.IEqualityComparer<T>>() != null);
                return default(SCG.IEqualityComparer<T>);
            }
        }

        bool IExtensible<T>.DuplicatesByCounting
        {
            get { return default(bool); }
        }

        bool IExtensible<T>.Add(T item)
        {
            IExtensible<T> @this = this;
            Contract.Requires<ReadOnlyCollectionException>(!@this.IsReadOnly);
            Contract.Requires<DuplicateNotAllowedException>(@this.AllowsDuplicates || @this.All(i => !@this.EqualityComparer.Equals(i, item)));
            Contract.Ensures(
                (Contract.Result<bool>() == true && @this.Count == Contract.OldValue(@this.Count) + 1)
                || (Contract.Result<bool>() == false && @this.Count == Contract.OldValue(@this.Count)));
            Contract.EnsuresOnThrow<DuplicateNotAllowedException>(@this.Count == Contract.OldValue(@this.Count));
            return default(bool);
        }

        void IExtensible<T>.AddAll<U>(SCG.IEnumerable<U> items)
        {
            IExtensible<T> @this = this;
            Contract.Requires<ArgumentNullException>(items != null, "items");
            Contract.Requires(!@this.IsReadOnly);
            Contract.Ensures(@this.Count >= Contract.OldValue(@this.Count));
        }

        bool IExtensible<T>.Check()
        {
            return default(bool);
        }

        #region Inherited Members not in Contract

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

        #endregion
    }
}
