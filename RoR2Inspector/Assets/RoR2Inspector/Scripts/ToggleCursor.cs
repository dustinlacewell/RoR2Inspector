using RoR2;

namespace RoR2Inspector
{
    public static class ToggleCursor
    {
        public static void Toggle()
        {
            var pes = MPEventSystemManager.primaryEventSystem;
            pes.cursorOpenerCount = pes.cursorOpenerCount > 0 ? 0 : 1;
        }
    }
}
