using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/use")]
public class useAction : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        //use item in room player is in
        if (useItem(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
        {
            return;
        }

        //use item in inventory
        if (useItem(controllerObj, controllerObj.playerObj.inventory, noun))
        {
            return;
        }

        //unavailable item
        controllerObj.currentText.text = "<color=#ff726fff> (O.O) There is no " + noun + "... </color>";
    }

    private bool useItem(gameController controllerObj, List<item> items, string noun)
    {
        foreach (item i in items)
        {
            if (i.itemName.ToLower() == noun)
            {
                if (controllerObj.playerObj.canUseItem(controllerObj, i))
                {
                    if (i.interactWith(controllerObj, "use"))
                    {
                        return true;
                    }
                }
                controllerObj.currentText.text = "<color=#ff726fff> (O.O) The <b>" + noun + "</b> does nothing... </color>";

                return true;
            }
        }

        return false;
    }
}
