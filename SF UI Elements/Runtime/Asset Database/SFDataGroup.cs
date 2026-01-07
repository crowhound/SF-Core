using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

namespace SF.DataAssets
{
    [CreateAssetMenu(fileName = "SF Data Group", menuName = "SF/Data Categories/Data Group")]
    public class SFDataGroup : ScriptableObject, ICollection<SFDataGroupEntry>
    {

        /// <summary>
        /// When a SFDataGroup is created we just set the newly created SFDataGroup by this,
        /// than increment this value by one.
        /// </summary>
        //private static int NextGroupID = 0;

        public int ID;
        public string Name;

        /*
        /// <summary>
        /// Allows setting wether or not if the Data Group should use a default field when not data entry is found during data retrieval after filtering is done.
        /// </summary>
        [SerializeField] private bool _useDefaultField = true;
        */
        
        /// <summary>
        /// If no file is found when searching in this Data Group after filtering search results, than if this value is not null use it.
        /// </summary>
        public SFDataGroupEntry DefaultDataEntry;


        /* Note since the SFDataGroup is saving a reference to an actual asset, 
         * when that asset is needed we don't need to get the path to that asset. We just need to copy the reference.
         * 
         * We should still have a simple way to get the asset paths though just in case someone has a need for them. 
         * Example you could have a C# class that is a visual element and to keep things organize you have the UXML file that is used for it's structure in the same folder. We could allow getting the C# class path - the file name and extention.
         * 
         * Use stringbuilder though for performance or Spans.
         */

        private List<SFDataGroupEntry> _dataEntries;

        /// <summary>
        /// A cached set of the data entries. This allows for reading back data at a much faster speed.
        /// </summary>
        private ReadOnlyCollection<SFDataGroupEntry> CachedDataEntries;

        
        #region ICollection Interface Implementation

        public int Count => _dataEntries.Count;

        public bool IsReadOnly => true;

        public void Add(SFDataGroupEntry item)
        {
            if(item is null)
            {
                Debug.LogWarning("A null item was being passed into the a SFDataGroup");
                return;
            }
            _dataEntries.Add(item);
            CachedDataEntries = _dataEntries.AsReadOnly();
        }

        public void Clear()
        {
            _dataEntries.Clear();
            // ReadOnlyCollection do not have a clear function. This is for performance reasons.
            CachedDataEntries = null;
        }

        public bool Contains(SFDataGroupEntry item)
        {
            return CachedDataEntries.Contains(item);
        }

        public void CopyTo(SFDataGroupEntry[] array, int arrayIndex)
        {
            _dataEntries.CopyTo(array, arrayIndex);
            CachedDataEntries = _dataEntries.AsReadOnly();
        }

        public IEnumerator<SFDataGroupEntry> GetEnumerator()
        {
            return CachedDataEntries.GetEnumerator();
        }

        public bool Remove(SFDataGroupEntry item)
        {
            bool wasRemoved = _dataEntries.Remove(item);
            
            // If an item was removed than update the cached collection.
            if(wasRemoved)
                CachedDataEntries = _dataEntries.AsReadOnly();

            return wasRemoved;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CachedDataEntries.GetEnumerator();
        }
        #endregion
    }



}
