using Cysharp.Threading.Tasks;

namespace ScreenAndOverlaySystem
{
    public interface IOpenable
    {
        UniTask Open();
        UniTask Close();
    }
}