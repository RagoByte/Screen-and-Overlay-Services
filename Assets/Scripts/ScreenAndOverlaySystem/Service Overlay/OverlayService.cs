using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ScreenAndOverlaySystem.Service_Screen;
using TestExample;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Overlay
{
    public class OverlayService : MonoBehaviour
    {
        private List<BaseOverlay> _defaultOverlays = new List<BaseOverlay>();
        private List<BaseOverlay> _ignoreQueueOverlays = new List<BaseOverlay>();
        private List<HiddenOverlayInfo> _hiddenOverlays = new List<HiddenOverlayInfo>();
        private IOpenable _loadingOverlay;

        private ScreenService _screenService;

        [SerializeField] private List<BaseOverlay> overlaysPrefabs = new List<BaseOverlay>();

        private void Awake()
        {
            _screenService = SV.Get<ScreenService>();
            _loadingOverlay = CreateOverlay<LoadingOverlay>(transform);
            Subscribe();
        }

        private void Subscribe()
        {
            _screenService.OnStartLoadScreen += ShowLoadingOverlay;
            _screenService.OnEndLoadScreen += HideLoadingOverlay;

            _screenService.OnStartLoadScreen += HideAllOverlays;
            _screenService.OnEndLoadScreen += ShowHiddenOverlays;
        }

        public async UniTask<T> OpenOverlay<T>(bool ignoreQueue = false) where T : BaseOverlay
        {
            T overlay = CreateOverlay<T>(transform);
            overlay.OnClosed += OnOverlayClosed;


            if (ignoreQueue)
            {
                await overlay.Open();
                _ignoreQueueOverlays.Add(overlay);
            }
            else
            {
                _defaultOverlays.Add(overlay);

                bool isFirstInQueue = _defaultOverlays.Count == 1 && _ignoreQueueOverlays.Count == 0;
                if (isFirstInQueue) await overlay.Open();
            }

            return overlay;
        }

        private T CreateOverlay<T>(Transform parent) where T : BaseOverlay
        {
            T overlayInstance = null;
            foreach (var overlay in overlaysPrefabs)
            {
                if (overlay is T overlayReference)
                {
                    overlayInstance = Instantiate(overlayReference, parent);
                    overlayInstance.gameObject.SetActive(false);
                    break;
                }
            }

            return overlayInstance;
        }

        private void OnOverlayClosed(BaseOverlay overlay)
        {
            if (_ignoreQueueOverlays.Contains(overlay))
            {
                _ignoreQueueOverlays.Remove(overlay);
            }

            if (_defaultOverlays.Contains(overlay))
            {
                _defaultOverlays.Remove(overlay);
            }

            OpenNext();
        }

        private async UniTask OpenNext()
        {
            if (_defaultOverlays.Count > 0 && _ignoreQueueOverlays.Count == 0)
            {
                await _defaultOverlays[0].Open();
            }
        }


        public void ShowLoadingOverlay()
        {
            _loadingOverlay.Open();
        }

        public void HideLoadingOverlay()
        {
            _loadingOverlay.Close();
        }

        public void DestroyAllOverlays()
        {
            if (!(_hiddenOverlays.Count > 0 || _defaultOverlays.Count > 0 || _ignoreQueueOverlays.Count > 0)) return;

            foreach (var simpleOverlay in _defaultOverlays)
            {
                Destroy(simpleOverlay.gameObject);
            }

            foreach (var ignoreOverlay in _ignoreQueueOverlays)
            {
                Destroy(ignoreOverlay.gameObject);
            }

            foreach (var informationOverlay in _hiddenOverlays)
            {
                Destroy(informationOverlay.Overlay.gameObject);
            }

            _defaultOverlays.Clear();
            _ignoreQueueOverlays.Clear();
            _hiddenOverlays.Clear();
        }


        private void HideAllOverlays()
        {
            if (_ignoreQueueOverlays.Count == 0 && _defaultOverlays.Count == 0) return;
            ScreenIdentifier currentScreenID = _screenService.CurrentScreenID;

            void HideList(List<BaseOverlay> overlays, bool ignoreQueue)
            {
                foreach (var overlay in overlays)
                {
                    _hiddenOverlays.Add(new HiddenOverlayInfo(overlay, currentScreenID, overlay.isActiveAndEnabled, ignoreQueue));
                    overlay.gameObject.SetActive(false);
                }

                overlays.Clear();
            }

            HideList(_ignoreQueueOverlays, true);
            HideList(_defaultOverlays, false);
        }

        private void ShowHiddenOverlays()
        {
            if (_hiddenOverlays.Count == 0) return;
            ScreenIdentifier currentScreenID = _screenService.CurrentScreenID;
            List<HiddenOverlayInfo> overlaysToShow = _hiddenOverlays.Where(info => info.ScreenID == currentScreenID).ToList();

            foreach (var info in overlaysToShow)
            {
                if (info.IgnoreQueue)
                    _ignoreQueueOverlays.Add(info.Overlay);
                else
                    _defaultOverlays.Add(info.Overlay);

                info.Overlay.gameObject.SetActive(info.WasActive);
                _hiddenOverlays.Remove(info);
            }
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }

        private void UnSubscribe()
        {
            _screenService.OnStartLoadScreen -= ShowLoadingOverlay;
            _screenService.OnEndLoadScreen -= HideLoadingOverlay;

            _screenService.OnStartLoadScreen -= HideAllOverlays;
            _screenService.OnEndLoadScreen -= ShowHiddenOverlays;
        }
    }
}