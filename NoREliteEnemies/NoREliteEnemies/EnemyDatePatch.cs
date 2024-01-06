using Spine.Unity;

namespace NoREliteEnemies
{
    internal class EnemyDatePatch
    {

        // Token: 0x06000008 RID: 8 RVA: 0x00002188 File Offset: 0x00000388
        [global::HarmonyLib.HarmonyPatch(typeof(global::Arulaune), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BigMerman), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Bigoni), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BlackMafia), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BlackOoze_Monster), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Cocoonman), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Coolmaiden), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingCreatures), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingDead), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingSisterKnight), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrowInquisition), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::goblin), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Gorotuki), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::HighInquisition_famale), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Inquisition), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::InquisitionRED), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::InquisitionWhite), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Kinoko), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Librarian), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Mafiamuscle), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Minotaurosu), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::MummyDog), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::MummyMan), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Mutude), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::OtherSlavebigAxe), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Pilgrim), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::PrisonOfficer), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::RequiemKnight), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sheepheaddemon), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SinnerslaveCrossbow), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sisiruirui), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sisterknight), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SkeltonOoze), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Slaughterer), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SlaveBigAxe), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Snailshell), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::suraimu), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TouzokuAxe), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TouzokuNormal), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Tyoukyoushi), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TyoukyoushiRed), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Undead), "Start")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Vagrant), "Start")]
        [global::HarmonyLib.HarmonyPostfix]
        private static void SpawnEliteEnemy(global::EnemyDate __instance, global::Spine.Unity.SkeletonAnimation ___mySpine, ref string ___JPname)
        {
            if (Plugin.mPlayerstaus != null)
            {
                if (Plugin.EliteSpawnChance.Value > UnityEngine.Random.Range(0f, 1))
                {
                    ___JPname += "<ELITE>";
                    float Lv = Plugin.mPlayerstaus.LV;
                    float HpMulti = UnityEngine.Random.Range(1f, 1f + (Lv / 10f * Plugin.EliteHPMult.Value));
                    __instance.Hp = __instance.MaxHp *= HpMulti;
                    __instance.Exp = global::UnityEngine.Mathf.RoundToInt(__instance.Exp * HpMulti * Plugin.EliteXpMult.Value);
                    global::UnityEngine.Color color;
                    if (UnityEngine.ColorUtility.TryParseHtmlString(Plugin.EliteColor.Value, out color))
                    {
                        ___mySpine.skeleton.SetColor(color);
                    }
                }
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x0000223C File Offset: 0x0000043C
        [global::HarmonyLib.HarmonyPatch(typeof(global::Arulaune), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BigMerman), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Bigoni), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BlackMafia), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::BlackOoze_Monster), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Cocoonman), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Coolmaiden), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingCreatures), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingDead), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrawlingSisterKnight), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::CrowInquisition), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::goblin), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Gorotuki), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::HighInquisition_famale), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Inquisition), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::InquisitionRED), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::InquisitionWhite), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Kinoko), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Librarian), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Mafiamuscle), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Minotaurosu), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::MummyDog), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::MummyMan), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Mutude), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::OtherSlavebigAxe), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Pilgrim), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::PrisonOfficer), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::RequiemKnight), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sheepheaddemon), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SinnerslaveCrossbow), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sisiruirui), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Sisterknight), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SkeltonOoze), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Slaughterer), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::SlaveBigAxe), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Snailshell), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::suraimu), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TouzokuAxe), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TouzokuNormal), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Tyoukyoushi), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::TyoukyoushiRed), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Undead), "reste")]
        [global::HarmonyLib.HarmonyPatch(typeof(global::Vagrant), "reste")]
        [global::HarmonyLib.HarmonyPrefix]
        private static bool SuperEnemyColor(global::EnemyDate __instance, global::Spine.Unity.SkeletonAnimation ___mySpine, string ___JPname)
        {
            if (___JPname.Contains("<ELITE>"))
            {
                global::UnityEngine.Color color;
                if (UnityEngine.ColorUtility.TryParseHtmlString(Plugin.EliteColor.Value, out color))
                {
                    ___mySpine.skeleton.SetColor(color);
                    return false;
                }
            }
            return true;
        }
        public EnemyDatePatch()
        {
        }
    }
}

