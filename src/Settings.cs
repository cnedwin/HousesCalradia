using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace HousesCalradia
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => $"{SubModule.Name}_v1";
        public override string DisplayName => SubModule.DisplayName;
        public override string FolderName => SubModule.Name;
        public override string FormatType => "json2";

        private const string AllowSameKingdomDiffCultureMarriage_Hint = "允许在同一王国内联姻的 贵族来自另一种文化。 请注意，始终允许同王国，同文化的婚姻，并且 始终首选相同文化的配对。 [默认：开]";

        private const string AllowDiffKingdomSameCultureMarriage_Hint = "允许不同王国之间的婚姻 这对夫妻有着相同的文化。 相同王国配对仍然始终是首选。 不包括 除非启用了该设置，否则不要使用氏族。 [默认：开]";

        private const string AllowDiffKingdomDiffCultureMarriage_Hint = "允许不同王国之间的婚姻 即使这对夫妻没有相同的文化。 同一个王国和/或同一个文化配对 永远是首选。 除非启用了该设置，否则不包括统治氏族。 [默认：关闭]";

        private const string AllowDiffKingdomMarriageForRulingClans_Hint = "允许王国统治家族联姻， 在任何情况下，允许不同王国的婚姻（如果有）进入不同王国的家庭。 [默认：开] ";

        private const string SpawnNobleWives_Hint = "如果没有合格的贵族候选人及其氏族 迫切需要婚姻才能生存，让贵族有机会嫁给 他们的文化和王国。 强烈推荐。 [默认：开]";

        private const string MinMaleMarriageAge_Hint = "在这个年龄以下，婚介系统不会考虑男性 为了婚姻。 如果将此值设置得太低，则玩家氏族的潜在配偶将少得多。 [默认值：27]";

        private const string MinFemaleMarriageAge_Hint = "在这个年龄以下，婚介系统不会考虑女性 为了婚姻。 如果将此值设置得太低，则玩家氏族的潜在配偶将少得多。 [默认值：27]";

        private const string MaxFemaleMarriageAge_Hint = "超过这个年龄，婚介系统不会考虑女性 为了婚姻。 如果您将其设置为更年期（45），那么更多的婚姻将不会生育。 [默认值：41]";

        private const string MarriageChanceMult_Hint = "乘以每年的结婚概率 高贵。 每个氏族适应度的基础机会减半。 建议留在低于 150％/ 1.5倍，适合适当的氏族适应度。 [默认值：100％]";

        private const string SpawnedMarriageChanceMult_Hint = "如果氏族渴望婚姻而没有婚姻 合格的候选人有资格与其中一位较弱的贵族结婚，这是倍数于 那个机会。 基础几率因许多因素而异。 [默认值：100％]";

        [SettingPropertyBool("允许相同王国，不同文化的通婚", HintText = AllowSameKingdomDiffCultureMarriage_Hint, RequireRestart = false, Order = 0)]
        [SettingPropertyGroup("AI贵族联姻", GroupOrder = 0)]
        public bool AllowSameKingdomDiffCultureMarriage { get; set; } = Config.AllowSameKingdomDiffCultureMarriage;

        [SettingPropertyBool("允许不同王国，相同文化的通婚", HintText = AllowDiffKingdomSameCultureMarriage_Hint, RequireRestart = false, Order = 1)]
        [SettingPropertyGroup("AI贵族联姻")]
        public bool AllowDiffKingdomSameCultureMarriage { get; set; } = Config.AllowDiffKingdomSameCultureMarriage;

        [SettingPropertyBool("允许不同王国，不同文化的通婚", HintText = AllowDiffKingdomDiffCultureMarriage_Hint, RequireRestart = false, Order = 2)]
        [SettingPropertyGroup("AI贵族联姻")]
        public bool AllowDiffKingdomDiffCultureMarriage { get; set; } = Config.AllowDiffKingdomDiffCultureMarriage;

        [SettingPropertyBool("允许不同王国，统治家族的通婚", HintText = AllowDiffKingdomMarriageForRulingClans_Hint, RequireRestart = false, Order = 3)]
        [SettingPropertyGroup("AI贵族联姻")]
        public bool AllowDiffKingdomMarriageForRulingClans { get; set; } = Config.AllowDiffKingdomMarriageForRulingClans;

        // public bool EnableMinorFactionMarriage { get; set; } = true;

        [SettingPropertyBool("允许小家族势力通婚", HintText = SpawnNobleWives_Hint, RequireRestart = false, Order = 3)]
        [SettingPropertyGroup("AI贵族联姻")]
        public bool SpawnNobleWives { get; set; } = Config.SpawnNobleWives;

        [SettingPropertyInteger("男性最小结婚年龄", 18, 35, HintText = MinMaleMarriageAge_Hint, RequireRestart = false, Order = 4)]
        [SettingPropertyGroup("AI贵族联姻")]
        public int MinMaleMarriageAge { get; set; } = Config.MinMaleMarriageAge;

        [SettingPropertyInteger("女性最小结婚年龄", 18, 35, HintText = MinFemaleMarriageAge_Hint, RequireRestart = false, Order = 5)]
        [SettingPropertyGroup("AI贵族联姻")]
        public int MinFemaleMarriageAge { get; set; } = Config.MinFemaleMarriageAge;

        [SettingPropertyInteger("女性最大结婚年龄", 36, 44, HintText = MaxFemaleMarriageAge_Hint, RequireRestart = false, Order = 6)]
        [SettingPropertyGroup("AI贵族联姻")]
        public int MaxFemaleMarriageAge { get; set; } = Config.MaxFemaleMarriageAge;

        [SettingPropertyFloatingInteger("联姻几率的倍数", 0f, 2f, "#0%", HintText = MarriageChanceMult_Hint, RequireRestart = false, Order = 7)]
        [SettingPropertyGroup("AI贵族联姻")]
        public float MarriageChanceMult { get; set; } = Config.MarriageChanceMult;

        [SettingPropertyFloatingInteger("小贵族婚姻概率倍数", 0f, 2f, "#0%", HintText = SpawnedMarriageChanceMult_Hint, RequireRestart = false, Order = 8)]
        [SettingPropertyGroup("AI贵族联姻")]
        public float SpawnedMarriageChanceMult { get; set; } = Config.SpawnedMarriageChanceMult;

        ///////

        private const string AllowPlayerExecutionToEliminateClan_Hint = "如果最后一个幸存的成年贵族在 氏族（即领导者）由玩家执行，那么氏族将被淘汰。";

        [SettingPropertyBool("执行可以灭亡氏族", HintText = AllowPlayerExecutionToEliminateClan_Hint, RequireRestart = false, Order = 0)]
        [SettingPropertyGroup("氏族灭绝", GroupOrder = 1)]
        public bool AllowPlayerExecutionToEliminateClan { get; set; } = Config.AllowPlayerExecutionToEliminateClan;
    }
}
