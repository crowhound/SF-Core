using UnityEditor;
using UnityEditor.UIElements;

using UnityEngine;
using UnityEngine.UIElements;

using SF.DataAssets;


namespace SFEditor.DataAssets.UIElements
{

    public class SFAssetDatabaseEditor : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [SerializeField] private SFAssetDatabase _assetDatabase;

        private VisualElement _root;
        private ListView _categoryListView;
        
        /*
        [MenuItem("SF/Editor/Asset Database")]
        public static void ShowExample()
        {
            SFAssetDatabaseEditor wnd = GetWindow<SFAssetDatabaseEditor>();
            wnd.titleContent = new GUIContent("SF Asset Database");
        }
        */
        

        public void CreateGUI()
        {
            _root = rootVisualElement;

            VisualElement _windowTemplate = m_VisualTreeAsset.Instantiate();
            _root.Add(_windowTemplate);

            _categoryListView = _root.Q<ListView>("category__list-view");
            _categoryListView.dataSource = _assetDatabase.DataGroups;
            _categoryListView.makeItem += MakeCategoryList;

            if(_assetDatabase != null)
            {
                _root.Bind(new SerializedObject(_assetDatabase));
            }
        }

        private VisualElement MakeCategoryList()
        {
            return new Label("Data Group");
        }
    }
}