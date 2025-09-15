using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.Service_Screen;
using ScreenAndOverlaySystem.UI;
using TestExample.Overlays;
using UnityEngine;

namespace TestExample.Views
{
    public class SettingsView : BaseView
    {
        [SerializeField] Clickable openNewsButton;
        [SerializeField] Clickable openCurrentTimePopUpButton;

        protected override UniTask OnOpen()
        {
            openNewsButton.ActionOnClicked += OpenNewsOverlay;
            openCurrentTimePopUpButton.ActionOnClicked += OpenCurrentTimePopUp;
            return UniTask.CompletedTask;
        }

        private void OpenCurrentTimePopUp()
        {
            SV.Get<OverlayService>().OpenOverlay<CurrentTimePopUpOverlay>(true);
        }

        private void OpenNewsOverlay()
        {
            SV.Get<OverlayService>().OpenOverlay<NewsPopUpOverlay>();
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }
    }
}