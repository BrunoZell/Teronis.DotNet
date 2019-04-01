﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Teronis.NetStandard.Extensions
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Basically, all this does is SHIFT the sign bits all the way to the first position. 
        /// If the result is unsigned then it will be 0; then it does the same operation and 
        /// flips the sign bits then ORs them together and the result is wither 1, 0 or -1.
        /// https://stackoverflow.com/questions/12184667/compare-two-numbers-and-return-1-0-or-1#answer-12185609
        /// </summary>
        /// <returns>
        /// returns 0 if equal
        /// returns 1 if x > y
        /// returns -1 if x < y
        /// </returns>
        public static int CompareFasterTo(this int x, int y) => ((x - y) >> 0x1F) | (int)((uint)-(x - y) >> 0x1F);
    }
}