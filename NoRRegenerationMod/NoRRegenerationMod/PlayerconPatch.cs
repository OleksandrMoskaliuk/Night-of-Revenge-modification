using NoRregeneration;

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

        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "CreampieKakidasu")]
        [global::HarmonyLib.HarmonyPostfix]
        private static void ManualEroDown(global::playercon __instance, PlayerStatus ___playerstatus, ref float ___key_vertical,
            ref bool ___key_submit ,ref bool ___eroflag2,  ref bool ___stabnow, ref bool ___Death)
        {
            if (__instance.erodown == 0 && !__instance.eroflag && !___eroflag2 && !___stabnow && !___Death)
            {
                __instance.ImmediatelyERO();
            }
        }
    }




}
