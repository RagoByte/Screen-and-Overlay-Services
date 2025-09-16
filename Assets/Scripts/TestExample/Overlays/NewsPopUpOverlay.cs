using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem;
using ScreenAndOverlaySystem.Service_Overlay;
using TMPro;
using UnityEngine;
using Clickable = ScreenAndOverlaySystem.UI.Clickable;

namespace TestExample.Overlays
{
    public class NewsPopUpOverlay : BaseOverlay
    {
        [SerializeField] private TextMeshProUGUI newsText;
        [SerializeField] Clickable closeButton;

        protected override UniTask OnOpen()
        {
            newsText.text = "2228 year. Unity 7 is coming soon! Stay tuned for more updates.";

            closeButton.ActionOnClicked += () => ((IOpenable)this).Close();
            return UniTask.CompletedTask;
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }
    }
}