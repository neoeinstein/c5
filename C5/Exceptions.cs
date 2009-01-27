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
  /// An exception to throw from library code when an internal inconsistency is encountered.
  /// </summary>
  [Serializable]
  public class InternalException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/> class.
    /// </summary>
    internal InternalException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    internal InternalException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    internal InternalException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalException"/>
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
    protected InternalException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown by an update operation on a Read-Only collection or dictionary.
  /// <para>This exception will be thrown unconditionally when an update operation 
  /// (method or set property) is called. No check is made to see if the update operation, 
  /// if allowed, would actually change the collection. </para>
  /// <seealso cref="GuardedCollectionValue{T}"/>
  /// </summary>
  [Serializable]
  public class ReadOnlyCollectionException : InvalidOperationException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyCollectionException"/> class.
    /// </summary>
    public ReadOnlyCollectionException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyCollectionException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ReadOnlyCollectionException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyCollectionException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public ReadOnlyCollectionException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyCollectionException"/>
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
    protected ReadOnlyCollectionException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown when an attempt is made to add or remove members from a fixed-size
  /// collection, such as <see cref="WrappedArray{T}"/>
  /// </summary>
  [Serializable]
  public class FixedSizeCollectionException : InvalidOperationException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FixedSizeCollectionException"/> class.
    /// </summary>
    public FixedSizeCollectionException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixedSizeCollectionException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public FixedSizeCollectionException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixedSizeCollectionException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public FixedSizeCollectionException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FixedSizeCollectionException"/>
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
    protected FixedSizeCollectionException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown when an attempt is made to listen to an event for which
  /// the current object does not raise events.
  /// </summary>
  [Serializable]
  public class UnlistenableEventException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlistenableEventException"/> class.
    /// </summary>
      public UnlistenableEventException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnlistenableEventException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public UnlistenableEventException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnlistenableEventException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public UnlistenableEventException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnlistenableEventException"/>
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
    protected UnlistenableEventException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown by enumerators, range views etc. when accessed after 
  /// the underlying collection has been modified.
  /// </summary>
  [Serializable]
  public class CollectionModifiedException : InvalidOperationException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionModifiedException"/> class.
    /// </summary>
    public CollectionModifiedException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionModifiedException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CollectionModifiedException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionModifiedException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public CollectionModifiedException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionModifiedException"/>
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
    protected CollectionModifiedException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

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

  /// <summary>
  /// An exception thrown by a lookup or lookup with update operation that does not 
  /// find the lookup item and has no other means to communicate failure.
  /// <para>The typical scenario is a lookup by key in a dictionary with an indexer,
  /// see e.g. <see cref="P:IDictionary{K,V}.Item"/></para>
  /// </summary>
  [Serializable]
  public class NoSuchItemException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NoSuchItemException"/> class.
    /// </summary>
    public NoSuchItemException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NoSuchItemException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NoSuchItemException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NoSuchItemException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public NoSuchItemException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NoSuchItemException"/>
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
    protected NoSuchItemException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown by an operation on a list (<see cref="IList{T}"/>)
  /// that only makes sense for a view, not for an underlying list.
  /// </summary>
  [Serializable]
  public class NotAViewException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NotAViewException"/> class.
    /// </summary>
    public NotAViewException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotAViewException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NotAViewException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotAViewException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public NotAViewException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotAViewException"/>
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
    protected NotAViewException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

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

  /// <summary>
  /// An exception thrown when a given handle is invalid.  This can be due to an attempt to add
  /// a handle to the queue when that handle is already in use or an attempt to use the handle
  /// to reference an object no longer in the queue or associated with a different queue.
  /// </summary>
  [Serializable]
  public class InvalidPriorityQueueHandleException : InvalidOperationException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPriorityQueueHandleException"/> class.
    /// </summary>
    public InvalidPriorityQueueHandleException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPriorityQueueHandleException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidPriorityQueueHandleException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPriorityQueueHandleException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public InvalidPriorityQueueHandleException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidPriorityQueueHandleException"/>
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
    protected InvalidPriorityQueueHandleException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown when an operation needs to make a comparison between two objects
  /// but they are not comparable, i.e. do not implement <see cref="IComparable{T}"/>.
  /// </summary>
  [Serializable]
  public class NotComparableException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NotComparableException"/> class.
    /// </summary>
    public NotComparableException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotComparableException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NotComparableException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotComparableException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public NotComparableException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotComparableException"/>
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
    protected NotComparableException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }

  /// <summary>
  /// An exception thrown by operations on a list that expects an argument
  /// that is a view on the same underlying list.
  /// </summary>
  [Serializable]
  public class IncompatibleViewException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="IncompatibleViewException"/> class.
    /// </summary>
    public IncompatibleViewException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncompatibleViewException"/>
    /// class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public IncompatibleViewException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncompatibleViewException"/>
    /// class with a specified error message and a reference to the inner exception that
    /// is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">
    /// The exception that is the cause of the current exception, or a null reference if
    /// no inner exception is specified.
    /// </param>
    public IncompatibleViewException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="IncompatibleViewException"/>
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
    protected IncompatibleViewException(SerializationInfo info, StreamingContext context) 
        : base(info, context) { }
  }
}