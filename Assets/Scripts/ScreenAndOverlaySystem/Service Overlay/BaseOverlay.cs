using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Overlay
{
    public abstract class BaseOverlay : MonoBehaviour, IOpenable
    {
        public Action<BaseOverlay> OnClosed;
        bool _wasOpened = false;


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
            if (_wasOpened) return;
            _wasOpened = true;
            gameObject.SetActive(true);
            gameObject.transform.SetAsLastSibling();
            await OnOpen();
        }

        async UniTask IOpenable.Close()
        {
            await OnClose();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnClosed?.Invoke(this);
            OnClosed = null;
        }
    }
}