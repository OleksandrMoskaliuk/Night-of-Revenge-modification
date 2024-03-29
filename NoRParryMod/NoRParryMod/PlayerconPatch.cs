﻿using System;
using UnityEngine;

namespace NoRParryMod
{

    internal class PlayerConPatch
    {
        // Postfix version of  NoResetGuardOnParry
        // will execute after guard_fun original function
        // Perry will reset block time
        // On bad timing parry get perfect block instead damage 
        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "guard_fun")]
        [global::HarmonyLib.HarmonyPostfix]
        public static void NoResetGuardOnParry(global::playercon __instance, global::PlayerStatus ___playerstatus,
             bool ___key_guard, bool ___Attacknow, int ___stepkind, bool ___nowdamage,
             bool ___magicnow, bool ___Itemuse, bool ___Death, ref bool ___Parry,
             ref float ___parrycount, ref float ___guradcount, float ___key_vertical)
        {
            if (___Parry)
            {
                if (___key_guard && !___Attacknow && ___stepkind == 0 && !___nowdamage && !___magicnow && ___playerstatus._SOUSA && !___Itemuse && !___Death)
                {
                    if (__instance.m_Grounded)
                    {
                        __instance.guard = true;
                        ___parrycount += global::UnityEngine.Time.deltaTime / 2f;
                        if (___guradcount > 0f)
                        {
                            ___guradcount -= global::UnityEngine.Time.deltaTime / 2f;
                            if (___guradcount < 0f)
                            {
                                ___guradcount = 0f;
                            }
                        }
                        if (__instance.justguard < ___playerstatus._GuardCutTime + 0.2f)
                        {
                            __instance.justguard += global::UnityEngine.Time.deltaTime / 2f;
                        }
                        if (___key_vertical > 0.01f && ___parrycount > 0.01f && ___playerstatus.WeaponKind != 5)
                        {
                            ___playerstatus.PleasureParalysisActionPercentage();
                            ___Parry = true;
                            ___parrycount = 0f;

                        }
                    }
                    else if (!__instance.m_Grounded)
                    {
                        __instance.guard = false;
                        __instance.justguard = 0f;
                        ___parrycount = 0f;
                        ___guradcount = 0f;
                    }

                }
                else
                {
                    __instance.guard = false;
                    __instance.justguard = 0f;
                    ___guradcount = 0f;
                }
            }

        }


        // Rest attack when guard button is pressedd, prefix patch function
        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "guard_fun")]
        [global::HarmonyLib.HarmonyPrefix]
        public static void ResetAttackOnGuard(global::playercon __instance, global::PlayerStatus ___playerstatus,
             bool ___key_guard, bool ___Attacknow, int ___stepkind, bool ___nowdamage,
             bool ___magicnow, bool ___Itemuse, bool ___Death, ref bool ___Parry,
             ref float ___parrycount, ref float ___guradcount, float ___key_vertical)
        {
            // Immidietely skip attack while guard is pressed
            if (___key_guard && ___Attacknow && ___stepkind == 0 && !___nowdamage && !___magicnow && ___playerstatus._SOUSA && !___Itemuse && !___Death)
            {
                __instance.Actstate = false;
                __instance.Atkcount = 0;
                __instance.Attacknow = false;
                __instance.Atkcombo = 0;
                __instance.tough = __instance.maxtough;
            }

        }

        // Fast skip magic cast
        [global::HarmonyLib.HarmonyPatch(typeof(global::playercon), "magicdata_fun")]
        [global::HarmonyLib.HarmonyPostfix]
        public static void SkipMagickCastOnGuard(global::playercon __instance, global::PlayerStatus ___playerstatus,
             bool ___key_guard, bool ___Attacknow, int ___stepkind, bool ___nowdamage,
             bool ___magicnow, bool ___Itemuse, bool ___Death, ref bool ___Parry,
             ref float ___parrycount, ref float ___guradcount, float ___key_vertical, ref bool ___magicfire , ref float ___mgcount , ref int ___magicdatanum,
             ref GameObject ___MagicSpellCanvas)
        {
            if (___key_guard)
            {
                ___MagicSpellCanvas.SetActive(false);
                __instance.magicnow = false;
                __instance.Actstate = false;
                ___magicfire = false;
                ___mgcount = 0f;
                __instance.tough = __instance.maxtough;
                ___playerstatus.PleasureParalysisActionPercentage();
            }
        }


        // Token: 0x06000012 RID: 18 RVA: 0x00002073 File Offset: 0x00000273
        public PlayerConPatch()
        {
        }
    }
}
