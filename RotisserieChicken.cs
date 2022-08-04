using SimpleSRmodLibrary.Creation;
using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Rotisserie.net
{
    class RotisserieChicken
    {
        static public void LoadRotisserie()
        {
            // chick
            GameObject ChickPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.CHICK));
            ChickPrefab.name = "Rotisserie Chick";
            SkinnedMeshRenderer mRenderChick = ChickPrefab.transform.Find("Chickadoo/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material ChickMat = UnityEngine.Object.Instantiate<Material>(mRenderChick.sharedMaterial);
            ChickMat.SetTexture("_RampGreen", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            ChickMat.SetTexture("_RampRed", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            ChickMat.SetTexture("_RampBlue", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            ChickMat.SetTexture("_RampBlack", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            mRenderChick.sharedMaterial = ChickMat;
            ChickPrefab.GetComponent<Identifiable>().id = Ids.ROTISSERIE_CHICK;
            ChickPrefab.transform.Find("Chickadoo/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = ChickMat;
            LookupRegistry.RegisterIdentifiablePrefab(ChickPrefab);
            CropCreation.LoadCrop(Ids.ROTISSERIE_CHICK, ChickPrefab, true, false, false, false);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, ChickPrefab, Ids.ROTISSERIE_CHICK, "Rotisserie Chick", OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieChick.png")), new Color32(149, 55, 24, 255)); // change this icon

            // hen
            GameObject HenHenPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HEN));
            HenHenPrefab.name = "Rotisserie Chicken";
            SkinnedMeshRenderer mRenderHen = HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material HenMat = UnityEngine.Object.Instantiate<Material>(mRenderHen.sharedMaterial);
            HenMat.SetTexture("_RampGreen", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            HenMat.SetTexture("_RampRed", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            HenMat.SetTexture("_RampBlue", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            HenMat.SetTexture("_RampBlack", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            mRenderHen.sharedMaterial = HenMat;
            HenHenPrefab.GetComponent<Identifiable>().id = Ids.ROTISSERIE_CHICKEN;
            HenHenPrefab.transform.Find("Hen Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = HenMat;
            HenHenPrefab.GetComponent<Reproduce>().childPrefab = ChickPrefab;
            HenHenPrefab.GetComponent<TransformChanceOnReproduce>().targetPrefab = OtherFunc.CopyPrefab(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            HenHenPrefab.GetComponent<TransformChanceOnReproduce>().transformChance = 2.5f;
            LookupRegistry.RegisterIdentifiablePrefab(HenHenPrefab);
            CropCreation.LoadCrop(Ids.ROTISSERIE_CHICKEN, HenHenPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, HenHenPrefab, Ids.ROTISSERIE_CHICKEN, "Rotisserie Chicken", OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieChicken.png")), new Color32(149, 55, 24, 255)); // change this icon

            // rooster
            GameObject RoostroPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROOSTER));
            RoostroPrefab.name = "Rotisserie Rooster";
            SkinnedMeshRenderer mRenderRoostro = RoostroPrefab.transform.Find("Roostro/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material RoostroMat = UnityEngine.Object.Instantiate<Material>(mRenderRoostro.sharedMaterial);
            RoostroMat.SetTexture("_RampGreen", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            RoostroMat.SetTexture("_RampRed", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            RoostroMat.SetTexture("_RampBlue", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            RoostroMat.SetTexture("_RampBlack", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            mRenderRoostro.sharedMaterial = RoostroMat;
            RoostroPrefab.GetComponent<Identifiable>().id = Ids.ROTISSERIE_ROOSTER;
            RoostroPrefab.transform.Find("Roostro/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = RoostroMat;
            HenHenPrefab.GetComponent<TransformChanceOnReproduce>().targetPrefab = OtherFunc.CopyPrefab(Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
            HenHenPrefab.GetComponent<TransformChanceOnReproduce>().transformChance = 2.5f;
            LookupRegistry.RegisterIdentifiablePrefab(RoostroPrefab);
            CropCreation.LoadCrop(Ids.ROTISSERIE_ROOSTER, RoostroPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, RoostroPrefab, Ids.ROTISSERIE_ROOSTER, "Rotisserie Rooster", OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.RotisserieRooster.png")), new Color32(149, 55, 24, 255)); // change this icon

            // after mess?
            ChickPrefab.GetComponent<TransformAfterTime>().options = new List<TransformAfterTime.TransformOpt>() 
            { 
                new TransformAfterTime.TransformOpt() 
                { 
                    targetPrefab = HenHenPrefab, 
                    weight = 4.5f 
                },
                new TransformAfterTime.TransformOpt()
                {
                    targetPrefab = RoostroPrefab,
                    weight = 3.5f
                },
                ChickPrefab.GetComponent<TransformAfterTime>().options.ElementAt(1) 
            };
        }
        static public void LoadElderRotisserie()
        {
            // elder rooster
            GameObject ElderRoostroPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ELDER_ROOSTER));
            ElderRoostroPrefab.name = "Over Cooked Rotisserie Rooster";
            SkinnedMeshRenderer mRenderElderRoostro = ElderRoostroPrefab.transform.Find("Elder Roostro/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material ElderRoostroMat = UnityEngine.Object.Instantiate<Material>(mRenderElderRoostro.sharedMaterial);
            ElderRoostroMat.SetTexture("_RampGreen", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            ElderRoostroMat.SetTexture("_RampRed", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            ElderRoostroMat.SetTexture("_RampBlue", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            ElderRoostroMat.SetTexture("_RampBlack", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            mRenderElderRoostro.sharedMaterial = ElderRoostroMat;
            ElderRoostroPrefab.GetComponent<Identifiable>().id = Ids.OVER_COOKED_ROTISSERIE_ROOSTER;
            ElderRoostroPrefab.transform.Find("Elder Roostro/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = ElderRoostroMat;
            LookupRegistry.RegisterIdentifiablePrefab(ElderRoostroPrefab);
            CropCreation.LoadCrop(Ids.OVER_COOKED_ROTISSERIE_ROOSTER, ElderRoostroPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, ElderRoostroPrefab, Ids.OVER_COOKED_ROTISSERIE_ROOSTER, "Over Cooked Rotisserie Rooster", OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.OverCookedRotisserieRooster.png")), new Color32(109, 55, 24, 255)); // change this icon

            // elder hen
            GameObject ElderHenPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ELDER_HEN));
            ElderHenPrefab.name = "Over Cooked Rotisserie Chicken";
            SkinnedMeshRenderer mRenderElderHen = ElderHenPrefab.transform.Find("Elder Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>();
            Material ElderHenMat = UnityEngine.Object.Instantiate<Material>(mRenderElderHen.sharedMaterial);
            ElderHenMat.SetTexture("_RampGreen", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            ElderHenMat.SetTexture("_RampRed", OtherFunc.ROTLoadImage("assets.rot_skin_ramp.png"));
            ElderHenMat.SetTexture("_RampBlue", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            ElderHenMat.SetTexture("_RampBlack", OtherFunc.ROTLoadImage("assets.rot_skin_ramp_darker.png"));
            mRenderElderHen.sharedMaterial = ElderHenMat;
            ElderHenPrefab.GetComponent<Identifiable>().id = Ids.OVER_COOKED_ROTISSERIE_CHICKEN;
            ElderHenPrefab.transform.Find("Elder Hen/mesh_body1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial = ElderHenMat;
            LookupRegistry.RegisterIdentifiablePrefab(ElderHenPrefab);
            CropCreation.LoadCrop(Ids.OVER_COOKED_ROTISSERIE_CHICKEN, ElderHenPrefab, false, false, false, true);
            VacItemCreation.NewVacItem(Vacuumable.Size.NORMAL, ElderHenPrefab, Ids.OVER_COOKED_ROTISSERIE_CHICKEN, "Over Cooked Rotisserie Chicken", OtherFunc.ROTCreateSprite(OtherFunc.ROTLoadImage("assets.OverCookedRotisserieChicken.png")), new Color32(109, 55, 24, 255)); // change this icon
        }
        static public void PreloadClasses()
        {
            // pre-cooked, cooked
            Identifiable.CHICK_CLASS.Add(Ids.ROTISSERIE_CHICK);
            Identifiable.MEAT_CLASS.Add(Ids.ROTISSERIE_CHICKEN);
            Identifiable.FOOD_CLASS.Add(Ids.ROTISSERIE_CHICKEN);
            Identifiable.MEAT_CLASS.Add(Ids.ROTISSERIE_ROOSTER);
            Identifiable.FOOD_CLASS.Add(Ids.ROTISSERIE_ROOSTER);

            // over-cooked
            Identifiable.MEAT_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            Identifiable.FOOD_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            Identifiable.MEAT_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_ROOSTER);
            Identifiable.FOOD_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_ROOSTER);

            Identifiable.ELDER_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            Identifiable.ELDER_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_ROOSTER);

            // non slime class
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ROTISSERIE_CHICK);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ROTISSERIE_CHICKEN);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.OVER_COOKED_ROTISSERIE_CHICKEN);
        }
    }
}
