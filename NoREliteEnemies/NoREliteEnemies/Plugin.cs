using BepInEx;
using UnityEngine;

namespace NoREliteEnemies
{
    [global::BepInEx.BepInPlugin("NoREliteEnemiesMod", "[twitter @Dru9Dealer] NoR_EEnemiesMod", "1.0.0")]
    [global::BepInEx.BepInProcess("NightofRevenge.exe")]
    public class Plugin : global::BepInEx.BaseUnityPlugin
    {
        private void Awake()
        {
            Log = base.Logger;
            // Enemies
            EliteSpawnChance = base.Config.Bind<float>("Enemies", "EliteSpawnChance", 1f, "Chance for an enemy to spawn as an elite from 0 to 1");
            EliteHPMult = base.Config.Bind<float>("Enemies", "EliteHPMult", 1f, "Enemies have random Hp multiplier from 1 + (PlayerLEvel / 10) to 1 + (PlayerLEvel / 10 * HPMultiplier)");
            EliteXpMult = base.Config.Bind<float>("Enemies", "EliteXpMult", 1f, "Elites have their EXP multiplied by this value");
            EliteColor = base.Config.Bind<string>("Enemies", "Color", "#ffffff", "Elites cab be tinted this color (#550055), by default color is transparent");
            // Patching
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(NoREliteEnemies.PlayerConPatch), null);
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(NoREliteEnemies.EnemyDatePatch), null);
            LoggerMessage01 = "[Twitter @Dru9Dealer] Elite Enemies Mod";
        }

        private void Update()
        {
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
            LogDat1.rectangle = new global::UnityEngine.Rect(10f + 350f, 90, 350f, 24f);
        }

        // Enemies configs
        public static BepInEx.Configuration.ConfigEntry<float> EliteSpawnChance;
        public static BepInEx.Configuration.ConfigEntry<float> EliteHPMult;
        public static BepInEx.Configuration.ConfigEntry<float> EliteXpMult;
        public static BepInEx.Configuration.ConfigEntry<string> EliteColor;
        // Debug
        internal static global::BepInEx.Logging.ManualLogSource Log;

        // Player stats
        public static PlayerStatus mPlayerstaus = null;
        public static playercon mPlayercon = null;

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
