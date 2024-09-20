using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/get")]
public class getAction : actions
{
    public override void respondToInput(gameController controllerObj, string noun)
    {
        foreach(item availableItem in controllerObj.playerObj.currentLocation.items)
        {
            if (availableItem.itemEnabled && availableItem.itemName.ToLower() == noun)
            {
                if (availableItem.playerCanTake)
                {
                    controllerObj.playerObj.inventory.Add(availableItem);
                    controllerObj.playerObj.currentLocation.items.Remove(availableItem);
                    controllerObj.currentText.text = "You have picked up " + noun;
                    return;
                    
                }
            }
        }
        controllerObj.currentText.text = "<color=#ff726fff> (v.v) You cannot take that! </color>";
    }
}
