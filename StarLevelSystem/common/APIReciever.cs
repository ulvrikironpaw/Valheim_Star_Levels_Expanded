using StarLevelSystem.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StarLevelSystem.common.DataObjects;

namespace StarLevelSystem.common
{
    internal class APIReciever {
        public static CreatureDetailCacheSDO FromDetailCacheToIntermediate(CreatureDetailCache cdc)
        {
            CreatureDetailCacheSDO dto = new CreatureDetailCacheSDO();
            dto.CreatureDisabledInBiome = cdc.CreatureDisabledInBiome;
            dto.CreatureCheckedSpawnMult = cdc.CreatureCheckedSpawnMult;
            dto.Level = cdc.Level;
            dto.Colorization = cdc.Colorization;
            dto.Modifiers = cdc.Modifiers.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
            dto.DamageReceivedModifiers = cdc.DamageRecievedModifiers;
            dto.CreatureBaseValueModifiers = cdc.CreatureBaseValueModifiers;
            dto.CreaturePerLevelValueModifiers = cdc.CreaturePerLevelValueModifiers;
            dto.CreatureDamageBonus = cdc.CreatureDamageBonus;
            dto.ModifierPrefixNames = cdc.ModifierPrefixNames.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
            dto.ModifierSuffixNames = cdc.ModifierSuffixNames.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
            return dto;
        }

        public static CreatureDetailCache FromIntermediateToCreatureDetailCache(CreatureDetailCacheSDO Extcdc)
        {
            CreatureDetailCache cdc = new CreatureDetailCache();
            cdc.CreatureDisabledInBiome = Extcdc.CreatureDisabledInBiome;
            cdc.CreatureCheckedSpawnMult = Extcdc.CreatureCheckedSpawnMult;
            cdc.Level = Extcdc.Level;
            cdc.Colorization = Extcdc.Colorization;
            cdc.Modifiers = ConvertModifiersTypeDict(Extcdc.Modifiers);
            cdc.DamageRecievedModifiers = Extcdc.DamageReceivedModifiers;
            cdc.CreatureBaseValueModifiers = Extcdc.CreatureBaseValueModifiers;
            cdc.CreaturePerLevelValueModifiers = Extcdc.CreaturePerLevelValueModifiers;
            cdc.CreatureDamageBonus = Extcdc.CreatureDamageBonus;
            cdc.ModifierPrefixNames = ConvertModifierNamesTypeDict(Extcdc.ModifierPrefixNames);
            cdc.ModifierSuffixNames = ConvertModifierNamesTypeDict(Extcdc.ModifierSuffixNames);
            return cdc;
        }

        private static Dictionary<Data.CreatureModifiersData.ModifierNames, ModifierType> ConvertModifiersTypeDict(Dictionary<string, ModifierType> baseDictionary)
        {
            Dictionary<Data.CreatureModifiersData.ModifierNames, ModifierType> enumBased = new Dictionary<Data.CreatureModifiersData.ModifierNames, ModifierType>();
            foreach (var kvp in baseDictionary)
            {
                if (Enum.TryParse<Data.CreatureModifiersData.ModifierNames>(kvp.Key, out Data.CreatureModifiersData.ModifierNames enumKey))
                {
                    enumBased[(Data.CreatureModifiersData.ModifierNames)enumKey] = kvp.Value;
                }
            }
            return enumBased;
        }

        private static Dictionary<Data.CreatureModifiersData.ModifierNames, List<string>> ConvertModifierNamesTypeDict(Dictionary<string, List<string>> baseDictionary)
        {
            Dictionary<Data.CreatureModifiersData.ModifierNames, List<string>> enumBased = new Dictionary<Data.CreatureModifiersData.ModifierNames, List<string>>();
            foreach (var kvp in baseDictionary)
            {
                if (Enum.TryParse<Data.CreatureModifiersData.ModifierNames>(kvp.Key, out Data.CreatureModifiersData.ModifierNames enumKey))
                {
                    enumBased[(Data.CreatureModifiersData.ModifierNames)enumKey] = kvp.Value;
                }
            }
            return enumBased;
        }

        private static Dictionary<string, string> ConvertDict(object dictObj)
        {
            var result = new Dictionary<string, string>();
            if (dictObj is System.Collections.IDictionary dict)
            {
                foreach (var key in dict.Keys)
                    result[key.ToString()] = dict[key]?.ToString();
            }
            return result;
        }

        private static Dictionary<string, float> ConvertDictF(object dictObj)
        {
            var result = new Dictionary<string, float>();
            if (dictObj is System.Collections.IDictionary dict)
            {
                foreach (var key in dict.Keys)
                {
                    if (dict[key] is float f)
                        result[key.ToString()] = f;
                    else if (dict[key] is IConvertible c)
                        result[key.ToString()] = c.ToSingle(null);
                }
            }
            return result;
        }

        private static Dictionary<string, List<string>> ConvertDictList(object dictObj)
        {
            var result = new Dictionary<string, List<string>>();
            if (dictObj is System.Collections.IDictionary dict)
            {
                foreach (var key in dict.Keys)
                {
                    var list = dict[key] as System.Collections.IEnumerable;
                    var stringList = new List<string>();
                    if (list != null)
                    {
                        foreach (var item in list)
                            stringList.Add(item?.ToString());
                    }
                    result[key.ToString()] = stringList;
                }
            }
            return result;
        }
    }
}
