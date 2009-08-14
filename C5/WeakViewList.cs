﻿/*
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
using SCG = System.Collections.Generic;

namespace C5
{
    /// <summary>
    /// This class is shared between the linked list and array list implementations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    class WeakViewList<T> where T : class
    {
        Node start;

        internal Node Add(T view)
        {
            Node newNode = new Node(view);
            if (start != null)
            {
                start.prev = newNode;
                newNode.next = start;
            }
            start = newNode;
            return newNode;
        }

        internal void Remove(Node n)
        {
            if (n == start)
            {
                start = start.next;
                if (start != null)
                    start.prev = null;
            }
            else
            {
                n.prev.next = n.next;
                if (n.next != null)
                    n.next.prev = n.prev;
            }
        }
        /// <summary>
        /// Note that it is safe to call views.Remove(view.myWeakReference) if view
        /// is the currently yielded object
        /// </summary>
        /// <returns></returns>
        public SCG.IEnumerator<T> GetEnumerator()
        {
            Node n = start;
            while (n != null)
            {
                //V view = n.weakview.Target as V; //This provokes a bug in the beta1 verifyer
                object o = n.weakview.Target;
                T view = o is T ? (T)o : null;
                if (view == null)
                    Remove(n);
                else
                    yield return view;
                n = n.next;
            }
        }

        [Serializable]
        internal class Node
        {
            internal readonly WeakReference weakview;
            internal Node prev;
            internal Node next;

            internal Node(T view)
            {
                weakview = new WeakReference(view);
            }
        }
    }
}
