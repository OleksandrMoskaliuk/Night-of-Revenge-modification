using BepInEx;
using UnityEngine;

namespace NoRFastSpellCast
{
    [global::BepInEx.BepInPlugin("NoRFastMagicCast", "[twitter @Dru9Dealer] NoR_FastCast", "1.0.0")]
    [global::BepInEx.BepInProcess("NightofRevenge.exe")]
    public class Plugin : global::BepInEx.BaseUnityPlugin
    {
        private void Awake()
        {
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(global::NoRFastSpellCast.PlayerConPatch), null);
            Plugin.LoggerMessage01 = "[Twitter @Dru9Dealer] FastCast mod enable";
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
                if (LogDat1.TimeRamained > (5f - 0.8f))
                {
                    LoggerMessage01 = LogDat1.LastMessage;
                }
                else
                {
                    LogDat1.TimeRamained = 5f;
                }
            }
        }
        public Plugin()
        {
            // Logger 01
            LogDat1.LastMessage = LoggerMessage01;
            LogDat1.rectangle = new global::UnityEngine.Rect(10f, 240, 350f, 24f);

        }

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

