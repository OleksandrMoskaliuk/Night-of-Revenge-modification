using UnityEngine;

namespace NoRBerserkMod
{
    [global::BepInEx.BepInPlugin("NoRBerserkMod", "[twitter @Dru9Dealer] NoR_BerserkMod", "1.0.0")]
    [global::BepInEx.BepInProcess("NightofRevenge.exe")]
    public class Plugin : global::BepInEx.BaseUnityPlugin
    {
        private void Awake()
        {
            Plugin.DashMult = base.Config.Bind<float>("Dash", "DashMult", 1.4f, "Multiplier for dash distance, which scales linearly from 1.0 at full health to 1.4 at 0% health");
            Plugin.DamageMult = base.Config.Bind<float>("Damage", "DamageMult", 2f, "Multiplier for damage dealt, which scales linearly from 1.0 at full health to 2.0 at 0% health");
            Plugin.AtkSpeedMult = base.Config.Bind<float>("Speed", "AtkSpeedMult", 2f, "Multiplier for attack speed, which scales linearly from 1.0 at full health to 2.0 at 0% health");
            Plugin.DamageResistMult = base.Config.Bind<float>("Resistance", "DamageResistMult", 2f, "Multiplier to increase resistance to damage, which scales linearly from 1.0 at full health to 2.0 at 0% health");
            Plugin.PleasureSkipMult = base.Config.Bind<float>("Pleasure", "PleasureSkipMult", 2.5f, "Multiplier for pleasure reduction on hit, which scales linearly from 1.0 at full health to 2.5 at 0% health");
            Plugin.SpRegenMult = base.Config.Bind<float>("Stamina", "SpRegenMult", 2f, "Multiplier for SP regeneration, which scales linearly from 1.0 at normal stamina to 2.0 at low stamina");
            Log = base.Logger;
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(global::NoRBerserkMod.EnemyDatePatch), null);
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(global::NoRBerserkMod.PlayerConPatch), null);
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(global::NoRBerserkMod.PlayerStatusPatch), null);
            LoggerMessage01 = "[Twitter @Dru9Dealer] Berserk mod enable";
        }

        private void Update()
        {
            if (mPlayerstatus != null && mPlayercon != null)
            {
                float LostHp = 1 - (mPlayerstatus.Hp / mPlayerstatus.AllMaxHP());
                if (mPlayerstatus.Sp < mPlayerstatus.AllMaxSP() && !mPlayerstatus && !mPlayerstatus && !mPlayerstatus && !mPlayerstatus && Time.timeScale != 0f)
                {
                    if (!mPlayercon.guard)
                    {
                        float Max = mPlayerstatus.AllMaxSP() / 2f * Time.deltaTime * Plugin.SpRegenMult.Value;
                        float Min = 0;
                        mPlayerstatus.Sp += UnityEngine.Mathf.Lerp(Min, Max, LostHp);
                    }
                    else
                    {
                        float Max = mPlayerstatus.AllMaxSP() / 7.5f * Time.deltaTime * Plugin.SpRegenMult.Value;
                        float Min = 0;
                        mPlayerstatus.Sp += UnityEngine.Mathf.Lerp(Min, Max, LostHp);
                    }
                }
                if (mPlayerstatus.Sp < 0f)
                {
                    mPlayerstatus.Sp = 0f;
                }

            }
        }

        private void OnGUI()
        {
            HandleLoggers(true);
        }

        private void HandleLoggers(bool on)
        {
            if (!on) { return; }

            // Logger 01            
            if (LogDat1.TimeRamained > 0)
            {
                global::UnityEngine.GUI.Box(LogDat1.rectangle, " " + LoggerMessage01);
                LogDat1.LastMessage = LoggerMessage01;
                LogDat1.TimeRamained -= UnityEngine.Time.deltaTime;
            }
            // Update time if new message was assigned
            if (!LoggerMessage01.Equals(LogDat1.LastMessage))
            {
                // Prevents messages flickering
                if (LogDat1.TimeRamained > (10f - 0.8f))
                {
                    LoggerMessage01 = LogDat1.LastMessage;
                }
                else
                {
                    LogDat1.TimeRamained = 10f;
                }
            }


        }

        public Plugin()
        {
            // Logger 01
            LogDat1.LastMessage = LoggerMessage01;
            LogDat1.rectangle = new global::UnityEngine.Rect(10f + 350f, 10, 350f, 24f);
        }
        public static global::BepInEx.Configuration.ConfigEntry<float> DashMult;
        public static global::BepInEx.Configuration.ConfigEntry<float> DamageMult;
        public static global::BepInEx.Configuration.ConfigEntry<float> AtkSpeedMult;
        public static global::BepInEx.Configuration.ConfigEntry<float> DamageResistMult;
        public static global::BepInEx.Configuration.ConfigEntry<float> PleasureSkipMult;
        public static global::BepInEx.Configuration.ConfigEntry<float> SpRegenMult;


        internal static global::BepInEx.Logging.ManualLogSource Log;

        static public PlayerStatus mPlayerstatus = null;
        static public playercon mPlayercon = null;
        private Rewired.Player mPlayer = null;

        // Logger 01
        public static string LoggerMessage01;
        private LogData LogDat1;

    }
    // Data for Logging messages
    public struct LogData
    {
        public Rect rectangle;
        public string LastMessage;
        public float TimeRamained;
    }
}
