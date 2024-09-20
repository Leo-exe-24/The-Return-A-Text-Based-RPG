using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/read")]
public class readAction : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        if(readItem(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
        {
            return;
        }

        controllerObj.currentText.text = "<color=#ff726fff> (O.O) There is nothing useful... </color>";
    }

    public bool readItem(gameController controllerObj, List<item> items, string noun)
    {
        foreach (item availableItem in items)
        {
            if(availableItem.itemName.ToLower() == noun)
            {
                if (controllerObj.playerObj.canReadItem(controllerObj, availableItem))
                {
                    if (availableItem.interactWith(controllerObj, "read"))
                    {
                        return true;
                    }
                }
                controllerObj.currentText.text = "<color=#ff726fff> (v.v) The <b>" + noun + "</b> has nothing to read... </color>";

                return true;
            }
        }
        return false;
    }
}
