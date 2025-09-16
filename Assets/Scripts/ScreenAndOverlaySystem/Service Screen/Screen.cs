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

        public async UniTask Open()
        {
            await OnOpen();
            _currentView = Instantiate(_defaultView, transform);
            await _currentView.Open();
        }

        public async UniTask Close()
        {
            if (_currentView != null)
            {
                await _currentView.Close();
            }

            await OnClose();
            Destroy(gameObject);
        }
    }
}