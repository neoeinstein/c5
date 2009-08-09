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
