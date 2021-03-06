﻿using System;
using Teronis.Threading.Tasks;

namespace Teronis.Collections.CollectionChanging
{
    public class CollectionChangeConversionAppliedEventArgs<ConvertedItemType, CommonValueType, OriginContentType> : EventArgs
    {
        public static CollectionChangeConversionAppliedEventArgs<ConvertedItemType, CommonValueType, OriginContentType> CreateAsynchronous(IConversionCollectionChangeBundles<ConvertedItemType, CommonValueType, OriginContentType> bundles, AsyncEventSequence eventSequence)
        {
            eventSequence = eventSequence ?? throw new ArgumentNullException(nameof(eventSequence));
            return new CollectionChangeConversionAppliedEventArgs<ConvertedItemType, CommonValueType, OriginContentType>(bundles, eventSequence);
        }

        /// <summary>
        /// This is the aspected original change that has been already applied.
        /// </summary>
        public ICollectionChangeBundle<ConvertedItemType, CommonValueType> ConvertedCollectionChangeBundle { get; private set; }
        public ICollectionChangeBundle<CommonValueType, OriginContentType> OriginCollectionChangeBundle { get; private set; }
        public AsyncEventSequence EventSequence { get; private set; }

        private CollectionChangeConversionAppliedEventArgs(IConversionCollectionChangeBundles<ConvertedItemType, CommonValueType, OriginContentType> bundles,
            AsyncEventSequence eventSequence)
        {
            bundles = bundles ?? throw new ArgumentNullException(nameof(bundles));
            ConvertedCollectionChangeBundle = bundles.ConvertedBundle;
            OriginCollectionChangeBundle = bundles.OriginBundle;
            EventSequence = eventSequence;
        }
    }
}
