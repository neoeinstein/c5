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
using SCG = System.Collections.Generic;
namespace C5
{
    /// <summary>
    /// An editable collection maintaining a definite sequence order of the items.
    ///
    /// <i>Implementations of this interface must compute the hash code and 
    /// equality exactly as prescribed in the method definitions in order to
    /// be consistent with other collection classes implementing this interface.</i>
    /// <i>This interface is usually implemented by explicit interface implementation,
    /// not as ordinary virtual methods.</i>
    /// </summary>
    public interface ISequenced<T> : ICollection<T>, IDirectedCollectionValue<T>
    {
        /// <summary>
        /// The hashcode is defined as <code>h(...h(h(h(x1),x2),x3),...,xn)</code> for
        /// <code>h(a,b)=CONSTANT*a+b</code> and the x's the hash codes of the items of 
        /// this collection.
        /// </summary>
        /// <returns>The sequence order hashcode of this collection.</returns>
        int GetSequencedHashCode();


        /// <summary>
        /// Compare this sequenced collection to another one in sequence order.
        /// </summary>
        /// <param name="otherCollection">The sequenced collection to compare to.</param>
        /// <returns>True if this collection and that contains equal (according to
        /// this collection's itemequalityComparer) in the same sequence order.</returns>
        bool SequencedEquals(ISequenced<T> otherCollection);
    }
}