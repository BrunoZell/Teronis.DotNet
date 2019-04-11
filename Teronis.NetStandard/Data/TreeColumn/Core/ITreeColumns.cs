﻿using System.Collections.Generic;

namespace Teronis.Data.TreeColumn.Core
{
    public interface ITreeColumnDefinitions<TreeColumnDefinitionKeyType, TreeColumnDefinitionType>
        where TreeColumnDefinitionKeyType : ITreeColumnKey
        where TreeColumnDefinitionType : ITreeColumnValue<TreeColumnDefinitionKeyType>
    {
        IDictionary<TreeColumnDefinitionKeyType, TreeColumnDefinitionType> TreeColumnDefinitionByKey { get; }
    }
}
