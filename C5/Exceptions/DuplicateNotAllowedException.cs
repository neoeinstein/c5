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
    /// An exception thrown when an operation attempts to create a duplicate in a collection with set semantics 
    /// (<see cref="IExtensible{T}.AllowsDuplicates"/> is false) or attempts to create a duplicate key in a dictionary.
    /// <para>With collections this can only happen with Insert operations on lists, since the Add operations will
    /// not try to create duplictes and either ignore the failure or report it in a bool return value.
    /// </para>
    /// <para>With dictionaries this can happen with the <see cref="IDictionary{K,V}.Add"/> method.</para>
    /// </summary>
    [Serializable]
    public class DuplicateNotAllowedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNotAllowedException"/> class.
        /// </summary>
        public DuplicateNotAllowedException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNotAllowedException"/>
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DuplicateNotAllowedException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNotAllowedException"/>
        /// class with a specified error message and a reference to the inner exception that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference if
        /// no inner exception is specified.
        /// </param>
        public DuplicateNotAllowedException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNotAllowedException"/>
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
        protected DuplicateNotAllowedException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}