using SF.UIElements.Utilities;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

namespace SFEditor.Core
{
    [UxmlElement]
    public partial class HubWelcomeView : VisualElement
    {
        public const string USSClassName = "hub-welcome__view";
        
        public HubWelcomeView()
        {
            this.AddChild(
                        new Label("<a href='https://crowhound.github.io/SF-Platformer/api/SF.Physics.CollisionInfo.html'> Welcome to the Shatter Fantasy Hub. </a>")
                            .AddCallback<Label,PointerDownLinkTagEvent>(OnWelcomeLinkClicked)
                    )
                .name = USSClassName;
            
            // Visual Elements needed.
            
            /*
             *  Label: Welcome message
             *  Link: Link to documentation
             *  Link: to GitHub repos
             */
            
            
        }
        
        private void OnWelcomeLinkClicked(PointerDownLinkTagEvent evt)
        {
            Debug.Log("Clicking on hyper text.");
            Application.OpenURL(evt.linkText);
        }
    }
}
