using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ScreenAndOverlaySystem.Service_Screen
{
    public class ScreenService : MonoBehaviour
    {
        private List<ScreenIdentifier> _openedScreenIDs = new List<ScreenIdentifier>();
        public Action OnStartLoadScreen;
        public Action OnEndLoadScreen;
        private Screen _currentScreen;

        [SerializeField] private List<Screen> screensPrefabs = new List<Screen>();

        public ScreenIdentifier CurrentScreenID
        {
            get
            {
                if (_currentScreen == null) return ScreenIdentifier.Main;
                return _currentScreen.ID;
            }
        }

        public async UniTask OpenPreviousScreen()
        {
            if (_openedScreenIDs.Count > 1)
            {
                ScreenIdentifier currentScreenID = _currentScreen.ID;
                ScreenIdentifier previousScreenID = _openedScreenIDs[^2];
                await OpenScreen(previousScreenID);
                _openedScreenIDs.Remove(currentScreenID);
            }
            else
            {
                await OpenScreen(ScreenIdentifier.Main);
            }
        }

        public async UniTask OpenScreen(ScreenIdentifier screenID)
        {
            OnStartLoadScreen?.Invoke();

            if (_currentScreen) await _currentScreen.Close();
            if (screenID == ScreenIdentifier.Main) _openedScreenIDs.Clear();
            if (_openedScreenIDs.Contains(screenID)) _openedScreenIDs.Remove(screenID);

            _openedScreenIDs.Add(screenID);

            _currentScreen = CreateScreen(screenID, transform);
            await _currentScreen.Open();
            OnEndLoadScreen?.Invoke();
        }

        private Screen CreateScreen(ScreenIdentifier screenID, Transform parent)
        {
            foreach (var scr in screensPrefabs)
            {
                if (scr.ID == screenID)
                {
                    return Instantiate(scr, parent);
                }
            }

            return null;
        }
    }
}