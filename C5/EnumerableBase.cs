/*
 Copyright (c) 2003-2006 Niels Kokholm and Peter Sestoft
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
*/

using System;
using SC = System.Collections;
using SCG = System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// A base class for implementing an <see cref="SCG.IEnumerable{T}"/>.
    /// </summary>
    [Serializable]
    public abstract class EnumerableBase<T> : SCG.IEnumerable<T>
    {
        /// <summary>
        /// Create an enumerator for this collection.
        /// </summary>
        /// <returns>The enumerator</returns>
        public abstract SCG.IEnumerator<T> GetEnumerator();

        /// <summary>
        /// Count the number of items in an enumerable by enumeration
        /// </summary>
        /// <param name="items">The enumerable to count</param>
        /// <returns>The size of the enumerable</returns>
        
        protected static int countItems(SCG.IEnumerable<T> items)
        {
            ICollectionValue<T> collectionValue = items as ICollectionValue<T>;
            if (collectionValue != null)
                return collectionValue.Count;

            SCG.ICollection<T> scgCollection = items as SCG.ICollection<T>;
            if (scgCollection != null)
                return scgCollection.Count;

            int count = 0;
            foreach (T item in items)
                ++count;

            return count;
        }

        #region IEnumerable Members

        SC.IEnumerator SC.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
