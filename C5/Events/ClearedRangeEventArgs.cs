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
    /// 
    /// </summary>
    public class ClearedRangeEventArgs : ClearedEventArgs
    {
        //WE could let this be of type int? to  allow 
        /// <summary>
        /// 
        /// </summary>
        public readonly int? Start;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="full"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        public ClearedRangeEventArgs(bool full, int count, int? start)
            : base(full, count)
        {
            Start = start;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("(ClearedRangeEventArgs {0} {1} {2})", Count, Full, Start);
        }
    }
}
