using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Screen
{
    public abstract class BaseView : MonoBehaviour, IOpenable
    {
        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.localScale = Vector2.one;
        }

        protected abstract UniTask OnOpen();
        protected abstract UniTask OnClose();

        async UniTask IOpenable.Open()
        {
            await OnOpen();
        }

        async UniTask IOpenable.Close()
        {
            await OnClose();
            Destroy(gameObject);
        }
    }
}