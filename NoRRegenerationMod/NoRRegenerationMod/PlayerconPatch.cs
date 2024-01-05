using NoRregeneration;
using UnityEngine;

namespace NoRRegeneration
{

    internal class PlayerConPatch
    {
        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "Start")]
        [global::HarmonyLib.HarmonyPostfix]
        private static void StartFunctionPatch(global::playercon __instance, PlayerStatus ___playerstatus)
        {
            // Get all components for update
            Plugin.mPlayerstaus = ___playerstatus;
            Plugin.mPlayercon = __instance;
        }
    }
}
