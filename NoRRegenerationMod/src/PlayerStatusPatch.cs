using System;
using HarmonyLib;
using UnityEngine;

namespace NoRregeneration
{
    internal class PlayerStatusPatch
    {
        [global::HarmonyLib.HarmonyPatch(typeof(global::PlayerStatus), "_atk_speed", global::HarmonyLib.MethodType.Getter)]
        [global::HarmonyLib.HarmonyPostfix]
        private static void IncreaseAttackSpeed(global::PlayerStatus __instance, ref float __result)
        {
            __result += (__result * Plugin.RegenerationBuff);
        }

        [global::HarmonyLib.HarmonyPatch(typeof(global::PlayerStatus), "_ATK", global::HarmonyLib.MethodType.Getter)]
        [global::HarmonyLib.HarmonyPostfix]
        private static void IncraseAttackDamage(global::PlayerStatus __instance, ref float __result)
        {
            __result += (__result * Plugin.RegenerationBuff);
        }

        public PlayerStatusPatch()
        {
        }
    }
}
