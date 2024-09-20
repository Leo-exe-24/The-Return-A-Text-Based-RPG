using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool itemEnabled = true;

    public item targetItem = null;

    public interactions[] interactionArray;

    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool playerCanReadFrom = false;

    public bool interactWith(gameController controllerObj, string actionKeyword, string noun = "")
    {
        foreach (interactions interaction in interactionArray)
        {
            if(interaction.actionObj.keyword == actionKeyword)
            {
                if ((noun != "") && (noun != interaction.textToMatch))
                    continue; 

                foreach (item disableItem in interaction.itemsToDisable)
                    disableItem.itemEnabled = false;

                foreach (item enableItem in interaction.itemsToEnable)
                    enableItem.itemEnabled = true;

                foreach (connection disableCon in interaction.connectionsToDisable)
                    disableCon.connectionEnabled = false;

                foreach (connection enableCon in interaction.connectionsToEnable)
                    enableCon.connectionEnabled = true;

                if(interaction.teleportLoc != null)
                {
                    controllerObj.playerObj.teleportPlayer(controllerObj, interaction.teleportLoc);
                }

                controllerObj.currentText.text = interaction.responseText;
                controllerObj.displayLocation(true);

                return true;
            }
        }
        return false;
    }
}
