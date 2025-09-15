using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Screen;

namespace TestExample.Screens
{
    public class CreditsScreen : Screen
    {
        public override ScreenIdentifier ID { get; } = ScreenIdentifier.Credits;

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