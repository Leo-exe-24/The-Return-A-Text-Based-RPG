using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/give")]
public class giveAction : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        if(controllerObj.playerObj.hasItemInInventory(noun))
        { 
            if (giveToItem(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
                return;
            controllerObj.currentText.text = "Nothing takes the " + noun;
            return;
        }
        controllerObj.currentText.text = "<color=#ff726fff> (O.O) You don't have a " + noun + "... </color>";
    }

    private bool giveToItem(gameController controllerObj, List<item> items, string noun)
    {
        foreach (item i in items)
        {
            if (i.itemEnabled)
            {
                if (controllerObj.playerObj.canGiveToItem(controllerObj, i))
                {
                    if (i.interactWith(controllerObj, "give", noun.ToLower()))
                    {
                        return true;
                    }
                }
            }

        }
        return false;
    }
}
