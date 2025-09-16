using ScreenAndOverlaySystem.Service_Overlay;
using ScreenAndOverlaySystem.Service_Screen;
using UnityEngine;

namespace TestExample
{
    [CreateAssetMenu(fileName = "ScreenAndOverlayConfig", menuName = "ScreenAndOverlayConfig")]
    public class Config : ScriptableObject
    {
        [field: SerializeField, Header(" Services ")] public ScreenService ScreenService { get; private set; }
        [field: SerializeField] public OverlayService OverlayService { get; private set; }
    
    }
}