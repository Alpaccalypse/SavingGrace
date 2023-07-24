using Assets.Code;
using Assets.Code.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SavingGraceMod
{
    public class SaveYourself : ModKernel
    {
        public World world;
        public bool autosaveEnable;
        public bool quicksaveEnable;

        public int autosaveYourCount;
        public int autosaveYourPeriod;

        public override void receiveModConfigOpts_bool(string optName, bool value)
        {
            base.receiveModConfigOpts_bool(optName, value);
            if (optName == "Enable custom autosaves?")
                autosaveEnable = value;
            if (optName == "Enable quicksaving?")
                quicksaveEnable = value;
        }

        public override void receiveModConfigOpts_int(string optName, int value)
        {
            if (autosaveEnable == true)
            {
                base.receiveModConfigOpts_int(optName, value);
                if (optName == "Number of autosaves")
                    autosaveYourCount = value;
                else if (optName == "Turns between autosaves")
                    autosaveYourPeriod = value;
            }
            {
                    World.autosaveCount = autosaveYourCount;
                    World.autosavePeriod = autosaveYourPeriod;
                    World.log("Saving Grace - Custom autosaves enabled. Count: " + World.autosaveCount + " , Period: " + World.autosavePeriod);
            }
        }

        //public enum Action
        //{
        //    QUICK_SAVE,
        //}

        //public static Dictionary<Action, KeyCode> saveMappings = new Dictionary<Action, KeyCode>
        //{
        //    {
        //        Action.QUICK_SAVE,
        //        KeyCode.F12
        //    }
        //};

        public void QuickSaveYourself()
        {
            if (Input.GetKeyDown(KeyCode.F12))
                World.log("Saving Grace Debug - F12 pressed");
        }
    }
}


//{
//    if (Input.GetKeyDown(KeyCode.F12))
//    {
//        if (world.map != null)
//        {
//            if (world.map.masker.mask != 0)
//            {
//                world.map.masker.setMask(MapMaskManager.maskType.NONE);
//                GraphicalMap.checkData();
//                world.ui.checkData();
//                return;
//            }

//            if (GraphicalMap.selectedHex != null || GraphicalMap.selectedUnit != null)
//            {
//                GraphicalMap.selectedUnit = null;
//                GraphicalMap.selectedHex = null;
//                GraphicalMap.checkData();
//                world.ui.checkData();
//                return;
//            }
//        }

//        if (world.ui.state != UIMaster.uiState.MAIN_MENU)
//        {
//            world.ui.setToMainMenu();
//        }
//        else if (world.map != null)
//        {
//            world.ui.setToWorld();
//        }
//    }
//if (quicksaveEnable == true)
//{
//    if (Input.GetKeyDown(KeyCode.F12))
//        world.save("quicksave");
//        World.log("quicksaving");
//}
//}
