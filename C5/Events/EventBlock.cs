/*
 * Copyright (c) 2003-2006 Niels Kokholm and Peter Sestoft
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

using System;

namespace C5
{
    /// <summary>
    /// Holds the real Events for a collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    internal sealed class EventBlock<T>
    {
        internal EventTypeEnum Events;

        private event CollectionChangedHandler<T> collectionChanged;

        internal event CollectionChangedHandler<T> CollectionChanged
        {
            add
            {
                collectionChanged += value;
                Events |= EventTypeEnum.Changed;
            }
            remove
            {
                collectionChanged -= value;
                if (collectionChanged == null)
                    Events &= ~EventTypeEnum.Changed;
            }
        }

        internal void RaiseCollectionChanged(object sender)
        {
            if (collectionChanged != null)
                collectionChanged(sender);
        }

        private event CollectionClearedHandler<T> collectionCleared;

        internal event CollectionClearedHandler<T> CollectionCleared
        {
            add
            {
                collectionCleared += value;
                Events |= EventTypeEnum.Cleared;
            }
            remove
            {
                collectionCleared -= value;
                if (collectionCleared == null)
                    Events &= ~EventTypeEnum.Cleared;
            }
        }

        internal void RaiseCollectionCleared(object sender, bool full, int count)
        {
            if (collectionCleared != null)
                collectionCleared(sender, new ClearedEventArgs(full, count));
        }

        internal void RaiseCollectionCleared(object sender, bool full, int count, int? start)
        {
            if (collectionCleared != null)
                collectionCleared(sender, new ClearedRangeEventArgs(full, count, start));
        }

        private event ItemsAddedHandler<T> itemsAdded;

        internal event ItemsAddedHandler<T> ItemsAdded
        {
            add
            {
                itemsAdded += value;
                Events |= EventTypeEnum.Added;
            }
            remove
            {
                itemsAdded -= value;
                if (itemsAdded == null)
                    Events &= ~EventTypeEnum.Added;
            }
        }

        internal void RaiseItemsAdded(object sender, T item, int count)
        {
            if (itemsAdded != null)
                itemsAdded(sender, new ItemCountEventArgs<T>(item, count));
        }

        private event ItemsRemovedHandler<T> itemsRemoved;

        internal event ItemsRemovedHandler<T> ItemsRemoved
        {
            add
            {
                itemsRemoved += value;
                Events |= EventTypeEnum.Removed;
            }
            remove
            {
                itemsRemoved -= value;
                if (itemsRemoved == null)
                    Events &= ~EventTypeEnum.Removed;
            }
        }

        internal void RaiseItemsRemoved(object sender, T item, int count)
        {
            if (itemsRemoved != null)
                itemsRemoved(sender, new ItemCountEventArgs<T>(item, count));
        }

        private event ItemInsertedHandler<T> itemInserted;

        internal event ItemInsertedHandler<T> ItemInserted
        {
            add
            {
                itemInserted += value;
                Events |= EventTypeEnum.Inserted;
            }
            remove
            {
                itemInserted -= value;
                if (itemInserted == null)
                    Events &= ~EventTypeEnum.Inserted;
            }
        }

        internal void RaiseItemInserted(object sender, T item, int index)
        {
            if (itemInserted != null)
                itemInserted(sender, new ItemAtEventArgs<T>(item, index));
        }

        private event ItemRemovedAtHandler<T> itemRemovedAt;

        internal event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add
            {
                itemRemovedAt += value;
                Events |= EventTypeEnum.RemovedAt;
            }
            remove
            {
                itemRemovedAt -= value;
                if (itemRemovedAt == null)
                    Events &= ~EventTypeEnum.RemovedAt;
            }
        }

        internal void RaiseItemRemovedAt(object sender, T item, int index)
        {
            if (itemRemovedAt != null)
                itemRemovedAt(sender, new ItemAtEventArgs<T>(item, index));
        }
    }
}