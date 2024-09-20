using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/talkTo")]
public class talkTo : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        Debug.Log("inside talkto");
        if (talkToItem(controllerObj, controllerObj.playerObj.currentLocation.items, noun))
            return;

        controllerObj.currentText.text = "<color=#ff726fff> (O.O) There is no " + noun + " here... </color>";
    }

    private bool talkToItem(gameController controllerObj, List<item> items, string noun)
    {
        foreach(item i in items)
        {
            if(i.itemEnabled)
            { 
                if(i.itemName.ToLower() == noun)
                {
                    if(controllerObj.playerObj.canTalkToItem(controllerObj,i))
                    {
                        if(i.interactWith(controllerObj, "talkto"))
                            return true;
                    }
                    controllerObj.currentText.text = "<color=#ff726fff> (O.O) The " + noun + " doesn't respond... </color>";
                    return true;
                }
            }
        }
        return false;
    }
}
