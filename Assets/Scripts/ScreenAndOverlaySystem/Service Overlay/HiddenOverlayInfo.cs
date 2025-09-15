using System;
using ScreenAndOverlaySystem.Service_Screen;

namespace ScreenAndOverlaySystem.Service_Overlay
{
    [Serializable]
    public class HiddenOverlayInfo
    {
        public BaseOverlay Overlay { get; private set; }
        public ScreenIdentifier ScreenID { get; private set; }
        public bool WasActive { get; private set; }
        public bool IgnoreQueue { get; private set; }


        public HiddenOverlayInfo(BaseOverlay overlay, ScreenIdentifier screenID, bool wasActive, bool ignoreQueue)
        {
            Overlay = overlay;
            ScreenID = screenID;
            WasActive = wasActive;
            IgnoreQueue = ignoreQueue;
        }
    }
}