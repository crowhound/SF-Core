using SF.UIElements.Utilities;
using UnityEngine;
using UnityEngine.UIElements;

namespace SF.UIElements
{
  
    public partial class SFVisualElementBase : VisualElement
    {
        public const string USSClassName = "sf-element";
        /// <summary>
        /// This is the main visual tree asset for the SFVisualElement.
        /// This is mainly used in child classes.
        /// </summary>
        protected VisualTreeAsset _visualTreeAsset;
        protected VisualElement _rootTemplateContainer = new();
        
        public SFVisualElementBase()
        {
            this.AddClass(USSClassName);
        }

        protected virtual void CloneVisualTreeAsset()
        {
            if (_visualTreeAsset == null)
                return;
            
            _visualTreeAsset.CloneTree(_rootTemplateContainer);
            Add(_rootTemplateContainer);
        }
    }
}
