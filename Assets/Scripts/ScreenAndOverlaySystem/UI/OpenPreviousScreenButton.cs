using ScreenAndOverlaySystem.Service_Screen;
using TestExample;

namespace ScreenAndOverlaySystem.UI
{
    public class OpenPreviousScreenButton : Clickable
    {
        private void Awake()
        {
            ActionOnClicked += OpenPreviousScreen;
        }

        private void OpenPreviousScreen()
        {
            SV.Get<ScreenService>().OpenPreviousScreen();
        }
    }
}