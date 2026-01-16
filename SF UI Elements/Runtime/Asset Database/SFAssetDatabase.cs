using System.Collections.Generic;

using UnityEngine;

namespace SF.DataAssets
{
    [CreateAssetMenu(fileName = "SF Group Database", menuName = "SF/SF Group Database")]
    public class SFAssetDatabase : ScriptableObject
    {
        // Not using  adictionary because of serialization work arounds I would have to deal with when binding serialized objects to the editor UI.

        public List<SFDataGroup> DataGroups = new();


        public void GetDataGroup(int dataGroup)
        {

        }
    }
}