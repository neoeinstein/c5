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

namespace C5
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum EventTypeEnum
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// 
        /// </summary>
        Changed = 0x00000001,
        /// <summary>
        /// 
        /// </summary>
        Cleared = 0x00000002,
        /// <summary>
        /// 
        /// </summary>
        Added = 0x00000004,
        /// <summary>
        /// 
        /// </summary>
        Removed = 0x00000008,
        /// <summary>
        /// 
        /// </summary>
        Basic = Changed | Cleared | Added | Removed,
        /// <summary>
        /// 
        /// </summary>
        Inserted = 0x00000010,
        /// <summary>
        /// 
        /// </summary>
        RemovedAt = 0x00000020,
        /// <summary>
        /// 
        /// </summary>
        All = Basic | Inserted | RemovedAt,
    }
}