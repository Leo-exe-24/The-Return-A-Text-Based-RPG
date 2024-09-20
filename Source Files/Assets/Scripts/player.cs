using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores information about the Player
public class player : MonoBehaviour
{
    public location currentLocation;

    public List<item> inventory = new List<item>();

    public bool hasItemInInventory(string noun)
    {
        foreach (item itemAvailable in inventory)
        {
            if (itemAvailable.itemName.ToLower() == noun)
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool changeLocation(gameController controller, string connectionNoun)
    {
        connection currentConnection = currentLocation.getConnection(connectionNoun);
        if(currentConnection != null)
        {
            if(currentConnection.connectionEnabled)
            {
                currentLocation = currentConnection.locationObj;
                return true;
            }
        }
        return false;
    }

    internal bool canReadItem(gameController controllerObj, item availableItem)
    {
        return availableItem.playerCanReadFrom;
    }

    public void teleportPlayer(gameController controllerObj, location destination)
    {
        currentLocation = destination;
    }

    internal bool canGiveToItem(gameController controllerObj, item i)
    {
        return i.playerCanGiveTo;
    }

    internal bool canTalkToItem(gameController controllerObj, item i)
    {
        return i.playerCanTalkTo;
    }

    internal bool canUseItem(gameController controllerObj, item selectedItem)
    {
        if (selectedItem.targetItem == null)
            return true;


        //check if item is in inventory or location
        if (hasItem(selectedItem.targetItem))
            return true;

        if (currentLocation.hasItem(selectedItem.targetItem))
            return true;


        return false;
    }

    private bool hasItem(item selectedItem)
    {
        foreach(item i in inventory)
        {
            if ((i == selectedItem) && (selectedItem.itemEnabled) )
                return true;
        }
        return false;
    }
}
