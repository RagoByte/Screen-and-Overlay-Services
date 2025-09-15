using ScreenAndOverlaySystem.Service_Screen;
using TestExample;
using UnityEngine;

namespace ScreenAndOverlaySystem.UI
{
    public class OpenScreenButton : Clickable
    {
        [SerializeField] private ScreenIdentifier screenIdToOpen = default;

        private void Awake()
        {
            ActionOnClicked += OpenSettingsScreen;
        }

        private void OpenSettingsScreen()
        {
            SV.Get<ScreenService>().OpenScreen(screenIdToOpen);
        }
    }
}