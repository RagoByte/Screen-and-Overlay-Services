using Cysharp.Threading.Tasks;
using DG.Tweening;
using ScreenAndOverlaySystem.Service_Screen;
using TMPro;
using UnityEngine;

namespace TestExample.Views
{
    public class CreditsView : BaseView
    {
        [SerializeField] private TextMeshProUGUI creditsText;


        private string[] credits = new string[]
        {
            "=== CREDITS ===",
            "Lead Developer: Me",
            "Bug Creator: Me",
            "Coffee Provider: Vending Machine",
            "Engine: Unity (please don't crash)",
            "Inspiration: Cyber Kirill",
            "Kernel Consultant: Linus Torvalds",
            "QA Tester: Nobody (it works on my machine)",
            "Special Thanks: ChatGPT",
            "Project Manager: TODO()",
            "=== THE END ==="
        };

        protected override UniTask OnOpen()
        {
            UpdateView();

            return UniTask.CompletedTask;
        }

        private void UpdateView()
        {
            creditsText.text = string.Join("\n", credits);

            int height = UnityEngine.Screen.height;
            var startPos = new Vector3(creditsText.rectTransform.position.x, height * 1.5f, creditsText.rectTransform.position.z);
            creditsText.rectTransform.position = startPos;

            creditsText.rectTransform
                .DOMoveY(-height * 0.5f, 20)
                .SetLoops(-1, LoopType.Restart)
                .SetLink(gameObject);
        }

        protected override UniTask OnClose()
        {
            return UniTask.CompletedTask;
        }
    }
}