using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Overlay
{
    public class LoadingOverlay : BaseOverlay, IOpenable
    {
        //animation
        [SerializeField] private TextMeshProUGUI animationText;
        private float _time;
        private int _countOfDots;

        protected override UniTask OnOpen()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }

        async UniTask IOpenable.Open()
        {
            gameObject.SetActive(true);
            gameObject.transform.SetAsLastSibling();
        }

        async UniTask IOpenable.Close()
        {
            await UniTask.Delay(650);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            AnimationUpdating();
        }

        private void AnimationUpdating()
        {
            _time += Time.deltaTime;
            if (_time < 0.15f) return;

            _time = 0;
            _countOfDots = (_countOfDots + 1) % 4;
            animationText.text = new string('.', _countOfDots);
        }
    }
}