using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/say")]
public class sayAction : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        if (sayToItem(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
            return;

        controllerObj.currentText.text = "Nothing Responds!";
    }

    private bool sayToItem(gameController controllerObj, List<item> items, string noun)
    {
        foreach(item i in items)
        {
            if(i.itemEnabled)
            {
                if (controllerObj.playerObj.canTalkToItem(controllerObj, i))
                {
                    if(i.interactWith(controllerObj,"say",noun.ToLower()))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
