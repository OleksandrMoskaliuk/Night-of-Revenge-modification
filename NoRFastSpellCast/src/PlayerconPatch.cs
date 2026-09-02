using UnityEngine;

namespace NoRFastSpellCast
{

    internal class PlayerConPatch
    {

        // Fast magic cast
        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "magic_fun")]
        [global::HarmonyLib.HarmonyPrefix]
        public static void FastMagicCast(global::playercon __instance, global::PlayerStatus ___playerstatus,
             bool ___key_guard, bool ___Attacknow, int ___stepkind, bool ___nowdamage,
             bool ___magicnow, bool ___Itemuse, bool ___Death, ref bool ___Parry,
             ref float ___parrycount, ref float ___guradcount, float ___key_vertical, ref bool ___magicfire, ref float ___mgcount, ref int ___magicdatanum,
             ref GameObject ___MagicSpellCanvas)
        {
            if (!__instance.nowdamage)
            {
                ___mgcount += ___playerstatus.Magicdata[__instance.maginumberfrag].cooltime * 0.6f * Time.deltaTime;
            }
        }


        // Token: 0x06000012 RID: 18 RVA: 0x00002073 File Offset: 0x00000273
        public PlayerConPatch()
        {
        }
    }
}
