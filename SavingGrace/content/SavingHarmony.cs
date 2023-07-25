using System.Collections.Generic;
using System.Reflection;
using Assets.Code;
using Assets.Code.Modding;
using HarmonyLib;
using SavingGraceMod;

namespace SavingGraceHarmonny

{
    public class SavingGraceModCore : ModKernel
    {
        private Harmony harmony;

        public override void onStartGamePresssed(Map map, List<God> gods)
        {
            harmony = new Harmony("SavingGraceMod");
            MethodInfo method = typeof(UIInputs).GetMethod("hotkeys");
            MethodInfo method2 = typeof(QuicksavingGrace).GetMethod("sgHotkeys");
            harmony.Patch(method, new HarmonyMethod(method2));
        }
    }
}