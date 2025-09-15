using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScreenAndOverlaySystem.UI.UIAnimations
{
    public class AnimatedClickable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        RectTransform _rectTransform;
        private Tween _tween;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            _tween.Kill();
            _tween = _rectTransform.DOScale(Vector3.one, 0.01f).SetLink(gameObject);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _tween.Kill();
            _tween = _rectTransform.DOScale(Vector3.one * 0.9f, 0.1f).SetLink(gameObject);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _tween.Kill();
            _tween = _rectTransform.DOScale(Vector3.one * 1f, 0.1f).SetLink(gameObject);
        }
    }
}