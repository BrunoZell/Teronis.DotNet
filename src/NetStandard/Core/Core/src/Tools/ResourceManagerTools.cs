﻿using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace Teronis.Tools
{
    public class ResourceManagerTools
    {
        public static List<CultureInfo> GetSupportedCultures(ResourceManager resourceManager)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var supportedCultures = new List<CultureInfo>();

            foreach (var culture in cultures) {
                try {
                    // TODO: After that line all satellite assemblies are loaded
                    var resourceSet = resourceManager.GetResourceSet(culture, true, false);

                    if (resourceSet != null) {
                        supportedCultures.Add(culture);
                    }
                } catch { }
            }

            return supportedCultures;
        }
    }
}
