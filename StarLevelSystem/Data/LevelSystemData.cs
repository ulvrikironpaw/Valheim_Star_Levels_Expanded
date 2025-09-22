using StarLevelSystem.API;
using StarLevelSystem.common;
using StarLevelSystem.modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static StarLevelSystem.common.DataObjects;

namespace StarLevelSystem.Data
{
    public static class LevelSystemData
    {

        public static CreatureLevelSettings SLE_Level_Settings = DefaultConfiguration;

        public static CreatureLevelSettings DefaultConfiguration = new CreatureLevelSettings()
        {
            DefaultCreatureLevelUpChance = new SortedDictionary<int, float>() {
                { 1, 20f },
                { 2, 15f },
                { 3, 12f },
                { 4, 10f },
                { 5, 8.0f },
                { 6, 6.5f },
                { 7, 5.0f },
                { 8, 3.5f },
                { 9, 1.5f },
                { 10, 1.0f },
                { 11, 0.5f },
                { 12, 0.25f },
                { 13, 0.125f },
                { 14, 0.0625f },
                { 15, 0.0312f },
                { 16, 0.0156f },
                { 17, 0.0078f },
                { 18, 0.0039f },
                { 19, 0.0019f },
                { 20, 0.0019f },
                { 21, 0.0019f },
                { 22, 0.0019f },
                { 23, 0.0019f },
                { 24, 0.0019f },
                { 25, 0.0019f },
                { 26, 0.0019f },
                { 27, 0.0019f },
                { 28, 0.0019f },
                { 29, 0.0019f },
                { 30, 0.0019f },
            },
            BiomeConfiguration = new Dictionary<Heightmap.Biome, BiomeSpecificSetting>()
            {
                { Heightmap.Biome.All, new BiomeSpecificSetting()
                    {
                        SpawnRateModifier = 1.5f,
                        DistanceScaleModifier = 1.5f,
                        DamageRecievedModifiers = new Dictionary<DamageType, float>() {
                            {DamageType.Poison, 1.5f }
                        },
                        CreatureBaseValueModifiers = new Dictionary<CreatureBaseAttribute, float>() {
                            { CreatureBaseAttribute.BaseHealth, 1f },
                            { CreatureBaseAttribute.BaseDamage, 1f },
                            { CreatureBaseAttribute.Speed, 1f },
                            { CreatureBaseAttribute.Size, 1f }
                        },
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.4f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.1f },
                            { CreaturePerLevelAttribute.SpeedPerLevel, 0f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.10f }
                        },
                        
                    }
                },
                { Heightmap.Biome.Meadows, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 4,
                    }
                },
                { Heightmap.Biome.BlackForest, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 6,
                    }
                },
                { Heightmap.Biome.Swamp, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 10,
                    }
                },
                { Heightmap.Biome.Mountain, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 14,
                    }
                },
                { Heightmap.Biome.Plains, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 18,
                    }
                },
                { Heightmap.Biome.Mistlands, new BiomeSpecificSetting()
                    {
                        BiomeMaxLevelOverride = 22,
                    }
                },
                { Heightmap.Biome.AshLands, new BiomeSpecificSetting()
                    {
                        DistanceScaleModifier = 0.5f,
                        BiomeMaxLevelOverride = 26,
                    }
                },
                { Heightmap.Biome.DeepNorth, new BiomeSpecificSetting()
                    {
                        DistanceScaleModifier = 0.5f,
                        BiomeMaxLevelOverride = 26,
                    }
                }
            },

            CreatureConfiguration = new Dictionary<string, CreatureSpecificSetting>() {
                { "Lox", new CreatureSpecificSetting()
                    {
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.SpeedPerLevel, 0.9f },
                        }
                    }
                },
                { "Troll", new CreatureSpecificSetting()
                    {
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.SizePerLevel, 0.05f },
                        }
                    }
                },
                { "Bjorn", new CreatureSpecificSetting()
                    {
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.SizePerLevel, 0.05f },
                        }
                    }
                },
                { "Eikthyr", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 4,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "gd_king", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 6,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "Bonemass", new CreatureSpecificSetting()
                    {
                    CreatureMaxLevelOverride = 8,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "Dragon", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 10,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "GoblinKing", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 12,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "SeekerQueen", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 14,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.07f }
                        },
                    }
                },
                { "Fader", new CreatureSpecificSetting()
                    {
                        CreatureMaxLevelOverride = 16,
                        SpawnRateModifier = 1f,
                        CreaturePerLevelValueModifiers = new Dictionary<CreaturePerLevelAttribute, float>() {
                            { CreaturePerLevelAttribute.HealthPerLevel, 0.3f },
                            { CreaturePerLevelAttribute.DamagePerLevel, 0.05f },
                            { CreaturePerLevelAttribute.SizePerLevel, 0.05f }
                        },
                    }
                }
            },

            EnableDistanceLevelBonus = true,
            DistanceLevelBonus = new SortedDictionary<int, SortedDictionary<int, float>>()
            {
                { 1250, new SortedDictionary<int, float>() {
                        { 1, 0.25f },
                    }
                },
                { 2500, new SortedDictionary<int, float>() {
                        { 1, 0.5f },
                        { 2, 0.25f },
                    }
                },
                { 3750, new SortedDictionary<int, float>() {
                        { 1, 1f },
                        { 2, 0.75f },
                        { 3, 0.5f },
                        { 4, 0.25f },
                    }
                },
                { 5000, new SortedDictionary<int, float>() {
                        { 1, 1f },
                        { 2, 1f },
                        { 3, 0.75f },
                        { 4, 0.5f },
                        { 5, 0.25f },
                        { 6, 0.15f },
                    }
                },
                { 6250, new SortedDictionary<int, float>() {
                        { 1, 1f },
                        { 2, 1f },
                        { 3, 1f },
                        { 4, 0.75f },
                        { 5, 0.5f },
                        { 6, 0.25f },
                        { 7, 0.20f },
                        { 8, 0.15f },
                    }
                },
                { 7500, new SortedDictionary<int, float>() {
                        { 1, 1f },
                        { 2, 1f },
                        { 3, 1f },
                        { 4, 1f },
                        { 5, 0.75f },
                        { 6, 0.5f },
                        { 7, 0.25f },
                        { 8, 0.20f },
                        { 9, 0.15f },
                    }
                },
                { 8750, new SortedDictionary<int, float>() {
                        { 1, 1f },
                        { 2, 1f },
                        { 3, 1f },
                        { 4, 1f },
                        { 5, 1f },
                        { 6, 0.75f },
                        { 7, 0.5f },
                        { 8, 0.25f },
                        { 9, 0.20f },
                        { 10, 0.15f },
                    }
                }
            }
        };  


        internal static void Init() {
            // Load the default configuration
            SLE_Level_Settings = DefaultConfiguration;
            try {
                UpdateYamlConfig(File.ReadAllText(ValConfig.levelsFilePath));
            }
            catch (Exception e) { Jotunn.Logger.LogWarning($"There was an error updating the Creature Level values, defaults will be used. Exception: {e}"); }
        }
        public static string YamlDefaultConfig() {
            var yaml = yamlserializer.Serialize(DefaultConfiguration);
            return yaml;
        }
        public static bool UpdateYamlConfig(string yaml) {
            try {
                SLE_Level_Settings = yamldeserializer.Deserialize<CreatureLevelSettings>(yaml);
                Logger.LogDebug("Loaded new Star Level Creature settings, updating loaded creatures...");
                foreach (var chara in Resources.FindObjectsOfTypeAll<Character>()) {
                    if (chara.m_level <= 1) { continue; }
                    CreatureDetailCache ccd = CompositeLazyCache.GetAndSetDetailCache(chara, true);
                    // Modify the creatures stats by custom character/biome modifications
                    ModificationExtensionSystem.ApplySpeedModifications(chara, ccd);
                    ModificationExtensionSystem.ApplyDamageModification(chara, ccd, true);
                    ModificationExtensionSystem.LoadApplySizeModifications(chara.gameObject, chara.m_nview, ccd, true);
                    ModificationExtensionSystem.ApplyHealthModifications(chara, ccd);
                    //Colorization.ApplyColorizationWithoutLevelEffects(chara.gameObject, ccd.Colorization);
                    //Colorization.ApplyLevelVisual(chara);
                }
            }
            catch (Exception ex) {
                StarLevelSystem.Log.LogError($"Failed to parse CreatureLevelSettings YAML: {ex.Message}");
                return false;
            }
            return true;
        }

        internal static IEnumerator UpdateCreatureAttributes(List<Character> characters) {
            int i = 0;
            WaitForSeconds sleep = new WaitForSeconds(0.1f);
            foreach (var character in characters) {
                if (i >= ValConfig.NumberOfCacheUpdatesPerFrame.Value) {
                    yield return sleep;
                    i = 0;
                }
                CreatureDetailCache ccd = CompositeLazyCache.GetAndSetDetailCache(character, true);
                // Modify the creatures stats by custom character/biome modifications
                ModificationExtensionSystem.ApplySpeedModifications(character, ccd);
                ModificationExtensionSystem.ApplyDamageModification(character, ccd, true);
                ModificationExtensionSystem.LoadApplySizeModifications(character.gameObject, character.m_nview, ccd, true);
                ModificationExtensionSystem.ApplyHealthModifications(character, ccd);

                i++;
            }
        }
    }
}
