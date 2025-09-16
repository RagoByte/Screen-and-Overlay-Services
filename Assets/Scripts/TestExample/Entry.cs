using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.Service_Screen;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestExample
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private ScreenAndOverlayConfig screenAndOverlayConfig;

        private void Awake()
        {
            SV.Register(screenAndOverlayConfig);

            ScreenService screenService = Instantiate(screenAndOverlayConfig.ScreenService);
            DontDestroyOnLoad(screenService.gameObject);
            SV.Register(screenService);

            OverlayService overlayService = Instantiate(screenAndOverlayConfig.OverlayService);
            DontDestroyOnLoad(overlayService.gameObject);
            SV.Register(overlayService);

            DontDestroyOnLoad(Camera.main);
            DontDestroyOnLoad(FindAnyObjectByType<EventSystem>());

            SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.Main);
        }
    }
}