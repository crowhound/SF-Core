using System.Collections.Generic;
using SFEditor.Core.Packages;
using UnityEngine;

namespace SFEditor.Core
{
    /// <summary>
    /// A database of the SF Packages that are usable for the community. 
    /// </summary>
    [CreateAssetMenu(fileName = "SFPackageDatabase", menuName = "SF/Hub/SF Package Database")]
    public class SFPackageDatabase : ScriptableObject
    {
        /// <summary>
        ///  Path to the SF Package Database asset.
        /// </summary>
        public const string DatabasePath =
            "Packages/com.shatter-fantasy.sf-core/Editor/Package Data/SFPackageDatabase.asset";
        public List<SFPackageDataSet> SFPackages = new();


        private void OnEnable()
        {
            //SFPackages.Add(SFPackageDefaults.SFUtilitiesPackage);
            //SFPackages.Add(SFPackageDefaults.SFUIElementsPackage);
            // Add the known extra SF Packages to the ExtraPackage list.
            //SFPackages.Add(SFPackageDefaults.SFMetroidvaniaPackage);
        }
    }

    [System.Serializable]
    public class SFPackageDataSet
    {
        public List<SFPackageData> PackageVersionData = new ();

        public SFPackageDataSet(string packageName, string basePackageURL, string packageDisplayName ,string packageReleaseTag = "")
        {
            
        }
    }
}
