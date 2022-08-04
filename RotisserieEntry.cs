using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using SRML.SR.Translation;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rotisserie.net
{
    public class Main : ModEntryPoint
    {
        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            RotisserieChicken.PreloadClasses();

            // chicken
            PediaRegistry.RegisterIdentifiableMapping(Ids.ROTISSERIE_CHICKEN_ENTRY, Ids.ROTISSERIE_CHICKEN);
            PediaRegistry.RegisterIdEntry(Ids.ROTISSERIE_CHICKEN_ENTRY, OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieChicken.png"))); // change this icon
            PediaRegistry.SetPediaCategory(Ids.ROTISSERIE_CHICKEN_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.ROTISSERIE_CHICKEN_ENTRY).SetTitleTranslation("Rotisserie Chicken").SetIntroTranslation("So well done.");
            TranslationPatcher.AddPediaTranslation("m.resource_type.rotisserie_chicken_entry", "Meat");
            TranslationPatcher.AddPediaTranslation("m.favored_by.rotisserie_chicken_entry", "All slimes.");
            TranslationPatcher.AddPediaTranslation("m.desc.rotisserie_chicken_entry", "Rotisserie Chickens.. oh my gosh, we're eating fancy tonight. (SLIMES LOVE IT SO MUCH!!)");
            // chick
            PediaRegistry.RegisterIdentifiableMapping(Ids.ROTISSERIE_CHICK_ENTRY, Ids.ROTISSERIE_CHICK);
            PediaRegistry.RegisterIdEntry(Ids.ROTISSERIE_CHICK_ENTRY, OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieChick.png"))); // change this icon
            PediaRegistry.SetPediaCategory(Ids.ROTISSERIE_CHICK_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.ROTISSERIE_CHICK_ENTRY).SetTitleTranslation("Rotisserie Chick").SetIntroTranslation("A little crispy, give it more time to cook.");
            TranslationPatcher.AddPediaTranslation("m.resource_type.rotisserie_chick_entry", "Meat");
            TranslationPatcher.AddPediaTranslation("m.favored_by.rotisserie_chick_entry", "No slimes. (Cook it, dang it)");
            TranslationPatcher.AddPediaTranslation("m.desc.rotisserie_chick_entry", "Give it some more time to cook! Will ya?");

            // rooster
            PediaRegistry.RegisterIdentifiableMapping(Ids.ROTISSERIE_ROOSTER_ENTRY, Ids.ROTISSERIE_ROOSTER);
            PediaRegistry.RegisterIdEntry(Ids.ROTISSERIE_ROOSTER_ENTRY, OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieRooster.png"))); // change this icon
            PediaRegistry.SetPediaCategory(Ids.ROTISSERIE_ROOSTER_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.ROTISSERIE_ROOSTER_ENTRY).SetTitleTranslation("Rotisserie Rooster").SetIntroTranslation("Ooo, even more well done.");
            TranslationPatcher.AddPediaTranslation("m.resource_type.rotisserie_rooster_entry", "Meat");
            TranslationPatcher.AddPediaTranslation("m.favored_by.rotisserie_rooster_entry", "All slimes.");
            TranslationPatcher.AddPediaTranslation("m.desc.rotisserie_rooster_entry", "Rotisserie Roosters.. oh my gosh, we're eating EVEN FANCIER tonight. (SLIMES LOVE IT EVEN MORE!!)");

            // elder chicken
            PediaRegistry.RegisterIdentifiableMapping(Ids.OVER_COOKED_ROTISSERIE_CHICKEN_ENTRY, Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            PediaRegistry.RegisterIdEntry(Ids.OVER_COOKED_ROTISSERIE_CHICKEN_ENTRY, OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.OverCookedRotisserieChicken.png"))); // change this icon
            PediaRegistry.SetPediaCategory(Ids.OVER_COOKED_ROTISSERIE_CHICKEN_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.OVER_COOKED_ROTISSERIE_CHICKEN_ENTRY).SetTitleTranslation("Over-Cooked Rotisserie Chicken").SetIntroTranslation("WHY YOU COOK IT LIKE THAT?");
            TranslationPatcher.AddPediaTranslation("m.resource_type.over_cooked_rotisserie_chicken_entry", "Meat");
            TranslationPatcher.AddPediaTranslation("m.favored_by.over_cooked_rotisserie_chicken_entry", "All slimes.");
            TranslationPatcher.AddPediaTranslation("m.desc.over_cooked_rotisserie_chicken_entry", "I'm just gonna pretend you didn't do that, for the sake of me.");
            // elder rooster
            PediaRegistry.RegisterIdentifiableMapping(Ids.OVER_COOKED_ROTISSERIE_ROOSTER_ENTRY, Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
            PediaRegistry.RegisterIdEntry(Ids.OVER_COOKED_ROTISSERIE_ROOSTER_ENTRY, OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.OverCookedRotisserieRooster.png"))); // change this icon
            PediaRegistry.SetPediaCategory(Ids.OVER_COOKED_ROTISSERIE_ROOSTER_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.OVER_COOKED_ROTISSERIE_ROOSTER_ENTRY).SetTitleTranslation("Over-Cooked Rotisserie Rooster").SetIntroTranslation("Y'all did that rooster wrong.");
            TranslationPatcher.AddPediaTranslation("m.resource_type.over_cooked_rotisserie_rooster_entry", "Meat");
            TranslationPatcher.AddPediaTranslation("m.favored_by.over_cooked_rotisserie_rooster_entry", "All slimes.");
            TranslationPatcher.AddPediaTranslation("m.desc.over_cooked_rotisserie_rooster_entry", "I hope we all pretend you didn't do that, someone going to jail.");

            // rotisserie chicken spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedAnimalSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedAnimalSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.WILDS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ROTISSERIE_CHICKEN),
                                weight = 0.04f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // rotisserie chick spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedAnimalSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedAnimalSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.RUINS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ROTISSERIE_CHICK),
                                weight = 0.05f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // rotisserie rooster spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedAnimalSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedAnimalSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.WILDS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ROTISSERIE_ROOSTER),
                                weight = 0.03f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // rotisserie crate spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedActorSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedActorSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.RUINS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ROTISSERIE_CRATE),
                                weight = 0.1f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
        }

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            RotisserieChicken.LoadElderRotisserie(); RotisserieChicken.LoadRotisserie();

            GameObject RotisserieCrate = OtherFunc.CopyPrefab(Identifiable.Id.CRATE_MOSS_01);
            RotisserieCrate.name = "Rotisserie Crate";

            var itemsProduced = new List<BreakOnImpact.SpawnOption>
            {
                new BreakOnImpact.SpawnOption()
                {
                    spawn = OtherFunc.CopyPrefab(Ids.ROTISSERIE_CHICKEN),
                    weight = 4.5f
                },
                new BreakOnImpact.SpawnOption()
                {
                    spawn = OtherFunc.CopyPrefab(Ids.ROTISSERIE_CHICK),
                    weight = 5.5f
                },
                new BreakOnImpact.SpawnOption()
                {
                    spawn = OtherFunc.CopyPrefab(Ids.ROTISSERIE_ROOSTER),
                    weight = 3.5f
                },
            };

            RotisserieCrate.GetComponent<Identifiable>().id = Ids.ROTISSERIE_CRATE;
            RotisserieCrate.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
            RotisserieCrate.GetComponent<BreakOnImpact>().minSpawns = 3;
            RotisserieCrate.GetComponent<BreakOnImpact>().maxSpawns = 6;
            RotisserieCrate.GetComponent<BreakOnImpact>().spawnOptions = itemsProduced;

            RotisserieCrate.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(RotisserieCrate.GetComponent<MeshRenderer>().material);
            RotisserieCrate.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(149, 55, 24, 255));
            RotisserieCrate.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));

            LookupRegistry.RegisterIdentifiablePrefab(RotisserieCrate);
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
        }

    }
}