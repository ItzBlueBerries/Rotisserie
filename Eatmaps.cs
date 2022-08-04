using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Rotisserie.net
{
    [HarmonyPatch(typeof(SlimeEat))]
    [HarmonyPatch("GetFoodGroupIds")]
    internal static class FoodGroupPatch
    {
        public static void Postfix(SlimeEat __instance, ref Identifiable.Id[] __result, SlimeEat.FoodGroup group)
        {
            if ((__result == null))
                return;
            List<Identifiable.Id> foodGroupIds = __result.ToList();
            if (group == SlimeEat.FoodGroup.MEAT) //Change to whatever foodgroup you want    
            {
                foodGroupIds.Add(Ids.ROTISSERIE_CHICKEN);
                foodGroupIds.Add(Ids.ROTISSERIE_ROOSTER);
                foodGroupIds.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
                foodGroupIds.Add(Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
            }
            __result = foodGroupIds.ToArray();
        }
    }
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class Eatmaps
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinition definition)
        {
            // slime support
            foreach (Identifiable.Id slimeID in Identifiable.SLIME_CLASS)
            {
                foreach (Identifiable.Id slimePRODUCE in definition.Diet.Produces)
                {
                    if (definition.IdentifiableId == slimeID)
                    {
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.ROTISSERIE_CHICKEN);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = slimePRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 8,
                            eats = Ids.ROTISSERIE_CHICKEN,
                            minDrive = 2
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.ROTISSERIE_ROOSTER);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = slimePRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 11,
                            eats = Ids.ROTISSERIE_ROOSTER,
                            minDrive = 2.5f
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = slimePRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 4,
                            eats = Ids.OVER_COOKED_ROTISSERIE_CHICKEN,
                            minDrive = 1
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = slimePRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 5,
                            eats = Ids.OVER_COOKED_ROTISSERIE_ROOSTER,
                            minDrive = 1.5f
                        });
                    }
                }
            }
            // largo support
            foreach (Identifiable.Id largoID in Identifiable.LARGO_CLASS)
            {
                foreach (Identifiable.Id largoPRODUCE in definition.Diet.Produces)
                {
                    if (definition.IdentifiableId == largoID)
                    {
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.ROTISSERIE_CHICKEN);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = largoPRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 8,
                            eats = Ids.ROTISSERIE_CHICKEN,
                            minDrive = 2
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.ROTISSERIE_ROOSTER);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = largoPRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 11,
                            eats = Ids.ROTISSERIE_ROOSTER,
                            minDrive = 2.5f
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = largoPRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 4,
                            eats = Ids.OVER_COOKED_ROTISSERIE_CHICKEN,
                            minDrive = 1
                        });
                        __instance.EatMap.RemoveAll((x) => x.eats == Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
                        __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                        {
                            isFavorite = true,
                            producesId = largoPRODUCE,
                            favoriteProductionCount = definition.Diet.FavoriteProductionCount + 5,
                            eats = Ids.OVER_COOKED_ROTISSERIE_ROOSTER,
                            minDrive = 1.5f
                        });
                    }
                }
            }
        }
    }
}
