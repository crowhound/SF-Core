using SF.UIElements;
using SF.UIElements.Utilities;
using UnityEngine;
using UnityEngine.UIElements;


namespace SFEditor.Core.Packages
{
    
#if SF_UIELEMENTS
    [UxmlElement]
    public partial class PackageDataControl : SFVisualElementBase
    {
        
        private Label _packageNameLabel = new Label();
        private Label _packageURLLabel = new Label();

        private TextField _packageReleaseTag = new();

        private SFPackageData _packageData;
        public SFPackageData PackageData 
        {  
            get => _packageData;
            private set => _packageData = value;
        }

        public PackageDataControl()
        {
            
        }

        public PackageDataControl(SFPackageData packageData)
        {
            PackageData = packageData;
            
            _packageNameLabel.text = "Package Name: " + packageData.PackageName;
            _packageURLLabel.text = "Package Git Url: " + packageData.FullPackageURL;
            
            this.AddChild(_packageNameLabel)
                .AddChild(_packageURLLabel)
                .AddChild(_packageReleaseTag);

            this.SetAllBorders(1, Color.black);
            
            RegisterEvents();

        }


        private void RegisterEvents()
        {
            _packageReleaseTag.RegisterValueChangedCallback(OnReleaseTagValueChanged);
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

#else

    // This is if the SF UIElements package has not been pulled in yet.
    public partial class PackageDataControl : VisualElement
    {
        public PackageDataControl(){}
    }
#endif
}
