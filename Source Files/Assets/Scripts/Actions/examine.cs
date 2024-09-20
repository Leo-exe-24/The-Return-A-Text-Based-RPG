using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/examine")]
public class examine : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        //check item in room player is in
        if(checkItems(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
        {
            return;
        }

        //check item in inventory
        if (checkItems(controllerObj, controllerObj.playerObj.inventory, noun))
        {
            return;
        }

        //unavailable item
        controllerObj.currentText.text = "<color=#ff726fff> (O.O) You can't see a " + noun + "... </color>";
    }

    private bool checkItems(gameController controllerObj, List<item> items, string noun)
    {
        foreach(item i in items)
        {
            if(i.itemName.ToLower() == noun)
            {
                if(i.interactWith(controllerObj, "examine"))
                {
                    return true;
                }
                else
                {
                    controllerObj.currentText.text = "You see " + i.description;

                }
                return true;
            }
        }

        return false;
    }
}
