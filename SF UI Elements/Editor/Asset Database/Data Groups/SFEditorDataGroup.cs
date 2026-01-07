using SF.DataAssets;

using UnityEditor;

using UnityEngine;

namespace SFEditor.DataAssets
{

    /// <summary>
    /// This is a data container to hold a similar set of assets in one place for easier retrieval 
    /// in editor code or in the Unity Editor inspectors .
    /// 
    /// This is the editor only version of the SF Data Groups.
    /// </summary>
    [CreateAssetMenu(fileName = "SF Editor Data Group", menuName = "SF/Data Categories/Editor Data Group")]
    public class SFEditorDataGroup : SFDataGroup
    {
        // Remove context menu for later.
        [ContextMenu("Print Asset Path.")]
        public string GetFilePath()
        {
            var assetPath = AssetDatabase.GetAssetPath(this);
            Debug.Log(assetPath);
            return assetPath;
        }
    }
}
