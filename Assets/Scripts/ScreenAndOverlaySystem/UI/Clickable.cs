using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScreenAndOverlaySystem.UI
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        public Action ActionOnClicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            ActionOnClicked?.Invoke();
        }

        private void OnDestroy()
        {
            ActionOnClicked = null;
        }
    }
}