using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Screen;

namespace ScreenAndOverlaySystem
{
    public class MainMenuScreen : Screen
    {
        public override ScreenIdentifier ID => ScreenIdentifier.Main;
        protected override UniTask OnOpen()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }
    }
}