﻿using HarmonyLib;

using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace HousesCalradia.Patches
{
    /// <summary>
    /// Disable periodic, untargeted, unfiltered AI marriages added in e1.5.5, as it's a redundant
    /// and inferior system to the one in Houses of Calradia.
    /// </summary>
    [HarmonyPatch(typeof(RomanceCampaignBehavior))]
    internal static class RomanceCampaignBehaviorPatch
    {
        [HarmonyPrefix]
        [HarmonyPriority(Priority.VeryHigh)]
        [HarmonyPatch("CheckNpcMarriages")]
        private static bool CheckNpcMarriages(Clan consideringClan) => false;
    }
}