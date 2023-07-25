using Assets.Code;
using Assets.Code.Modding;

namespace SavingGraceMod
{
    public class AutosavingGrace : ModKernel
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
        public override void afterLoading(Map map)
        {
            if (autosaveEnable == true)
            {
                World.autosaveCount = autosaveYourCount;
                World.autosavePeriod = autosaveYourPeriod;
                World.log("Saving Grace - Autosave reinitialised after loading:" + World.autosaveCount + " , Period: " + World.autosavePeriod);
            }
        }

    }
}

