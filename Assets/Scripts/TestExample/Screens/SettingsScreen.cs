using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Screen;

namespace TestExample.Screens
{
    public class SettingsScreen : Screen
    {
        public override ScreenIdentifier ID { get; } = ScreenIdentifier.Settings;

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