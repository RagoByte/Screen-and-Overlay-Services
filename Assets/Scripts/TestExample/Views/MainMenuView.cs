using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Screen;

namespace TestExample.Views
{
    public class MainMenuView : BaseView
    {
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