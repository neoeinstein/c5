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
using System.Runtime.Serialization;
using SCG = System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// An excption thrown when trying to access a view (a list view on a <see cref="IList{T}"/> or 
    /// a snapshot on a <see cref="IPersistentSorted{T}"/>)
    /// that has been invalidated by some earlier operation.
    /// <para>
    /// The typical scenario is a view on a list that hash been invalidated by a call to 
    /// Sort, Reverse or Shuffle on some other, overlapping view or the whole list.
    /// </para>
    /// </summary>
    [Serializable]
    public class ViewDisposedException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewDisposedException"/> class.
        /// </summary>
        public ViewDisposedException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewDisposedException"/>
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ViewDisposedException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewDisposedException"/>
        /// class with a specified error message and a reference to the inner exception that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference if
        /// no inner exception is specified.
        /// </param>
        public ViewDisposedException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewDisposedException"/>
        /// class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about
        /// the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about
        /// the source or destination.
        /// </param>
        protected ViewDisposedException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}