﻿using System;
using System.ComponentModel;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace HousesCalradia
{
    public class SubModule : MBSubModuleBase
    {
        /* Semantic Versioning (https://semver.org)
         *
         * In the case of your usual mod, "breaking API compatibility" (major version increment) is save-incompatibility
         * with itself with respect to the prior version. However, if the mod talks to others, that's an actual API too.
         * The rest of the version components function as usual.
         */
        public static readonly int SemVerMajor = 1;
        public static readonly int SemVerMinor = 1;
        public static readonly int SemVerPatch = 3;
        public static readonly string? SemVerSpecial = "beta1";
        private static readonly string SemVerEnd = (SemVerSpecial is null) ? string.Empty : "-" + SemVerSpecial;
        public static readonly string Version = $"{SemVerMajor}.{SemVerMinor}.{SemVerPatch}{SemVerEnd}";

        public static readonly string Name = typeof(SubModule).Namespace;
        public static readonly string DisplayName = "AI贵族联姻"; // to be shown to humans in-game
        public static readonly string HarmonyDomain = "com.zijistark.bannerlord." + Name.ToLower();

        internal static readonly Color ImportantTextColor = Color.FromUint(0x00F16D26); // orange

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            Util.EnableLog = true; // enable various debug logging
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (!hasLoaded)
            {
                Util.Log.Print($"Loading {DisplayName}...");
                bool useMcm = false;

                try
                {
                    if (Settings.Instance is { } settings)
                    {
                        useMcm = true;
                        Util.Log.Print("MCM settings instance found!");

                        // Copy current settings to master config
                        Config.CopyFromSettings(settings);

                        // Register for settings property-changed events
                        settings.PropertyChanged += Settings_OnPropertyChanged;
                    }
                }
                catch (Exception) { }

                if (!useMcm)
                    Util.Log.Print("MCM settings instance NOT found! Using defaults.");

                Util.Log.Print("\nConfiguration:");
                Util.Log.Print(Config.ToStringLines(indentSize: 4));
                Util.Log.Print(string.Empty);

                var harmony = new Harmony(HarmonyDomain);
                harmony.PatchAll();

                Util.Log.Print($"Loaded {DisplayName}!\n");
                InformationManager.DisplayMessage(new InformationMessage($"Loaded {DisplayName}", ImportantTextColor));
                hasLoaded = true;
            }
        }

        protected override void OnGameStart(Game game, IGameStarter starterObject)
        {
            base.OnGameStart(game, starterObject);

            if (game.GameType is Campaign)
            {
                var initializer = (CampaignGameStarter)starterObject;
                initializer.AddBehavior(new MarriageBehavior());
            }
        }

        protected static void Settings_OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (sender is Settings settings && args.PropertyName == Settings.SaveTriggered)
            {
                Util.Log.Print("Received Settings save-triggered event...\n\nNew Settings:");
                Config.CopyFromSettings(settings);
                Util.Log.Print(Config.ToStringLines(indentSize: 4));
                Util.Log.Print(string.Empty);
            }
        }

        private bool hasLoaded;
    }
}
