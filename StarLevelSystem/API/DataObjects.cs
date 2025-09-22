using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace StarLevelSystem.API
{
    [PublicAPI]
    public enum DamageType
    {
        Blunt = 0,
        Slash = 1,
        Pierce = 2,
        Fire = 3,
        Frost = 4,
        Lightning = 5,
        Poison = 6,
        Spirit = 7,
        Chop = 8,
        Pickaxe = 9,
    }

    [PublicAPI]
    public enum CreatureBaseAttribute
    {
        BaseHealth = 0,
        BaseDamage = 1,
        AttackSpeed = 2,
        Speed = 3,
        Size = 4,
    }

    [PublicAPI]
    public enum CreaturePerLevelAttribute
    {
        HealthPerLevel = 0,
        DamagePerLevel = 1,
        SpeedPerLevel = 2,
        AttackSpeedPerLevel = 3,
        SizePerLevel = 4,
    }

    [PublicAPI]
    public enum ModifierType
    {
        Major = 0,
        Minor = 1,
        Boss = 2
    }

    [PublicAPI]
    public class ColorDef
    {
        public float hue { get; set; } = 0f;
        public float saturation { get; set; } = 0f;
        public float value { get; set; } = 0f;
        public bool is_emissive { get; set; } = false;

        public LevelEffects.LevelSetup ToLevelEffect()
        {
            return new LevelEffects.LevelSetup()
            {
                m_scale = 1f,
                m_hue = hue,
                m_saturation = saturation,
                m_value = value,
                m_setEmissiveColor = is_emissive,
                m_emissiveColor = new Color(hue, saturation, value)
            };
        }
    }

    [PublicAPI]
    public class CreatureDetailCacheSDO
    {
        // This is used to determine if this creature should be deleted
        public bool CreatureDisabledInBiome { get; set; }
        // This is used to determine if spawn multiplier has been applied
        public bool CreatureCheckedSpawnMult { get; set; }
        // This is the color variation applied to the creature
        public ColorDef Colorization { get; set; }
        // This is the level of the creature
        public int Level { get; set; }
        // Structure: <ModifierName, ModifierType>
        // ModifierName: https://github.com/MidnightsFX/Valheim_Star_Levels_Expanded/blob/master/StarLevelSystem/Data/CreatureModifiersData.cs#L34
        public Dictionary<string, ModifierType> Modifiers { get; set; }
        public Dictionary<DamageType, float> DamageReceivedModifiers { get; set; }
        public Dictionary<CreatureBaseAttribute, float> CreatureBaseValueModifiers { get; set; }
        public Dictionary<CreaturePerLevelAttribute, float> CreaturePerLevelValueModifiers { get; set; }
        public Dictionary<DamageType, float> CreatureDamageBonus { get; set; }
        // Structure: <ModifierName, List<string>>
        // ModifierName: https://github.com/MidnightsFX/Valheim_Star_Levels_Expanded/blob/master/StarLevelSystem/Data/CreatureModifiersData.cs#L34
        public Dictionary<string, List<string>> ModifierPrefixNames { get; set; }
        // Structure: <ModifierName, List<string>>
        // ModifierName: https://github.com/MidnightsFX/Valheim_Star_Levels_Expanded/blob/master/StarLevelSystem/Data/CreatureModifiersData.cs#L34
        public Dictionary<string, List<string>> ModifierSuffixNames { get; set; }
    }
}
