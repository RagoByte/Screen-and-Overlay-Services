using System.Collections.Generic;
using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.Service_Screen;
using UnityEngine;
using Screen = ScreenAndOverlaySystem.Service_Screen.Screen;

namespace TestExample
{
    [CreateAssetMenu(fileName = "Config", menuName = "Config")]
    public class Config : ScriptableObject
    {
        [field: SerializeField, Header(" Services ")] public ScreenService ScreenService { get; private set; }
        [field: SerializeField] public OverlayService OverlayService { get; private set; }
    
        [field: SerializeField,Header(" Prefabs ")] public List<Screen> ScreensPrefabs { get; private set; }
        [field: SerializeField] public List<BaseOverlay> OverlaysPrefabs { get; private set; }
    }
}