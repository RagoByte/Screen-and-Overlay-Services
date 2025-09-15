using ScreenAndOverlaySystem.Service_Screen;

namespace TestExample
{
    public class Game
    {
        public void Init()
        {
            SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.Main);
        }
    }
}