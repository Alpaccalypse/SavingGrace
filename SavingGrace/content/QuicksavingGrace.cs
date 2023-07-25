using Assets.Code;
using System.Collections.Generic;
using UnityEngine;

namespace SavingGraceMod
{
    public class QuicksavingGrace
    {

        public static Dictionary<KeyCode, System.Action> saveMappings = new Dictionary<KeyCode, System.Action>
        {
            {
                KeyCode.S,
                quickSave
            },
            {
                KeyCode.L,
                quickLoad
            },
        };

        public static bool IsPressed(KeyCode key)
        {

            return Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), key.ToString(), false));
        }

        public static void sgHotkeys()
        {
            World world = GraphicalMap.world;
            if (world.ui.uiTopRight.cheatField.isFocused || world.ui.uiLeftPrimary.notes.isFocused || world.ui.uiTopRight.mapGenInputField.isFocused || world.ui.uiScrollables.scrollable_threats.filterField.isFocused || world.ui.uiScrollables.scrollable_locs.filter.isFocused)
            {
                return;
            }

            if (GraphicalMap.world.ui.state == UIMaster.uiState.WORLD)
            {
                foreach (var hotkey in saveMappings)
                {
                    if (IsPressed(hotkey.Key) && Input.GetKey(KeyCode.LeftControl))
                    {
                        hotkey.Value();
                    }
                    else if (IsPressed(hotkey.Key) && Input.GetKey(KeyCode.RightControl))
                    {
                        hotkey.Value();
                    }
                }
            }
        }

        public static void quickSave()
        {
            World world = GraphicalMap.world;
            if (world.ui.state == UIMaster.uiState.WORLD && world.map != null && world.ui.blocker == null)
            {
                World.log("Quicksaving");
                world.save("quicksave.sv");
            }
        }
        public static void quickLoad()
        {
            World world = GraphicalMap.world;
            if (world.ui.state == UIMaster.uiState.WORLD && world.map != null && world.ui.blocker == null)
            {
                World.log("Loading quicksave");
                world.load("quicksave.sv");
            }
        }

    }
}
