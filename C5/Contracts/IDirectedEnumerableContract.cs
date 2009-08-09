using System;
using System.Diagnostics.Contracts;

namespace C5.Contracts
{
    [ContractClassFor(typeof(IDirectedEnumerable<>))]
    internal sealed class IDirectedEnumerableContract<T> : IDirectedEnumerable<T>
    {
        IDirectedEnumerable<T> IDirectedEnumerable<T>.Backwards()
        {
            IDirectedEnumerable<T> @this = this;
            Contract.Ensures((Contract.Result<IDirectedEnumerable<T>>().Direction == EnumerationDirection.Forwards && @this.Direction == EnumerationDirection.Backwards) || @this.Direction == EnumerationDirection.Forwards);
            Contract.Ensures(Contract.Result<IDirectedEnumerable<T>>() != null);
            return default(IDirectedEnumerable<T>);
        }

        EnumerationDirection IDirectedEnumerable<T>.Direction
        {
            get
            {
                Contract.Ensures(Enum.IsDefined(typeof(EnumerationDirection), Contract.Result<EnumerationDirection>()));
                return default(EnumerationDirection);
            }
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

        #endregion
    }
}
