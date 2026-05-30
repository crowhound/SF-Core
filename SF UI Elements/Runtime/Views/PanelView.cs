using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace SF.UIModule
{
    
    /// <summary>
    /// Represents a possible runtime sub-view, sub-menu, or anything else that has a <see cref="PanelRenderer"/> for the rendering component.
    /// The PanelView acts as the container of a specific set of <see cref="VisualElement"/>.
    /// that have their own set of elements.
    /// <example>
    /// InventoryView to display a games inventory and SettingsView for displaying the option buttons
    /// that open up the respected menus like graphics,audio, and so forth.
    /// </example> </summary>
    public class PanelView<TPanelController> : IDisposable where TPanelController : PanelController
    {
        public VisualElement RootElement { get; protected set; }
        public bool IsHidden => RootElement?.style.display == DisplayStyle.None;
        [SerializeField] protected bool _hideOnAwake = true;
        
        protected TPanelController _panelController;
        
        /// <summary>
        /// Initialize the and assigns root element from the <see cref="PanelRenderer"/>. 
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="panelController"></param>
        public virtual void Initialize(VisualElement rootElement, TPanelController panelController = null)
        {
            _panelController ??= panelController;
		    
            RootElement = rootElement;

            if(_hideOnAwake)
            {
                Hide();
            }
		    
            //SetVisualElements();
            //RegisterEventCallbacks();
        }
        
        /// <summary>
        /// Shows the defined root element of the <see cref="UIView"/>.
        /// This sets the root element's style display to flex.
        /// </summary>
        public void Show()
        {
            if(RootElement != null)
                RootElement.style.display = DisplayStyle.Flex;
        }

        /// <summary>
        /// Hides the defined root element of the <see cref="UIView"/>.
        /// /// This sets the root element's style display to none.
        /// </summary>
        public void Hide()
        {
            if(RootElement != null)
                RootElement.style.display = DisplayStyle.None;
        }

        /// <summary>
        /// Unregisters any callbacks or event handlers.
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
