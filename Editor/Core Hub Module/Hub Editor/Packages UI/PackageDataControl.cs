using UnityEditor;
using UnityEngine.UIElements;

using static SFEditor.Core.Utilities.HubPathUtilities;

using SF.UIElements;
using SF.UIElements.Utilities;
using UnityEngine;

namespace SFEditor.Core.Packages
{
    [UxmlElement]
    public sealed partial class PackageDataControl : SFVisualElementBase
    {

        private Button _installButton;
        
        private SFPackageData _packageData;
        public SFPackageData PackageData 
        {  
            get => _packageData;
            private set => _packageData = value;
        }
        
        public PackageDataControl()
        {
            _visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(AvailablePackageUXMLPath);
            CloneVisualTreeAsset();
        }
        public PackageDataControl(SFPackageData packageData)
        {
            _visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(AvailablePackageUXMLPath);
            CloneVisualTreeAsset();
            
            PackageData = packageData;
            // Have to set the data source of the TemplateContainer not the root C# VisualElement object.
            _rootTemplateContainer.dataSource = PackageData;
            
            _installButton = _rootTemplateContainer
                .Q<Button>("package-install__button")
                ?.OnClick(OnInstallButtonClicked);
            
        }

        private void OnInstallButtonClicked()
        {
            Debug.Log($"Installing: {_packageData.PackageName}");
            SFHubPackageSystem.AddSFPackage(_packageData);
        }

        private void OnReleaseTagValueChanged(ChangeEvent<string> evt)
        {
            // TODO: Import new package version after validating the new release tage value is a valid package release.
            _packageData.PackageReleaseTag = evt.newValue;
            
            // Testing remove.
            if (string.IsNullOrEmpty(evt.newValue))
                return;
        
            SFHubPackageSystem.AddSFPackage(_packageData);
        }
    }
}
