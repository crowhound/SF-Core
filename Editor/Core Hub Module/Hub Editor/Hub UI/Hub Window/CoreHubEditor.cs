using SF.UIElements;
using SFEditor.Core.Packages;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using SF.UIElements.Utilities;
using SFEditor.Core;
using UnityEngine.UIElements.Experimental;
using static SFEditor.Core.Packages.SFPackageDefaults;
using static SFEditor.UIElements.Utilities.SFUIElementsFactory;

public class CoreHubEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset _hubVisualTreeAsset = default;
    [SerializeField] private StyleSheet _hubStyleSheetAsset = default;

    private VisualElement _hubVisualTemplate;
    
    #region Constant path strings
    private const string PathToHubVisualTree =
        "Packages/com.shatter-fantasy.sf-core/Editor/Core Hub Module/Hub Editor/Hub UI/Hub Window/CoreHubEditor.uxml";
    private const string PathToHubStyleSheet = "Packages/com.shatter-fantasy.sf-core/Editor/Core Hub Module/Hub Editor/Hub UI/Hub Window/CoreHubEditor.uss";
    #endregion
    
    private VisualElement Root => rootVisualElement;
    
    [MenuItem("Tools/SF/CoreHubEditor")]
    public static void ShowEditor()
    {
        CoreHubEditor wnd = GetWindow<CoreHubEditor>();
        wnd.titleContent = new GUIContent("Core Hub");
        wnd.minSize = new Vector2(400, 250);
    }

    public void CreateGUI()
    {
        // TODO: Once the SF package system to auto install the SF UI Toolkit is done use it for adding new UI Elements via C#.
        if (!IsAssetsValid())
        {
            // TODO: Add a Error USS style for text.
            Root.Add(new Label("Check the Unity console logs for a warning. There was an problem validating the editor assets for the SF Core Hub."));
            return;
        }

        _hubVisualTemplate = new();
        
       _hubVisualTreeAsset.CloneTree(_hubVisualTemplate);
       Root.AddChild(_hubVisualTemplate); // Unity's default

       Root.Q<SideBarLayout>().SideBarMenu
           .AddChild(new Button(){text = "Welcome"})
           .AddChild(new Button(){text = "Packages"})
           .AddChild(new Button(){text = "Samples"})
           .AddChild(new Button(){text = "Release Notes"})
           .AddChild(new Button(){text = "Report Bug"});

       Root.Q<VisualElement>(name = "side-bar__container")
           .AddChild(new HubPackageView());
       
       Root.styleSheets.Add(SFCommonStyleSheet);
       
       if(_hubStyleSheetAsset != null)
           Root.styleSheets.Add(_hubStyleSheetAsset);
    }

    private bool IsAssetsValid()
    {
        if (_hubVisualTreeAsset == null)
        {
            _hubVisualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(PathToHubVisualTree);
        }
        
        if (_hubStyleSheetAsset == null)
        {
            _hubStyleSheetAsset = AssetDatabase.LoadAssetAtPath<StyleSheet>(PathToHubStyleSheet);
        }

        if (_hubVisualTreeAsset == null || _hubStyleSheetAsset == null)
        {
            Debug.LogError("When trying to validate the SF CoreHubEditor assets for the asset window ui, an asset was missing or value assigned was null."
                + $"The Hub Visual Tree asset value is: {_hubVisualTreeAsset}."
                + $"The Hub Style Sheet asset value is: {_hubStyleSheetAsset}.");
            return false;
        }
        
        return true;
    }
}
