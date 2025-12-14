using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SFEditor.Core.Utilities
{
    public class HubIconUtilities
    {
        
        /// <summary>
        /// The path to the root folder with the SF Core Hub icons in it. This includes PNGs and SVGs.
        /// </summary>
        public const string IconPath = "Packages/com.shatter-fantasy.sf-core/Editor/Editor Icons/";
        
        public static readonly VectorImage ReleaseNotesIcon;
        public const string ReleaseNotesIconPath = IconPath + "Release Notes Icon.svg";
        
        static HubIconUtilities()
        {
            ReleaseNotesIcon = AssetDatabase.LoadAssetAtPath<VectorImage>(ReleaseNotesIconPath);
        }
    }
}
