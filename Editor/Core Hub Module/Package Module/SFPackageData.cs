using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

namespace SFEditor.Core.Packages
{
    /// <summary>
    /// The data struct used for keeping track of packages versions, other SF package dependencies,
    /// scripting defines, needed assembly definitions, and Unity packages dependencies.
    /// </summary>
    [System.Serializable]
    public struct SFPackageData
    {
        public readonly string PackageName;
        public readonly string BasePackageURL;
        /// <summary>
        /// This is an optional string to allow people to pull specific versions of a package release or even choose the nightly  branch. 
        /// </summary>
        public string PackageReleaseTag;

        public string FullPackageURL => BasePackageURL + PackageReleaseTag;
        
        public List<string> ScriptingDefinesNames;
        public List<string> UnityPackageDependencies;
        
        public SFPackageData(string packageName, string basePackageURL, string packageReleaseTag = "")
        {
            if (string.IsNullOrEmpty(packageName))
            {
                Debug.LogError("The package name value being passed into the SFPackageData constructor is not valid."
                    + $"Passed in package name is: {packageName}");
                packageName = "Invalid Package Name";
            }

            // TODO BasePackageURL Validation: Make sure the BasePackageURL value is a valid Git URL.
            
            PackageName = packageName;
            BasePackageURL = basePackageURL;
            PackageReleaseTag = packageReleaseTag;
            
            ScriptingDefinesNames = new();
            UnityPackageDependencies = new();
        }
    }

    /// <summary>
    /// These are the URL for the current public GitHub packages
    /// </summary>
    public class SFPackageDefaults
    {
        #region Required Packages
        public static readonly SFPackageData SFUtilitiesPackage = new SFPackageData(SFUtilitiesPackageName,SFUtilitiesBasePackageURL);
        public static readonly SFPackageData SFUIElementsPackage = new SFPackageData(SFUIElementsPackageName,SFUIElementsBasePackageURL);
        
        public const string SFUtilitiesPackageName = "shatter-fantasy.sf-utilities";
        public const string SFUtilitiesBasePackageURL = "https://github.com/Shatter-Fantasy/SF-Utilities.git";
        
        public const string SFUIElementsPackageName = "shatter-fantasy.sf-ui-elements";
        public const string SFUIElementsBasePackageURL = "https://github.com/Shatter-Fantasy/SF-UI-Elements.git";

        #endregion
        
        /*
            public const string SFSpriteToolsBasePackageURL = "https://github.com/crowhound/SF-Sprite-Tools.git";
            public const string SFSpriteToolsPackageName = "com.shatter-fantasy.sf-sprite-tools";
        */
    }
}
