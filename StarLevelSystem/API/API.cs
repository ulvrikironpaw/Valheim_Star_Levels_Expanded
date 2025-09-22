using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StarLevelSystem.API
{
    /// <summary>
    /// API for accessing and modifying Creature based modifications from the StarLevelSystems Cache entries
    /// </summary>
    [PublicAPI]
    public static class CreatureCacheAPI
    {
        private static readonly Type CompositeLazyCacheType;
        private static readonly MethodInfo GetCreatureCacheEntry;
        private static readonly MethodInfo UpdateCacheEntryMethod;
        private static readonly MethodInfo ApplyCacheForCreature;

        public static bool CreatureCacheAvailable => CompositeLazyCacheType != null
            && GetCreatureCacheEntry != null 
            && UpdateCacheEntryMethod != null
            && ApplyCacheForCreature != null;

        static CreatureCacheAPI() {
            CompositeLazyCacheType = Type.GetType("StarLevelSystem.Data.CompositeLazyCache, StarLevelSystem");
            GetCreatureCacheEntry = CompositeLazyCacheType.GetMethod("GetCreatureCacheEntry", BindingFlags.Public | BindingFlags.Static);
            UpdateCacheEntryMethod = CompositeLazyCacheType.GetMethod("UpdateCreatureCacheEntry", BindingFlags.Public | BindingFlags.Static);
            ApplyCacheForCreature = CompositeLazyCacheType.GetMethod("ApplyCacheForSelectedCreature", BindingFlags.Public | BindingFlags.Static);
        }

        /// <summary>
        /// Gets a creature cache entry by its ZDOID
        /// </summary>
        /// <param name="creatureId">The creature's ZDOID</param>
        /// <returns>The cache entry or null if not found</returns>
        public static CreatureDetailCacheSDO GetCacheEntry(uint creatureId) {
            return (CreatureDetailCacheSDO)GetCreatureCacheEntry.Invoke(null, new object[] { creatureId });
        }

        /// <summary>
        /// Updates a creature cache entry in the session cache by its ZDOID
        /// Returns true if the entry was updated, false if it wasn't found
        /// </summary>
        /// <param name="creatureId">The creature's ZDOID</param>
        /// <param name="cacheEntry">The updated cache entry</param>
        public static bool UpdateCacheEntry(uint creatureId, CreatureDetailCacheSDO cacheEntry)
        {
            return (bool)UpdateCacheEntryMethod.Invoke(null, new object[] { creatureId, cacheEntry });
        }

        /// <summary>
        /// Updates the creature's stats, modifiers, color, size etc based on the current cache entry
        /// Note: Creature cache statts are automatically applied 1 second after a character is awkened.
        /// If you need to modify creature stats after that, you should call this method to re-apply the cache entry
        /// </summary>
        /// <param name="character">The character entry for this creature</param>
        /// <returns>True if the cache was applied, false if not</returns>
        public static bool ApplyCacheUpdatesToCreature(Character character) {
            return (bool)ApplyCacheForCreature.Invoke(null, new object[] { character });
        }

        /// <summary>
        /// Sets the modifiers for a creature ZDOID that is currently loaded
        /// </summary>
        /// <param name="creatureId">The creature's ZDOID</param>
        /// <param name="modifiers">Dictionary of modifiers with reference to their modifier type</param>
        public static bool SetModifiersForCreature(uint creatureId, Dictionary<string, ModifierType> modifiers) {
            CreatureDetailCacheSDO cacheEntry = GetCacheEntry(creatureId);
            if (cacheEntry == null) { return false; }
            cacheEntry.Modifiers = modifiers;
            return UpdateCacheEntry(creatureId, cacheEntry);
        }
    }
}
