﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Teronis.Data
{
    public class Update<T>
    {
        public object OriginalSource { get; private set; }
        public T Content { get; private set; }

        public Update(T content, object originalSource)
        {
            Content = content;
            OriginalSource = originalSource;
        }
    }
}