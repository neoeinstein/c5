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
    /// Tentative, to conserve memory in GuardedCollectionValueBase
    /// This should really be nested in Guarded collection value, only have a guardereal field
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    internal sealed class ProxyEventBlock<T>
    {
        private ICollectionValue<T> proxy, real;

        internal ProxyEventBlock(ICollectionValue<T> proxy, ICollectionValue<T> real)
        {
            this.proxy = proxy;
            this.real = real;
        }

        private event CollectionChangedHandler<T> collectionChanged;
        private CollectionChangedHandler<T> collectionChangedProxy;

        internal event CollectionChangedHandler<T> CollectionChanged
        {
            add
            {
                if (collectionChanged == null)
                {
                    if (collectionChangedProxy == null)
                        collectionChangedProxy = delegate(object sender) { collectionChanged(proxy); };
                    real.CollectionChanged += collectionChangedProxy;
                }
                collectionChanged += value;
            }
            remove
            {
                collectionChanged -= value;
                if (collectionChanged == null)
                    real.CollectionChanged -= collectionChangedProxy;
            }
        }

        private event CollectionClearedHandler<T> collectionCleared;
        private CollectionClearedHandler<T> collectionClearedProxy;

        internal event CollectionClearedHandler<T> CollectionCleared
        {
            add
            {
                if (collectionCleared == null)
                {
                    if (collectionClearedProxy == null)
                        collectionClearedProxy =
                            delegate(object sender, ClearedEventArgs e) { collectionCleared(proxy, e); };
                    real.CollectionCleared += collectionClearedProxy;
                }
                collectionCleared += value;
            }
            remove
            {
                collectionCleared -= value;
                if (collectionCleared == null)
                    real.CollectionCleared -= collectionClearedProxy;
            }
        }

        private event ItemsAddedHandler<T> itemsAdded;
        private ItemsAddedHandler<T> itemsAddedProxy;

        internal event ItemsAddedHandler<T> ItemsAdded
        {
            add
            {
                if (itemsAdded == null)
                {
                    if (itemsAddedProxy == null)
                        itemsAddedProxy = delegate(object sender, ItemCountEventArgs<T> e) { itemsAdded(proxy, e); };
                    real.ItemsAdded += itemsAddedProxy;
                }
                itemsAdded += value;
            }
            remove
            {
                itemsAdded -= value;
                if (itemsAdded == null)
                    real.ItemsAdded -= itemsAddedProxy;
            }
        }

        private event ItemInsertedHandler<T> itemInserted;
        private ItemInsertedHandler<T> itemInsertedProxy;

        internal event ItemInsertedHandler<T> ItemInserted
        {
            add
            {
                if (itemInserted == null)
                {
                    if (itemInsertedProxy == null)
                        itemInsertedProxy = delegate(object sender, ItemAtEventArgs<T> e) { itemInserted(proxy, e); };
                    real.ItemInserted += itemInsertedProxy;
                }
                itemInserted += value;
            }
            remove
            {
                itemInserted -= value;
                if (itemInserted == null)
                    real.ItemInserted -= itemInsertedProxy;
            }
        }

        private event ItemsRemovedHandler<T> itemsRemoved;
        private ItemsRemovedHandler<T> itemsRemovedProxy;

        internal event ItemsRemovedHandler<T> ItemsRemoved
        {
            add
            {
                if (itemsRemoved == null)
                {
                    if (itemsRemovedProxy == null)
                        itemsRemovedProxy = delegate(object sender, ItemCountEventArgs<T> e) { itemsRemoved(proxy, e); };
                    real.ItemsRemoved += itemsRemovedProxy;
                }
                itemsRemoved += value;
            }
            remove
            {
                itemsRemoved -= value;
                if (itemsRemoved == null)
                    real.ItemsRemoved -= itemsRemovedProxy;
            }
        }

        private event ItemRemovedAtHandler<T> itemRemovedAt;
        private ItemRemovedAtHandler<T> itemRemovedAtProxy;

        internal event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add
            {
                if (itemRemovedAt == null)
                {
                    if (itemRemovedAtProxy == null)
                        itemRemovedAtProxy = delegate(object sender, ItemAtEventArgs<T> e) { itemRemovedAt(proxy, e); };
                    real.ItemRemovedAt += itemRemovedAtProxy;
                }
                itemRemovedAt += value;
            }
            remove
            {
                itemRemovedAt -= value;
                if (itemRemovedAt == null)
                    real.ItemRemovedAt -= itemRemovedAtProxy;
            }
        }
    }
}
