using System;
using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.UI;
using TMPro;
using UnityEngine;

namespace TestExample.Overlays
{
    public class CurrentTimePopUpOverlay : BaseOverlay
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] Clickable closeButton;
        private int _lastSecond = -1;

        protected override UniTask OnOpen()
        {
            closeButton.ActionOnClicked += () => Close();
            return UniTask.CompletedTask;
        }

        private void Update()
        {
            var now = DateTime.Now;
            if (now.Second != _lastSecond)
            {
                _lastSecond = now.Second;
                timeText.text = now.ToString("HH:mm:ss");
            }
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }
    }
}