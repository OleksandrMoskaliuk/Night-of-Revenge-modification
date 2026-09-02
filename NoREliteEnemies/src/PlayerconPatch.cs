using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoREliteEnemies
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
