using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="actions/inventory")]
public class inventory : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        if(controllerObj.playerObj.inventory.Count == 0)
        {
            controllerObj.currentText.text = "<color=#ff726fff> (O.O) You collected Nothing... </color>";
        }
        else
        {
            string result = "You have...";
            bool first = true;
            foreach(item collectedItem in controllerObj.playerObj.inventory)
            {
                if (first)
                {
                    result += "\n --- a <b>" + collectedItem.itemName + "</b>";
                    first = false;
                }
                else
                {
                    result += "\n --- and a <b>" + collectedItem.itemName + "</b>";
                }
            }
            controllerObj.currentText.text = "<color=#ffff00ff>" + result + "</color>";
        }
    }
}
