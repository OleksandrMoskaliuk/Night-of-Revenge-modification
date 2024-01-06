using UnityEngine;

namespace NoRregeneration
{
    [global::BepInEx.BepInPlugin("NoRregeneration", "[twitter @Dru9Dealer] NoRregeneration", "1.0.0")]
    [global::BepInEx.BepInProcess("NightofRevenge.exe")]
    public class Plugin : global::BepInEx.BaseUnityPlugin
    {
        private void Awake()
        {
            Log = base.Logger;
            // Regeneration
            RegenerationMultiplier = base.Config.Bind<float>("Regeneration", "RegenerationMultiplier", 1f, "Regeneration multiplier from all sources: " +
                "(Level/5 * RegenerationMultiplier) + " +
                "(BirthCount/10 * RegenerationMultiplier) + " +
                 "(RapeCount/100 * RegenerationMultiplier) + " +
                  "(TotalCumVolume/1000 * RegenerationMultiplier) + ");
            global::HarmonyLib.Harmony.CreateAndPatchAll(typeof(global::NoRRegeneration.PlayerConPatch), null);
            Plugin.LoggerMessage01 = "[Twitter @Dru9Dealer] Regeneration mod enable";
        }

        private void Update()
        {
            if (mPlayerstaus != null && mPlayercon != null)
            {
                // Passive regeneration
                float Level = (float)mPlayerstaus.LV / 10f;
                float BirthCount = (float)mPlayerstaus.HaramiCount / 10f;
                float RapeCount = (float)mPlayerstaus.RapeCount / 100f;
                float TotalCumVolume = mPlayerstaus.NakadashiValue / 1000f;
                float TotalRegenSource = BirthCount + RapeCount + TotalCumVolume + Level;
                float RegenerationStrength = RegenerationFromSource(TotalRegenSource);

                bool PassiveRegenCondition = !mPlayercon.Attacknow && !mPlayercon.Actstate
                    && !mPlayercon.stepfrag && !mPlayercon.magicnow
                    && global::UnityEngine.Time.timeScale != 0f;
                // Health and pleasure regeneration
                if (mPlayerstaus.Hp < mPlayerstaus.AllMaxHP() && PassiveRegenCondition)
                {
                    mPlayerstaus.Hp += mPlayerstaus.AllMaxHP() * RegenerationStrength * Time.deltaTime;
                    if (mPlayerstaus.Hp < 0f)
                    {
                        mPlayerstaus.Hp = 0f;
                    }
                }
                else  // Regenerete pleasure only when Hp full
                {
                    bool IsStaminaFull = mPlayerstaus.Sp >= mPlayerstaus.AllMaxSP() * 0.99;
                    if (mPlayerstaus._BadstatusVal[0] > 0 && IsStaminaFull && PassiveRegenCondition)
                    {
                        float PleasureRegenerate = 100 * RegenerationStrength * Time.deltaTime;
                        mPlayerstaus._BadstatusVal[0] -= PleasureRegenerate;
                        if (mPlayerstaus._BadstatusVal[0] < 0f)
                        {
                            mPlayerstaus._BadstatusVal[0] = 0f;
                        }
                    }
                }
                // Stamina and mana regeneration
                if (mPlayerstaus.Sp < mPlayerstaus.AllMaxSP() && PassiveRegenCondition)
                {
                    mPlayerstaus.Sp += mPlayerstaus.AllMaxSP() * RegenerationStrength * Time.deltaTime;
                    if (mPlayerstaus.Sp < 0f)
                    {
                        mPlayerstaus.Sp = 0f;

                    }
                }
                else // Regenerete mana only if sp full
                {
                    if (mPlayerstaus.Mp < mPlayerstaus.AllMaxMP() && PassiveRegenCondition)
                    {
                        float ManaRegen = mPlayerstaus.AllMaxMP() * RegenerationStrength * Time.deltaTime;
                        float SpRegen = mPlayerstaus.AllMaxSP() * RegenerationStrength * Time.deltaTime;
                        mPlayerstaus.Mp += ManaRegen + SpRegen; 

                        if (mPlayerstaus.Mp < 0f)
                        {
                            mPlayerstaus.Mp = 0f;
                        }
                    }
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

        private float RegenerationFromSource(float source)
        {
            float Regeneration = (float)(0.2f * global::System.Math.Log(0.2 * source + 1.0) *
                (1.0 * global::System.Math.Pow(source, 0.5) + 2.71828182846f) + -1.9 * global::System.Math.Pow(1.0, source) + 1.9) / 25f;
            return Regeneration;
        }

        public Plugin()
        {
            // Logger 01
            LogDat1.LastMessage = LoggerMessage01;
            LogDat1.rectangle = new global::UnityEngine.Rect(10f, 10, 350f, 24f);

            mPlayercon = null;
            mPlayerstaus = null;
        }

        public static BepInEx.Configuration.ConfigEntry<float> RegenerationMultiplier;

        internal static global::BepInEx.Logging.ManualLogSource Log;

        public static playercon mPlayercon = null;
        public static PlayerStatus mPlayerstaus = null;

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

