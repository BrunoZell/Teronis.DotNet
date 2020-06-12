﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
//using GitVersion.MSBuildTask;
using Microsoft.Build.Utilities;
using Teronis.GitVersionCache.Utilities;
using Teronis.IO;

namespace Teronis.GitVersionCache.BuildTasks
{
    public static class BuildTaskUtilities
    {
        public static DirectoryInfo GetParentOfGitVersionYamlDirectory() =>
              DirectoryTools.GetDirectoryOfFileAbove("GitVersion.yml", ModuleInitializer.ContainerRootDirectory);

        public static DirectoryInfo GetParentOfGitDirectory() =>
              DirectoryTools.GetDirectoryOfDirectoryAbove(".git", ModuleInitializer.ContainerRootDirectory);


        //DirectoryUtilities.GetDirectoryOfFileAbove("GitVersion.yml", ModuleInitializer.ContainerRootDirectory);

        ///// <summary>
        ///// Gets the GitVersionCore owned list of <see cref="ServiceDescriptor"/>s.
        ///// </summary>
        //public static IServiceProvider GetGitVersionCoreOwnedServiceProvider(GitVersionTaskBase buildTask)
        //{
        //    var buildServiceProviderMethodInfo = typeof(GitVersionTasks).GetMethod("BuildServiceProvider", BindingFlags.Static | BindingFlags.NonPublic);
        //    var serviceProvider = (IServiceProvider)buildServiceProviderMethodInfo.Invoke(null, new[] { buildTask });
        //    return serviceProvider;
        //}

        ///// <summary>
        ///// Gets the GitVersionCore owned list of <see cref="ServiceDescriptor"/>s.
        ///// </summary>
        //public static IList<ServiceDescriptor> GetGitVersionCoreOwnedServiceDescriptors(GitVersionTaskBase buildTask)
        //{
        //    var serviceProvider = GetGitVersionCoreOwnedServiceProvider(buildTask);
        //    var instanceBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        //    var engine = serviceProvider.GetType().GetField("_engine", instanceBindingFlags).GetValue(serviceProvider);
        //    var callSiteFactory = engine.GetType().GetProperty("CallSiteFactory", instanceBindingFlags).GetValue(engine);
        //    var serviceDescriptors = (List<ServiceDescriptor>)callSiteFactory.GetType().GetField("_descriptors", instanceBindingFlags).GetValue(callSiteFactory);
        //    return serviceDescriptors;
        //}

        public static void SetUndefinedAsDefault(object instance, string propertyName, TaskLoggingHelper Log)
        {
            var instanceType = instance.GetType();
            var propertyInfo = instanceType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            if (propertyInfo == null) {
                return;
            }

            var propertyValue = propertyInfo.GetValue(instance);

            if (propertyValue is string propertyString && propertyString == "*Undefined*") {
                propertyInfo.SetValue(instance, null);
            }
        }
    }
}