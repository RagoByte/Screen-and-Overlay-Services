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

        public async UniTask Open()
        {
            await OnOpen();
        }

        public async UniTask Close()
        {
            await OnClose();
            Destroy(gameObject);
        }
    }
}