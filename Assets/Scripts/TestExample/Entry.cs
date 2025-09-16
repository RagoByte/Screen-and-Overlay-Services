using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.Service_Screen;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestExample
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private Config config;

        private void Awake()
        {
            ScreenService screenService = Instantiate(config.ScreenService);
            DontDestroyOnLoad(screenService.gameObject);
            SV.Register(screenService);

            OverlayService overlayService = Instantiate(config.OverlayService);
            DontDestroyOnLoad(overlayService.gameObject);
            SV.Register(overlayService);

            DontDestroyOnLoad(Camera.main);
            DontDestroyOnLoad(FindAnyObjectByType<EventSystem>());

            SV.Get<ScreenService>().OpenScreen(ScreenIdentifier.Main);
        }
    }
}