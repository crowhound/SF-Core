using System.Collections.Generic;
using UnityEngine.UIElements;

using SF.UIElements;
using SF.UIElements.Utilities;
using SFEditor.Core.Packages;

namespace SFEditor.Core
{
    [UxmlElement]
    public partial class HubPackageView : SFVisualElementBase
    {
        public new const string USSClassName = "hub-package__view";

        public List<SFPackageData> InstalledPackages => SFHubPackageSystem.SFInstalledPackages;
        public List<SFPackageData> ExtraPackages => SFHubPackageSystem.SFExtraPackages;
        
        public HubPackageView() : base()
        {
            foreach (var packageData in InstalledPackages)
            {
                this.AddChild(new PackageDataControl(packageData));
            }

            foreach (var packageData in ExtraPackages)
            {
                // If we already have the extra package installed don't show it again.
                if(InstalledPackages.Contains(packageData))
                    continue;
                
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
