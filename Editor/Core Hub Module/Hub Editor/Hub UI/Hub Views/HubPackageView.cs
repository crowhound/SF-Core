using System.Collections.Generic;
using UnityEngine.UIElements;

using SF.UIElements;
using SF.UIElements.Utilities;
using SFEditor.Core.Packages;
using static SFEditor.Core.Packages.SFPackageDefaults;

namespace SFEditor.Core
{
    [UxmlElement]
    public partial class HubPackageView : SFVisualElementBase
    {
        public new const string USSClassName = "hub-package__view";

        public List<SFPackageData> InstalledPackages => SFHubPackageSystem.SFInstalledPackages;
        
        public SFPackageData UtilitiesPackage = new(SFUtilitiesPackageName, SFUtilitiesBasePackageURL); 

        public HubPackageView() : base()
        {
            foreach (var packageData in InstalledPackages)
            {
                this.AddChild(new PackageDataControl(packageData));
            }
            
            /*
             *  List of installed SF packages of Unity. List<SFPackageData>
             *  List the required Unity packages for the installed packages.
             *  List minimum version of Unity required for full feature support.
             */
        }
    }
}
