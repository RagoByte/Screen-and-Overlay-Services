using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Screen
{
    public abstract class Screen : MonoBehaviour, IOpenable
    {
        public abstract ScreenIdentifier ID { get; }
        [SerializeField] private BaseView _defaultView;
        private BaseView _currentView;

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
            _currentView = Instantiate(_defaultView, transform);
            await ((IOpenable)_currentView).Open();
        }

        async UniTask IOpenable.Close()
        {
            if (_currentView != null)
            {
                await ((IOpenable)_currentView).Close();
            }

            await OnClose();
            Destroy(gameObject);
        }
    }
}